using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Entity
{
	[XmlRoot("Shortcuts")]
	public class ShortcutGroup
	{
		[XmlElement("Groups")]
		public List<ShortcutGroupItem> Items { get; set; }
	}

	public class ShortcutGroupItem
	{
		[XmlElement("Name")]
		public String Name { get; set; }
	}
}
