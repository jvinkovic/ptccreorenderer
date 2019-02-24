using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Renderer
{
    public class Render
    {
        private static string logName = "log";
        private static int logEntriesCount = 5;

        public static pfcls.IpfcWindow Window;
        public static pfcls.IpfcBaseSession Session;
        public static pfcls.IpfcAsyncConnection AsyncConnection;
        public static pfcls.CCpfcAsyncConnection Casync;
        public static pfcls.IpfcModel StartingDocument;

        private static string _imagesFolder;

        /// <summary>
        /// args -> [images path, exe path, model path]
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                _imagesFolder = args[0];
            }

            if (args.Length == 3)
            {
                string modelPath = args[2].Substring(0, args[2].LastIndexOf("prt") + 3);

                var p = new FromModel();
                p.Start(_imagesFolder, args[1], modelPath);
                return;
            }

            SetLogFile();

            // close handler
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            if (ConnectToPtc())
            {
                StartRender();
            }

            File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " END \n");

            if (Console.IsOutputRedirected == false)
            {
                Console.WriteLine("\nPress any key to exit!");
                Console.ReadKey();
            }
        }

        private static void SetLogFile()
        {
            var files = Directory.GetFiles(".", "*.log");

            int num = files.Length % logEntriesCount;

            logName = logName + num + ".log";

            var f = File.Create(logName);
            f.Close();
        }

        private static bool ConnectToPtc()
        {
            Console.Write("Starting connection...");

            try
            {
                File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " Connect to ptc start... \n");

                if (Casync == null)
                {
                    Casync = new pfcls.CCpfcAsyncConnection();
                    AsyncConnection = Casync.GetActiveConnection();

                    if (AsyncConnection == null)
                    {
                        AsyncConnection = Casync.Connect(null, null, null, null);
                        File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " got connection \n");
                    }
                    Console.Write(" Connected!");

                    Session = (pfcls.IpfcBaseSession)AsyncConnection.Session;
                    Console.WriteLine(", Got session!");
                    File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " got session \n");
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + ex + " \n");
                Console.WriteLine("\nMake sure model is opened with Administrator rights. \n" + ex + "\n");
                return false;
            }

            return true;
        }

        public static pfcls.IpfcModel GetActiveDocument()
        {
            return Session.CurrentModel ?? StartingDocument;
        }

        public static void StartRender()
        {
            Console.WriteLine("Starting rendering...");

            try
            {
                StartingDocument = GetActiveDocument();
                File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " got document \n");
                if (StartingDocument != null)
                {
                    // do the rendering
                    pfcls.IpfcSolid solid = (pfcls.IpfcSolid)StartingDocument;
                    pfcls.IpfcFamilyMember familyMember = (pfcls.IpfcFamilyMember)solid;

                    string cleanDocName = string.Concat(StartingDocument.FullName?.Split(Path.GetInvalidFileNameChars()));
                    var dir = _imagesFolder;
                    if (dir == null)
                    {
                        try
                        {
                            dir = Path.GetDirectoryName(StartingDocument.Origin);
                        }
                        catch
                        {
                            dir = "";
                        }
                    }

                    string activeDocumentFolder = Path.Combine(dir, cleanDocName + "_renders");

                    Console.WriteLine("Images will be in \"" + activeDocumentFolder + "\"");

                    if (Directory.Exists(activeDocumentFolder) == false)
                    {
                        Directory.CreateDirectory(activeDocumentFolder);
                    }

                    double widthImg = 19.2;
                    double heightImg = 10.8;
                    string imageExtension = ".png";
                    pfcls.IpfcRasterImageExportInstructions instructions = (pfcls.IpfcRasterImageExportInstructions)new pfcls.CCpfcBitmapImageExportInstructions().Create(widthImg, heightImg);
                    instructions.DotsPerInch = pfcls.EpfcDotsPerInch.EpfcRASTERDPI_300;
                    instructions.ImageDepth = pfcls.EpfcRasterDepth.EpfcRASTERDEPTH_24;

                    Console.WriteLine("Getting instances...");
                    File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " Getting instances... \n");
                    pfcls.CpfcFamilyTableRows familyTableRows = familyMember.ListRows();
                    var total = familyTableRows.Count;
                    float count = 0;
                    File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " start render all \n");
                    foreach (pfcls.IpfcFamilyTableRow familyTableRow in familyTableRows)
                    {
                        string instanceName = familyTableRow.InstanceName;
                        Console.Write("instanceName = " + instanceName);

                        string pathForImg = Path.Combine(activeDocumentFolder, instanceName + imageExtension);

                        pfcls.IpfcModel instanceModel = familyTableRow.CreateInstance();
                        instanceModel.Display();

                        Window = Session.GetModelWindow(instanceModel);
                        Window.ExportRasterImage(pathForImg, instructions);

                        count++;
                        Console.WriteLine(" \t - " + (count / total).ToString("0.00%") + " \t ({0}/{1})", count, total);
                    }

                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("\nCould not get active document.");
                    File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " Could not get active document \n");
                }

                // return to view of starting document
                if (StartingDocument != null)
                {
                    StartingDocument.Display();
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + ex + " \n");
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
                    File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " Connection end error. \n");
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
