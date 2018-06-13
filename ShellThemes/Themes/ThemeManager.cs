namespace NickAc.IDE_Shell.Themes
{
    public static class ThemeManager
    {
        public static ThemeBase CurrentTheme { get; set; } = new DarkThemeImpl();
    }
}
