namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class VS2015DarkTheme : VS2015ThemeBase
    {
        public VS2015DarkTheme()
            : base(Decompress(Resources.vs2015dark_vstheme))
        {
            Measures.DockPadding = 7;
            if (ToolStripRenderer is VisualStudioToolStripRenderer renderer)
            {
                renderer.IsDarkTheme = true;
            }
        }
    }
}
