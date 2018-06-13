using System.Collections.Generic;
using FastColoredTextBoxNS.Events;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public interface ILanguage
	{
		string Name { get; }
		string Extension { get; }

		List<Rule> Rules { get; }

        string CommentPrefix { get; }

        char LeftBracket { get; set; }
        char RightBracket { get; set; }

        char LeftBracket2 { get; set; }
        char RightBracket2 { get; set; }

        string AutoIndentCharsPatterns { get; }
        
        List<Marker> FoldingMarkers { get; }

		/// <summary>
		/// Strategy of search of brackets to highlighting
		/// </summary>
		BracketsHighlightStrategy BracketsHighlightStrategy { get; }

		void AutoIndentNeeded(AutoIndentEventArgs args);

        Style[] GetStyles();
    }
}
