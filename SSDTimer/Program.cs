using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SSDTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string AppName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            Process[] RunningProcesses = Process.GetProcessesByName(AppName);
            if (RunningProcesses.Length <= 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SSDContext());
            }
            else
            {
                return;
            }
        }
    }
}
