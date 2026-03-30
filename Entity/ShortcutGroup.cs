using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Entity
{
	/// <summary>
	/// Represents a collection of shortcut groups, typically used for the top-level group configuration.
	/// </summary>
	[XmlRoot("Shortcuts")]
	public class ShortcutGroup
	{
		/// <summary>
		/// Gets or sets the list of shortcut groups.
		/// </summary>
		[XmlElement("Groups")]
		public List<ShortcutGroupItem> Items { get; set; }
	}

	/// <summary>
	/// Represents a single shortcut group, containing its name.
	/// </summary>
	public class ShortcutGroupItem
	{
		/// <summary>
		/// Gets or sets the name of the shortcut group.
		/// </summary>
		[XmlElement("Name")]
		public String Name { get; set; }
	}
}
