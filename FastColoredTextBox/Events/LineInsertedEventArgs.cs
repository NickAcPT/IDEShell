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

namespace FastColoredTextBoxNS.Events
{
	public class LineInsertedEventArgs : EventArgs
    {
		/// <summary>
		/// Inserted line index
		/// </summary>
		public int Index { get; private set; }

		/// <summary>
		/// Count of inserted lines
		/// </summary>
		public int Count { get; private set; }



		public LineInsertedEventArgs(int index, int count)
        {
            Index = index;
            Count = count;
        }        
    }
}
