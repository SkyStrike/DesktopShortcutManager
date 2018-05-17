using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Entity
{
	[XmlRoot("Mappings")]
	public class IconMap
	{
		[XmlElement("Map")]
		public List<IconMapItem> Items { get; set; }
	}

	public class IconMapItem {

		[XmlAttribute("Ext")]
		public string Ext { get; set; }

		[XmlAttribute("Icon")]
		public string Icon { get; set; }
	}
}
