using System.Collections.Generic;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS.Events;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class CSharpSyntax : Syntax
    {
        public CSharpSyntax()
			: base("C#", "cs")
        {
			Keywords = new List<string>()
			{
				"abstract",
				"as",
				"base",
				"bool",
				"break",
				"byte",
				"case",
				"catch",
				"char",
				"checked",
				"class",
				"const",
				"continue",
				"decimal",
				"default",
				"delegate",
				"do",
				"double",
				"else",
				"enum",
				"event",
				"explicit",
				"extern",
				"false",
				"finally",
				"fixed",
				"float",
				"for",
				"foreach",
				"goto",
				"if",
				"implicit",
				"in",
				"int",
				"interface",
				"internal",
				"is",
				"lock",
				"long",
				"namespace",
				"new",
				"null",
				"object",
				"operator",
				"out",
				"override",
				"params",
				"private",
				"protected",
				"public",
				"readonly",
				"ref",
				"return",
				"sbyte",
				"sealed",
				"short",
				"sizeof",
				"stackalloc",
				"static",
				"string",
				"struct",
				"switch",
				"this",
				"throw",
				"true",
				"try",
				"typeof",
				"uint",
				"ulong",
				"unchecked",
				"unsafe",
				"ushort",
				"using",
				"virtual",
				"void",
				"volatile",
				"while",
				"add",
				"alias",
				"ascending",
				"descending",
				"dynamic",
				"from",
				"get",
				"global",
				"group",
				"into",
				"join",
				"let",
				"orderby",
				"partial",
				"remove",
				"select",
				"set",
				"value",
				"var",
				"where",
				"yield",
			};
			FunctionNames = new List<string>()
			{
				"Equals",
				"GetHashCode",
				"GetType",
				"ToString",
			};

			CommentPrefix = "//";
            LeftBracket = '(';
            RightBracket = ')';
            LeftBracket2 = '{';
            RightBracket2 = '}';
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
