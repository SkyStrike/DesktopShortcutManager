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
		[XmlElement("map")]
		public List<IconMapItem> Items { get; set; }
	}

	public class IconMapItem {

		[XmlAttribute("ext")]
		public string Ext { get; set; }

		[XmlAttribute("icon")]
		public string Icon { get; set; }
	}
}
