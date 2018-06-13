//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.IO;

namespace NickAc.IDE_Shell.Files
{
    public interface IFile
    {
        FileInfo FileInfo { get; set; }

        bool SaveFile();

        bool SaveFileAs(FileInfo info);
    }
}