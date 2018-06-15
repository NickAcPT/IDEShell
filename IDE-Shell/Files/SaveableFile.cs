//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System;
using System.IO;

namespace NickAc.IDE_Shell.Files
{
    public class SaveableFile : ViewableFile
    {
        public override bool SaveFile()
        {
            if (FileInfo == null)
                return SaveFileAs(null);

            //TODO: Add option to disable safe save
            var tempFilePath = Path.Combine(FileInfo.Directory?.FullName ?? "", Guid.NewGuid().ToString("N"));
        
            File.WriteAllBytes(tempFilePath, Contents ?? new byte[0]);
            
            if (File.Exists(FileInfo.FullName))
            {
                File.Delete(FileInfo.FullName);
            }
            File.Move(tempFilePath, FileInfo.FullName);
            return true;
        }
    }
}