using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderer
{
    public partial class Form1 : Form
    {
        private string _imagesPath;
        private string _exePath;
        private string _modelPath;

        public Form1(ConsoleWriter writer)
        {
            InitializeComponent();

            writer.WriteEvent += consoleWriter_WriteEvent;
            writer.WriteLineEvent += consoleWriter_WriteLineEvent;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string help = @"1. Run PTC setup and instal VB Api on PTC Parametric as shown in picture (""VBApi_install.png"")

2.Set Environement Variables > System Variables to:
Variable: PRO_COMM_MSG_EXE
Value: < path_to_PTC >\Common Files\x86e_win64\obj\pro_comm_msg.exe

3.register the COM server
run the vb_api_register.bat file located at<install>\Creo \Parametric\bin

4.Open part in creo as administrator
and then run renderer exe as administrator and images will appear where part is the inside directory with part name

IF PROBLEMS:
In case of any errors that cannot be solved following procedure above, run ""vb_api_perm_register.bat"" file FROM THE SAME DIRECTORY WHERE IS ""vb_api_register.bat""";

            MessageBox.Show(help);
        }

        private void btnImagesDir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Pick Directory For Rendered Images";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _imagesPath = fbd.SelectedPath;
                    tbImagesPath.Text = fbd.SelectedPath;

                    gbApp.Enabled = true;
                    gbModel.Enabled = true;
                }
                else
                {
                    _imagesPath = null;
                    tbImagesPath.Text = null;

                    gbApp.Enabled = false;
                    gbModel.Enabled = false;
                }
            }
        }

        private void btnExePath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Filter = "*.exe|*.exe";
                ofd.Multiselect = false;
                ofd.Title = "Parametric EXE";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _exePath = ofd.FileName;
                    tbExePath.Text = ofd.FileName;
                }
                else
                {
                    _exePath = null;
                    tbExePath.Text = null;
                }
            }

            EnableSaveBtn();
        }

        private void btnModelPath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Filter = "*.prt*|*.prt*";
                ofd.Multiselect = false;
                ofd.Title = "Model file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _modelPath = ofd.FileName;
                    tbModelPath.Text = ofd.FileName;
                }
                else
                {
                    _modelPath = null;
                    tbModelPath.Text = null;
                }
            }

            EnableSaveBtn();
        }

        private void EnableSaveBtn()
        {
            if (_exePath != null && _modelPath != null)
            {
                btnStartFromModel.Enabled = true;
            }
            else
            {
                btnStartFromModel.Enabled = false;
            }
        }

        private void btnStartFromApp_Click(object sender, EventArgs e)
        {
            DisabeAndCleanlUI();
            Task.Factory.StartNew(() =>
            {
                Render.Main(new string[] { _imagesPath });

                EnableUI();
            }, TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent);
        }

        private void btnStartFromModel_Click(object sender, EventArgs e)
        {
            DisabeAndCleanlUI();
            Task.Factory.StartNew(() =>
            {
                Render.Main(new string[] { _imagesPath, _exePath, _modelPath });

                EnableUI();
            }, TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent);
        }

        private void DisabeAndCleanlUI()
        {
            tbResult.Clear();
            gbApp.Enabled = false;
            gbModel.Enabled = false;
            btnImagesDir.Enabled = false;
        }

        private void EnableUI()
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                gbApp.Enabled = true;
                gbModel.Enabled = true;
                btnImagesDir.Enabled = true;
            }));
        }

        private void consoleWriter_WriteLineEvent(object sender, ConsoleWriterEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => tbResult.AppendText(e.Value + "\n")));
        }

        private void consoleWriter_WriteEvent(object sender, ConsoleWriterEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => tbResult.AppendText(e.Value)));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.In.Close();
        }
    }
}
