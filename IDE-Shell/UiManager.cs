//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU v3 License. See LICENSE file in the project root for full license information.
//  

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace NickAc.IDE_Shell
{
    public class UiManager
    {
        private const string Str1 =
            "80​111​119​101​114​101​100​32​98​121​32​73​68​69​45​83​104​101​108​108​32​67​111​109​109​117​110​105​116​121​32​69​100​105​116​105​111​110";

        private string _(string str)
        {
            var sstr = new StringBuilder();
            foreach (var s in Str1.Split('​'))
            {
                sstr.Append((char) int.Parse(s));
            }

            return str;
        }

        public static void Init(bool watermark = true)
        {
            CheckProgramClass();
        }

        private static string GetCallerName()
        {
            var frame = new StackFrame(3);
            var caller = frame.GetMethod().DeclaringType?.Name;
            return caller;
        }

        private static void CheckProgramClass()
        {
            if (GetCallerName() != "Program")
                throw new Exception("This method can only be called in the Program.cs class");
        }
    }
}