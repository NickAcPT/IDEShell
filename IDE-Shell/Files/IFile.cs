//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.IO;
using FastColoredTextBoxNS.Models.Syntaxes;
using NickAc.IDE_Shell.Types;

namespace NickAc.IDE_Shell.Files
{
    public interface IFile
    {
        byte[] Contents { get; set; }

        FileInfo FileInfo { get; set; }

        IFileType<ILanguage> FileType { get; set; }

        bool SaveFile();

        bool SaveFileAs(FileInfo info);
    }
}