using System.Drawing;

namespace NickAc.IDE_Shell.Themes
{
    public class DarkThemeImpl : ThemeBase
    {
        public override Color MainWindowColor => Color.FromArgb(45, 45, 48);
        public override Color MainWindowSecondaryColor => Color.FromArgb(0, 122, 204);

        public override Color EditorBackColor => Color.FromArgb(30, 30, 30);
        public override Color EditorCaretColor => Color.White;
        public override Color EditorForeColor => Color.White;

        public override Color EditorSelectionColor => Color.FromArgb(102, 50, 153, 255);
        public override Color HighlightKeywordsStyleColor => Color.FromArgb(70, 155, 210);
        public override Color HighlightStringStyleColor => Color.FromArgb(214, 157, 133);
    }
}