using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NickAc.IDE_Shell;

namespace ShellTest
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UiManager.Init("TestIDE");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
