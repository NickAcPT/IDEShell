//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.IO;

namespace NickAc.IDE_Shell.Files
{
    public class ViewableFile : IFile
    {
        public ViewableFile(FileInfo info)
        {
            FileInfo = info;
        }

        public ViewableFile()
        {
        }

        public FileInfo FileInfo { get; set; }
        public bool SaveFile()
        {
            if (FileInfo == null)
            {
                
            }
        }

        public bool SaveFileAs(FileInfo info)
        {
            throw new System.NotImplementedException();
        }
    }
}