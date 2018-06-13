using System.Drawing;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;

namespace NickAc.IDE_Shell.Themes
{
    public abstract class ThemeBase
    {
        public abstract Color MainWindowColor { get; }
        public abstract Color MainWindowSecondaryColor { get; }

        public abstract Color EditorBackColor { get; }
        public abstract Color EditorCaretColor { get; }
        public abstract Color EditorSelectionColor { get; }
        public abstract Color EditorForeColor { get; }

        public abstract Color HighlightKeywordsStyleColor { get; }
        public abstract Color HighlightStringStyleColor { get; }

        public void ApplyToFctb(FastColoredTextBoxNS.FastColoredTextBox box)
        {
            box.BackColor = EditorBackColor;
            box.IndentBackColor = EditorBackColor;
            box.CaretColor = EditorCaretColor;
            box.ServiceLinesColor = Color.Transparent;
            box.SelectionColor = EditorSelectionColor;
            box.ForeColor = EditorForeColor;
        }


        public void ApplyToModernForm(ModernForm frm)
        {
            frm.ColorScheme = new ColorScheme(MainWindowColor, MainWindowSecondaryColor);
        }
    }
}