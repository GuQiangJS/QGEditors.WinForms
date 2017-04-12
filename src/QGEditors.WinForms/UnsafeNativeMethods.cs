// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace QGEditors.WinForms {
    internal static class UnsafeNativeMethods {
        internal const int EC_LEFTMARGIN = 0x1;
        internal const int EC_RIGHTMARGIN = 0x2;
        internal const int EM_SETMARGINS = 0xD3;

        internal const int EM_SETRECT = 0xB3;

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}