using System;
using System.IO;
using System.Runtime.InteropServices;
using pfcls;

namespace PtcCreoRenderer
{
    internal class Program
    {
        public static IpfcWindow Window;
        public static IpfcBaseSession Session;
        public static IpfcAsyncConnection AsyncConnection;
        public static CCpfcAsyncConnection Casync;

        private static void Main(string[] args)
        {
            // close handler
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            if (ConnectToPtc())
            {
                StartRender();
            }

            Console.WriteLine("\nPress any key to exit!");
            Console.ReadKey();
        }

        private static bool ConnectToPtc()
        {
            try
            {
                if (Casync == null)
                {
                    Casync = new CCpfcAsyncConnection();
                    AsyncConnection = Casync.GetActiveConnection();

                    if (AsyncConnection == null)
                    {
                        AsyncConnection = Casync.Connect(null, null, null, null);
                    }
                    Session = (IpfcBaseSession)AsyncConnection.Session;
                }
            }
            catch
            {
                Console.WriteLine("\nMake sure model is opened.");
                return false;
            }

            return true;
        }

        public static IpfcModel GetActiveDocument()
        {
            return Session.CurrentModel;
        }

        public static void StartRender()
        {
            try
            {
                IpfcModel startingDocument = GetActiveDocument();
                if (startingDocument != null)
                {
                    // do the rendering
                    IpfcSolid solid = (IpfcSolid)startingDocument;
                    IpfcFamilyMember familyMember = (IpfcFamilyMember)solid;
                    string activeDocumentPath = startingDocument.Origin;

                    string cleanDocName = string.Concat(startingDocument.FullName?.Split(Path.GetInvalidFileNameChars()));
                    string activeDocumentFolder = Path.Combine(Path.GetDirectoryName(activeDocumentPath), cleanDocName + "_renders");

                    if (Directory.Exists(activeDocumentFolder) == false)
                    {
                        Directory.CreateDirectory(activeDocumentFolder);
                    }

                    double widthImg = 19.2;
                    double heightImg = 10.8;
                    string imageExtension = ".png";
                    IpfcRasterImageExportInstructions instructions = (IpfcRasterImageExportInstructions)new CCpfcBitmapImageExportInstructions().Create(widthImg, heightImg);
                    instructions.DotsPerInch = EpfcDotsPerInch.EpfcRASTERDPI_300;
                    instructions.ImageDepth = EpfcRasterDepth.EpfcRASTERDEPTH_24;

                    CpfcFamilyTableRows familyTableRows = familyMember.ListRows();
                    var total = familyTableRows.Count;
                    float count = 0;
                    foreach (IpfcFamilyTableRow familyTableRow in familyTableRows)
                    {
                        string instanceName = familyTableRow.InstanceName;
                        Console.Write("instanceName = " + instanceName);

                        string pathForImg = Path.Combine(activeDocumentFolder, instanceName + imageExtension);

                        IpfcModel instanceModel = familyTableRow.CreateInstance();
                        instanceModel.Display();

                        Window = Session.GetModelWindow(instanceModel);
                        Window.ExportRasterImage(pathForImg, instructions);
                        instanceModel.Delete();

                        count++;
                        Console.WriteLine(" \t - " + (count / total).ToString("0.00%") + " \t ({0}/{1})", count, total);
                    }
                }
                else
                {
                    Console.WriteLine("\nCould not get active document.");
                }

                // return to view of starting document
                if (startingDocument != null)
                {
                    startingDocument.Display();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Cleanup();
            }
        }

        private static void Cleanup()
        {
            if (AsyncConnection != null)
            {
                try
                {
                    AsyncConnection.End();
                }
                catch
                {
                    Console.WriteLine("\nConnection end error.");
                }
            }
        }

        #region Trap application termination

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);

        private static EventHandler _handler;

        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            Console.WriteLine("Exiting system due to external CTRL-C, or process kill, or shutdown");

            // do the cleanup - up to 5 sec MAX
            // or OS will kill everything instead
            Cleanup();

            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);

            return true;
        }

        #endregion Trap application termination
    }
}
