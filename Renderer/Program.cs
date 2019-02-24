using System;
using System.Windows.Forms;

namespace Renderer
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var consoleWriter = new ConsoleWriter())
            {
                Console.SetOut(consoleWriter);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(consoleWriter));
            }
        }
    }
}
