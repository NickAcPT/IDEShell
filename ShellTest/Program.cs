using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NickAc.IDE_Shell;

namespace ShellTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UiManager.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
