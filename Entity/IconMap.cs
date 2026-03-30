using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Entity
{
	/// <summary>
	/// Represents a collection of icon-to-extension mappings.
	/// </summary>
	[XmlRoot("Mappings")]
	public class IconMap
	{
		/// <summary>
		/// Gets or sets the list of icon mapping items.
		/// </summary>
		[XmlElement("map")]
		public List<IconMapItem> Items { get; set; }
	}

	/// <summary>
	/// Represents an individual mapping between a file extension and an icon file.
	/// </summary>
	public class IconMapItem {

		/// <summary>
		/// Gets or sets the file extension associated with the icon.
		/// </summary>
		[XmlAttribute("ext")]
		public string Ext { get; set; }

		/// <summary>
		/// Gets or sets the filename of the icon.
		/// </summary>
		[XmlAttribute("icon")]
		public string Icon { get; set; }
	}
}
