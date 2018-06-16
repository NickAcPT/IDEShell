//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.ComponentModel.Composition;
using Newtonsoft.Json;

namespace NickAc.IDE_Shell.Config
{
    [InheritedExport(typeof(IConfigSection))]
    public interface IConfigSection
    {   
        [JsonIgnore]
        string DisplayName { get; }
    }
}