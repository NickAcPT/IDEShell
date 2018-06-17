//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU v3 License. See LICENSE file in the project root for full license information.
//  

using System.Drawing;
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
        private const string WaterMark = "Powered by IDE-Shell Community Edition";
        protected DockPanel DockPanel { get; private set; }

        public ThemeBase DockTheme { get; set; } = new VS2015DarkTheme();

        protected VisualStudioToolStripExtender toolStripExtender = new VisualStudioToolStripExtender();

        public override string Text
        {
            get => base.Text;
            set
            {
                UiManager.CheckIfInitialized();
                base.Text = UiManager.IdeName + (value != string.Empty ? @" - " + value : string.Empty);
            }
        }

        public ShellForm()
        {
            UiManager.CheckIfInitialized();
            InitDockPanel();
            this.Controls.Add(DockPanel);
        }

        private void InitDockPanel()
        {
            Load += (s, e) => Text = "";
            DockPanel = new DockPanel()
            {
                Dock = DockStyle.Fill,
                Theme = DockTheme
            };

            if (UiManager.IsWatermarkEnabled)
            {
                var rectSize = SizeF.Empty;
                DockPanel.Paint += (s, e) =>
                {
                    if (rectSize.IsEmpty)
                        rectSize = e.Graphics.MeasureString(WaterMark, TitleBarFont);
                    var dr = DockPanel.DisplayRectangle;
                    using (var sb = new SolidBrush(Color.FromArgb(15, DockPanel.Theme.ColorPalette.TabUnselected.Text)))
                    {
                        e.Graphics.DrawString(WaterMark, TitleBarFont, sb,
                            Rectangle.FromLTRB((int) (dr.Right - rectSize.Width), (int) (dr.Bottom - rectSize.Height),
                                dr.Right, dr.Bottom));
                    }
                };
            }
        }
    }
}