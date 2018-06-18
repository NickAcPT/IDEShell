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
        
        private static ushort LoWord(ulong l) { return (ushort)(l & 0xFFFF); }
        private static ushort HiWord(ulong l) { return (ushort)((l >> 16) & 0xFFFF); }
        private static ushort GetXLParam(ulong lp) { return LoWord(lp); }
        private static ushort GetYLParam(ulong lp) { return HiWord(lp); }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private int MakeLParam(int p, int p_2)
        {
            return ((p_2 << 16) | (p & 0xFFFF));
        }   
        protected override void WndProc(ref Message m)
        {
            const int wmMousemove = 512;
            const int wmLbuttondown = 513;
            const int wmLbuttonup = 514;
            const int wmLbuttondblclk = 515;

            if (((m.Msg == wmLbuttonup) || (m.Msg == wmLbuttondown) || (m.Msg == wmLbuttondblclk) || (m.Msg == wmMousemove)) && !DesignMode && Parent != null) {
                if (!ShouldSelectItem()) {
                    var findForm = FindForm();

                    var localPoint = PointToScreen(new Point(GetXLParam((ulong) m.LParam), GetYLParam((ulong) m.LParam)));
                    var formPoint = findForm.PointToClient(localPoint);

                    SendMessage(findForm.Handle, m.Msg, m.WParam, (IntPtr) MakeLParam(formPoint.X, formPoint.Y));
                    Parent.Capture = true;
                    Capture = false;
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }

}