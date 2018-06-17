using System.Windows.Forms;

namespace NickAc.IDE_Shell.Menu
{
	public interface IBuildableMenuItemHolder : IMenuItemHolder
	{
	    ToolStripItem BuildMenu(MenuStrip strip);
	    ToolStripItem BuildMenu();
	}
}
