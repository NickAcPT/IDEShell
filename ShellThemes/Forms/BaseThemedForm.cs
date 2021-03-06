﻿using System;
using System.Drawing;
using System.Windows.Forms;
using NickAc.IDE_Shell.Themes;
using NickAc.ModernUIDoneRight.Forms;

namespace NickAc.IDE_Shell.Forms
{
    public partial class BaseThemedForm : ModernForm
    {
        private bool _shouldMakeBorderBig = true;

        public BaseThemedForm()
        {
            InitializeComponent();
            TitlebarHeight = 31;
        }

        public bool ShouldMakeBorderBig
        {
            get => _shouldMakeBorderBig;
            set
            {
                _shouldMakeBorderBig = value;
                var rect = DisplayRectangle;
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                if (!ShouldMakeBorderBig) return base.DisplayRectangle;
                var rect = base.DisplayRectangle;
                const int borderSize = 7;
                return Rectangle.FromLTRB(rect.Left + borderSize, rect.Top, rect.Right - borderSize,
                    rect.Bottom - borderSize);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int wmParentnotify = 0x0210;
            if (!Focused && m.Msg == wmParentnotify) Activate();
            base.WndProc(ref m);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ThemeManager.CurrentTheme.ApplyToModernForm(this);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            using (var sb = new SolidBrush(ColorScheme.PrimaryColor))
            {
                e.Graphics.FillRectangle(sb,
                    Rectangle.FromLTRB(TitlebarRectangle.Left, TitlebarRectangle.Bottom, DisplayRectangle.Left,
                        DisplayRectangle.Bottom));
                e.Graphics.FillRectangle(sb,
                    Rectangle.FromLTRB(DisplayRectangle.Right, TitlebarRectangle.Bottom, TitlebarRectangle.Right,
                        DisplayRectangle.Bottom));

                e.Graphics.FillRectangle(sb,
                    Rectangle.FromLTRB(TitlebarRectangle.Left, DisplayRectangle.Bottom, TitlebarRectangle.Right,
                        Height - BorderOffset));
            }
        }
    }
}