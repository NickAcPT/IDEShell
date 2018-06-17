//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU v3 License. See LICENSE file in the project root for full license information.
//  

using System;
using System.Drawing;
using System.Windows.Forms;
using NickAc.IDE_Shell.Forms;
using NickAc.IDE_Shell.Menu;
using WeifenLuo.WinFormsUI.Docking;

namespace NickAc.IDE_Shell
{
    public class ShellForm : BaseThemedForm
    {
        private const string WaterMark = "Powered by IDE-Shell";
        protected VisualStudioToolStripExtender toolStripExtender = new VisualStudioToolStripExtender();

        public ShellForm()
        {
            ShouldMakeBorderBig = false;
            UniqueId = Guid.NewGuid();
            UiManager.CheckIfInitialized();
            InitDockPanel();
            InitMenu();
            InitMenuItems();
            Controls.Add(DockPanel);
        }


        private void InitMenu()
        {
            MainMenuStrip = new MenuStrip();
            toolStripExtender.SetStyle(MainMenuStrip, VisualStudioToolStripExtender.VsVersion.Vs2015,
                DockPanel.Theme);
            Controls.Add(MainMenuStrip);
        }

        private void InitMenuItems()
        {
            GetMenu("&File")
                .AddItem("&New")
                .AddItem("&Open")
                .AddItem("-")
                .AddItem("&Close")
                .BuildMenu();

            GetMenu("&New")
                .AddItem("&Project")
                .AddItem("&File")
                .BuildMenu();
        }

        public Guid UniqueId { get; set; }

        protected DockPanel DockPanel { get; private set; }

        public ThemeBase DockTheme { get; set; } = new VS2015DarkTheme();

        public IMenuItemHolder GetMenu(string menu)
        {
            return MenuBuilder.GetMenu(menu, this);
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                UiManager.CheckIfInitialized();
                base.Text = UiManager.IdeName + (value != string.Empty ? @" - " + value : string.Empty);
            }
        }

        private void InitDockPanel()
        {
            Load += (s, e) => Text = "";
            DockPanel = new DockPanel
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