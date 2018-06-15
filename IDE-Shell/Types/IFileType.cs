//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.ComponentModel.Composition;
using FastColoredTextBoxNS.Models.Syntaxes;

namespace NickAc.IDE_Shell.Types
{
    [InheritedExport(typeof(IFileType<>))]
    public interface IFileType<T> where T: ILanguage
    {
        string[] FileExtensions { get; }

        string TypeDescription { get; }
    }
}