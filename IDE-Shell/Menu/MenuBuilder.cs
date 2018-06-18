using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NickAc.IDE_Shell;
using System.Windows.Forms;

namespace NickAc.IDE_Shell.Menu
{
	public class MenuBuilder : IBuildableMenuItemHolder
	{
	    private const int SubItemPadding = 10;

	    //Static menu finder
	    private static Dictionary<Guid, List<ToolStripItem>> _items = new Dictionary<Guid, List<ToolStripItem>>();

	    public MenuBuilder(ShellForm owner, ToolStripItem parentItem)
	    {
	        Owner = owner;
	        ParentItem = parentItem;
	    }

	    private static MenuBuilder GetMenuFor(ShellForm owner, string name = "")
	    {
	        if (!_items.ContainsKey(owner.UniqueId))
                _items.Add(owner.UniqueId, new List<ToolStripItem>());

            owner.FormClosed -= ShellMenuOwner_FormClosed;
            owner.FormClosed += ShellMenuOwner_FormClosed;

	        if (name == string.Empty) return null;

	        var first = _items[owner.UniqueId].FirstOrDefault(c => c.Text == name);
	        
	        return new MenuBuilder(owner, first ?? GetItemForString(name));
	    }

	    private static void ShellMenuOwner_FormClosed(object sender, EventArgs e)
	    {
	        if (sender is ShellForm frm)
	            _items.Remove(frm.UniqueId);
	    }

	    private ShellForm Owner { get; }

	    private ToolStripItem ParentItem { get; }

	    private List<ToolStripItem> _toAddItems = new List<ToolStripItem>();

		// Instantiating functions

		public static IMenuItemHolder GetMenu(string name, ShellForm owner)
		{
			return GetMenuFor(owner, name);
		}

		// Chaining functions

		public IBuildableMenuItemHolder AddItem(ToolStripItem item)
		{
            if (item.GetCurrentParent() == null)
		        _toAddItems.Add(item);
            _items[Owner.UniqueId].Add(item);
			return this;
		}

		public IBuildableMenuItemHolder AddItem(string itemText, out ToolStripItem item)
		{
		    var menuItem = GetItemForString(itemText);
		    item = menuItem;
		    return AddItem(item = menuItem);
		}

		public IBuildableMenuItemHolder AddItem(string[] items, out ToolStripItem[] item)
		{
		    var toReturn = new List<ToolStripItem>();
		    IBuildableMenuItemHolder lastItem = this;
		    foreach (var i in items)
		    {
		        var stripItem = GetItemForString(i);
                toReturn.Add(stripItem);
		        lastItem = AddItem(stripItem);
		    }

		    item = toReturn.ToArray();
		    return lastItem;
		}

	    public IBuildableMenuItemHolder AddItem(string itemText)
	    {
	        return AddItem(itemText, out _);
	    }

	    public IBuildableMenuItemHolder AddItem(string[] items)
	    {
	        return AddItem(items, out _);
	    }

	    private static ToolStripItem GetItemForString(string i)
	    {
            if (i == "-")
                return new ToolStripSeparator();
	        var menuItem = new ToolStripMenuItem(i);
            
	        return menuItem;
	    }

	    // Executing functions


	    public ToolStripItem BuildMenu()
	    {
	        return BuildMenu(Owner?.MainMenuStrip);
	    }

	    public ToolStripItem BuildMenu(MenuStrip strip)
		{
		    if (ParentItem == null) return null;

            if (ParentItem is ToolStripDropDownItem dropD)
                dropD.DropDownItems.AddRange(_toAddItems.ToArray());
		    if (!strip.Items.Contains(ParentItem) && ParentItem.GetCurrentParent() == null)
		        strip.Items.Add(ParentItem);
		    return ParentItem;
		}
	}
}
