//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.ComponentModel.Composition;

namespace NickAc.IDE_Shell.Config
{
    [InheritedExport(typeof(IConfigSection))]
    public interface IConfigSection
    {
        string DisplayName { get; }
    }
}