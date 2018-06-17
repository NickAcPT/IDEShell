//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU v3 License. See LICENSE file in the project root for full license information.
//  

using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace NickAc.IDE_Shell
{
    public class UiManager
    {
        private const string MainClassEntryPoint = "Program";

        protected internal static bool IsWatermarkEnabled { get; private set; }

        public static string IdeName { get; private set; } = "";

        public static bool Initialized { get; private set; }

        public static void Init(string ideName, bool watermark = true)
        {
            CheckProgramClass();
            Initialized = true;
            IsWatermarkEnabled = watermark;
            IdeName = ideName;
        }

        public static void CheckIfInitialized()
        {
            if (!Initialized)
                throw new Exception("The IDE wasn't initialized yet.");
        }

        private static string GetCallerName()
        {
            var caller = GetCaller();
            return caller?.Name;
        }

        private static Type GetCaller()
        {
            var frame = new StackFrame(4);
            var caller = frame.GetMethod().DeclaringType;
            if (caller?.Name == MainClassEntryPoint && caller.IsSubclassOf(typeof(Control)))
                throw new Exception("The Program.cs class shouldn't extend any WindowsForms Control.");
            return caller;
        }

        private static void CheckProgramClass()
        {
            if (GetCallerName() != MainClassEntryPoint)
                throw new Exception("This method can only be called in the Program.cs class");
        }
    }
}