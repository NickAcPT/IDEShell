using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using FastColoredTextBoxNS.Events;
using FastColoredTextBoxNS.StaticResources;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
	public abstract class Syntax : ILanguage
	{
		public string Name { get; protected set; }
		public string Extension { get; protected set; }
		public List<Rule> Rules { get; protected set; }
		public string CommentPrefix { get; protected set; }

		public char LeftBracket { get; set; }
		public char RightBracket { get; set; }
		public char LeftBracket2 { get; set; }
		public char RightBracket2 { get; set; }

		public string AutoIndentCharsPatterns { get; protected set; }
		public List<Marker> FoldingMarkers { get; protected set; }
		public BracketsHighlightStrategy BracketsHighlightStrategy { get; protected set; }

		private List<string> _Keywords;
		protected List<string> Keywords
		{
			get { return _Keywords; }
			set
			{
				_Keywords = value;

				KeyWordsRegex = GenerateExactMatch(value);

				if (value.Count == 0) return;

				Rules.Add(new Rule(KeyWordsRegex, KeywordStyle()));
			}
		}
		protected Regex KeyWordsRegex { get; set; }

		private List<string> _functions;
		protected List<string> FunctionNames
		{
			get { return _functions; }
			set
			{
				_functions = value;

				FunctionsRegex = GenerateExactMatch(value);

				if (value.Count == 0) return;

				Rules.Add(new Rule(FunctionsRegex, FunctionStyle()));
			}
		}
		protected Regex FunctionsRegex { get; set; }



		public Syntax(string syntaxName, string extensionName)
		{
			Name      = syntaxName;
			Extension = extensionName;

			Rules = new List<Rule>()
			{
				new Rule(StringRegex(), StringStyle()),
				new Rule(NumberRegex(), NumberStyle()),
			};

			CommentPrefix = "\x0";

			LeftBracket   = Bracket.Disabled;
			RightBracket  = Bracket.Disabled;
			LeftBracket2  = Bracket.Disabled;
			RightBracket2 = Bracket.Disabled;

			AutoIndentCharsPatterns = "";

			FoldingMarkers = new List<Marker>();

			BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

			Keywords      = new List<string>();
			FunctionNames = new List<string>();
		}



		/// <summary>
		/// This regex only match with the exact words means there can't be alphabetical
		/// char(s) at the beginning or at the end of the given words
		/// </summary>
		/// <param name="words"></param>
		/// <returns></returns>
		protected Regex GenerateExactMatch(List<string> words)
		{
			if (words.Count == 0)
				return new Regex("");
			var regexString = "";

			foreach (var word in words)
				regexString += string.Format("{0}|", word);

			// remove the last | symbol
			regexString = regexString.Substring(0, regexString.Length - 1);

			return new Regex($@"(?!{StringRegex()})\b({regexString})\b(?<!{StringRegex()})", SyntaxHighlighter.RegexCompiledOption);
		}

		protected virtual Style KeywordStyle()
		{
			return Styles.BlueBoldStyle;
		}

		protected virtual Style FunctionStyle()
		{
			return Styles.MaroonStyle;
		}

		public virtual Regex StringRegex()
		{
			return new Regex("'(.*?)'|\"(.*?)\"", SyntaxHighlighter.RegexCompiledOption);
		}

		public virtual Style StringStyle()
		{
			return Styles.BrownStyle;
		}
		public virtual Regex NumberRegex()
		{
			return new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", SyntaxHighlighter.RegexCompiledOption);
		}

		public virtual Style NumberStyle()
		{
			return Styles.MagentaStyle;
		}

		public Style[] GetStyles()
		{
			var styles = new Style[Rules.Count];

			for (int i = 0; i < styles.Length; i++)
				styles[i] = Rules[i].Style;

			return styles;
		}

		public virtual void AutoIndentNeeded(AutoIndentEventArgs args)
		{

		}
	}
}
