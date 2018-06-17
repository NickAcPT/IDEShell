using System.Windows.Forms;

namespace NickAc.IDE_Shell.Menu
{
	public interface IMenuItemHolder
	{
		IBuildableMenuItemHolder AddItem(ToolStripItem item);
		IBuildableMenuItemHolder AddItem(string itemText, out ToolStripItem item);
		IBuildableMenuItemHolder AddItem(string[] items, out ToolStripItem[] item);

	    IBuildableMenuItemHolder AddItem(string itemText);
	    IBuildableMenuItemHolder AddItem(string[] items);

	}
}
