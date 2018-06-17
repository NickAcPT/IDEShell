//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NickAc.IDE_Shell.Controls
{
    public class MouseThroughStatusStrip : StatusStrip
    {
        public MouseThroughStatusStrip()
        {
            AutoSize = false;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        internal static Point invalidMouseEnter = new Point(2147483647, 2147483647);
        private Point _mouseEnterWhenShown = invalidMouseEnter;

        private bool ShouldSelectItem()
        {
            Point p = PointToClient(Cursor.Position);
            return GetItemAt(p) != null;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            const int wmMousemove = 512;
            const int wmLbuttondown = 513;
            const int wmLbuttonup = 514;
            const int wmLbuttondblclk = 515;

            if (((m.Msg == wmLbuttonup) || (m.Msg == wmLbuttondown) || (m.Msg == wmLbuttondblclk) || (m.Msg == wmMousemove)) && !DesignMode && Parent != null) {
                if (!ShouldSelectItem()) {
                    SendMessage(Parent.Handle, m.Msg, m.WParam, m.LParam);
                    Parent.Capture = true;
                    Capture = false;
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }

}