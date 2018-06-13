//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pavel_torgashov@ukr.net
//
//  Copyright (C) Pavel Torgashov, 2011-2016. 

// #define debug


// -------------------------------------------------------------------------------
// By default the FastColoredTextbox supports no more 16 styles at the same time.
// This restriction saves memory.
// However, you can to compile FCTB with 32 styles supporting.
// Uncomment following definition if you need 32 styles instead of 16:
//
// #define Styles32

using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS.Events
{
	public class WordWrapNeededEventArgs : EventArgs
    {
        public List<int> CutOffPositions { get; private set;}
        public bool ImeAllowed { get; private set;}
        public Line Line { get; private set; }



        public WordWrapNeededEventArgs(List<int> cutOffPositions, bool imeAllowed, Line line)
        {
            CutOffPositions = cutOffPositions;
            ImeAllowed = imeAllowed;
            Line = line;
        }
    }
}
