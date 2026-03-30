using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Entity
{
	/// <summary>
	/// Represents a root container for a list of shortcut items, primarily used for serialization within group files.
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class Shortcuts
	{
		/// <summary>
		/// Gets or sets the list of shortcut items.
		/// </summary>
		[XmlElement("Shortcuts")]
		public List<ShortcutItem> Items { get; set; }
	}

}
