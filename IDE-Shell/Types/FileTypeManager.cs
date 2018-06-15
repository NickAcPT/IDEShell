//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the LGPL v3 License. See LICENSE file in the project root for full license information.
//  

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using FastColoredTextBoxNS.Models.Syntaxes;

namespace NickAc.IDE_Shell.Types
{
    public class FileTypeManager
    {
        private FileTypeManager _instance;

        public FileTypeManager Instance => _instance ?? (_instance = new FileTypeManager());

        public FileTypeManager()
        {
            Compose();    
        }

        [ImportMany(typeof(IFileType<>))]
        public List<IFileType<ILanguage>> FileTypes { get; set; }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }

    }
}