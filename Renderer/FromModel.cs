using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Renderer
{
    public class FromModel
    {
        private static string logName = "logM";
        private static int logEntriesCount = 5;

        public static pfcls.IpfcWindow Window;
        public static pfcls.IpfcBaseSession Session;
        public static pfcls.IpfcAsyncConnection AsyncConnection;
        public static pfcls.CCpfcAsyncConnection Casync;
        public static pfcls.IpfcModel StartingDocument;

        private string _exe = @"C:\PTC_stuff\Creo 4.0\M050\Parametric\bin\parametric.exe"; // for test
        private string _modelPath;
        private string _imagesFolder;

        public void Start(string imagesFolder, string exe, string modelPath)
        {
            _imagesFolder = imagesFolder;

            if (exe != "test")
            {
                _exe = exe;
            }

            _modelPath = modelPath;

            SetLogFile();

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

        private void SetLogFile()
        {
            var files = Directory.GetFiles(".", "*.log");

            int num = files.Length % logEntriesCount;

            logName = logName + num + ".log";

            var f = File.Create(logName);
            f.Close();
        }

        private void SetModel()
        {
            pfcls.IpfcModelDescriptor descModel;

            Session.ChangeDirectory(Environment.CurrentDirectory);
            descModel = (new pfcls.CCpfcModelDescriptor()).CreateFromFileName(_modelPath);

            StartingDocument = Session.RetrieveModel(descModel);
        }

        private bool ConnectToPtc()
        {
            Console.WriteLine("\nConnecting to PTC...");

            try
            {
                File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " Connect to ptc start... \n");

                if (Casync == null)
                {
                    Casync = new pfcls.CCpfcAsyncConnection();
                    AsyncConnection = Casync.GetActiveConnection();

                    if (AsyncConnection == null)
                    {
                        AsyncConnection = Casync.Start(_exe /*+ " -g:no_graphics -i:rpc_input"*/, ".");
                        File.AppendAllText(logName, DateTime.UtcNow.ToString("yy.MM.dd HH:mm:ss ") + " got connection \n");
                    }
                    Session = (pfcls.IpfcBaseSession)AsyncConnection.Session;
                    SetModel();
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

        private pfcls.IpfcModel GetActiveDocument()
        {
            return Session.CurrentModel ?? StartingDocument;
        }

        private void StartRender()
        {
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
                    try
                    {
                        if (dir == null)
                        {
                            dir = Path.GetDirectoryName(_modelPath);
                        }
                    }
                    catch { }

                    string activeDocumentFolder = Path.Combine(dir, cleanDocName + "_renders");

                    Console.WriteLine("Images will be in " + activeDocumentFolder);

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

        private void Cleanup()
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
    }
}
