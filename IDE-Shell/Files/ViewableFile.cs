//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.IO;
using FastColoredTextBoxNS.Models.Syntaxes;
using NickAc.IDE_Shell.Types;

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

        public IFileType<ILanguage> FileType { get; set; }

        public bool SaveFile()
        {
            return false;
        }

        public bool SaveFileAs(FileInfo info)
        {
            //Save the file
            return false;
        }
    }
}