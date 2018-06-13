using System.Collections.Generic;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.Events;
using FastColoredTextBoxNS.StaticResources;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class LuaSyntax : Syntax
    {
        public LuaSyntax()
			: base("Lua", "lua")
        {
			Keywords      = new List<string>()
			{
				"and",
				"break",
				"do",
				"else",
				"elseif",
				"end",
				"false",
				"for",
				"function",
				"if",
				"in",
				"local",
				"nil",
				"not",
				"or",
				"repeat",
				"return",
				"then",
				"true",
				"until",
				"while",
			};
			FunctionNames = new List<string>()
			{
				"assert",
				"collectgarbage",
				"dofile",
				"error",
				"getfenv",
				"getmetatable",
				"ipairs",
				"load",
				"loadfile",
				"loadstring",
				"module",
				"next",
				"pairs",
				"pcall",
				"print",
				"rawequal",
				"rawget",
				"rawlen",
				"rawset",
				"require",
				"select",
				"setfenv",
				"setmetatable",
				"tonumber",
				"tostring",
				"type",
				"unpack",
				"xpcal",
			};

			Rules.Add(new Rule(NumberRegex(), NumberStyle()));

			Rules.Add(new Rule(CommentRegex(),  CommentStyle()));
			Rules.Add(new Rule(CommentRegex2(), CommentStyle()));
			Rules.Add(new Rule(CommentRegex3(), CommentStyle()));

			CommentPrefix = "--";
            LeftBracket = '(';
            RightBracket = ')';
            LeftBracket2 = '{';
            RightBracket2 = '}';

            FoldingMarkers = new List<Marker>()
            {
                new Marker(      "{",     "}"),  // allow to collapse brackets block
                new Marker(@"--\[\[", @"\]\]"),  // allow to collapse comment block
            };
        }
		
		
		
        public Regex CommentRegex()
        {
            return new Regex(@"--.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
        }

        public Regex CommentRegex2()
        {
            return new Regex(@"(--\[\[.*?\]\])|(--\[\[.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
        }

        public Regex CommentRegex3()
        {
            return new Regex(@"(--\[\[.*?\]\])|(.*\]\])", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
        }

        public Style CommentStyle()
        {
            return Styles.GreenStyle;
        }

        public override void AutoIndentNeeded(AutoIndentEventArgs args)
        {
            //end of block
            if (Regex.IsMatch(args.LineText, @"^\s*(end|until)\b"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            // then ...
            if (Regex.IsMatch(args.LineText, @"\b(then)\s*\S+"))
                return;
            //start of operator block
            if (Regex.IsMatch(args.LineText, @"^\s*(function|do|for|while|repeat|if)\b"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }

            //Statements else, elseif, case etc
            if (Regex.IsMatch(args.LineText, @"^\s*(else|elseif)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                return;
            }
        }
    }
}
