//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU v3 License. See LICENSE file in the project root for full license information.
//  

using System.Reflection;
using System.Security;
using System.Text;
using System.Windows.Forms;
using NickAc.IDE_Shell.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NickAc.IDE_Shell
{
    public class ShellForm : BaseThemedForm
    {
        protected DockPanel DockPanel { get; }

        public ThemeBase DockTheme { get; set; } = new VS2015DarkTheme();

        protected VisualStudioToolStripExtender toolStripExtender = new VisualStudioToolStripExtender();

        public ShellForm()
        {
            this.Controls.Add(DockPanel);
        }
    }
}