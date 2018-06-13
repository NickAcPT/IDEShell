using FastColoredTextBoxNS.Models.Syntaxes;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.Events;

namespace FastColoredTextBoxNS
{
    public class SyntaxHighlighter
	{
		protected FastColoredTextBox Fctb { get; set; }
		protected static Platform PlatformType { get; private set; }
        protected List<Style> ResilientStyles { get; set; }
        public static RegexOptions RegexCompiledOption { get; private set; }



        public SyntaxHighlighter(FastColoredTextBox fctb) {
			Fctb = fctb;
			PlatformType = FastColoredTextBoxNS.PlatformType.GetOperationSystemPlatform();

			ResilientStyles = new List<Style>(5);

			if (PlatformType == Platform.X86)
				RegexCompiledOption = RegexOptions.Compiled;
			else
				RegexCompiledOption = RegexOptions.None;
		}



        /// <summary>
        /// Highlights syntax for given language
        /// </summary>
        public virtual void HighlightSyntax(ILanguage language, Range range)
        {
            range.ClearStyle(language.GetStyles());

            foreach (var rule in language.Rules)
                range.SetStyle(rule.Style, rule.Regex);
            
            range.ClearFoldingMarkers();

            foreach (var marker in language.FoldingMarkers)
                range.SetFoldingMarkers(marker.StartMarker, marker.EndMarker, marker.RegexOption);
        }

        public virtual void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            var tb = (sender as FastColoredTextBox);
            
            tb.Language.AutoIndentNeeded(args);
        }

        /// <summary>
        /// Adds the given <paramref name="style"/> as resilient style. A resilient style is additionally available when highlighting is 
        /// based on a syntax descriptor that has been derived from a XML description file. In the run of the highlighting routine 
        /// the styles used by the FCTB are always dropped and replaced with the (initial) ones from the syntax descriptor. Resilient styles are 
        /// added afterwards and can be used anyway. 
        /// </summary>
        /// <param name="style">Style to add</param>
        public virtual void AddResilientStyle(Style style)
        {
            if (ResilientStyles.Contains(style)) return;
            Fctb.CheckStylesBufferSize(); // Prevent buffer overflow
            ResilientStyles.Add(style);
        }
	}
}