using System;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
	public class HtmlSyntax : Syntax
	{
		public HtmlSyntax()
			: base("HTML", "html")
		{
			CommentPrefix = "//";
		}
	}
}
