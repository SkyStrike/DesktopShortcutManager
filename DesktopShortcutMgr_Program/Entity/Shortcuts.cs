using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Entity
{
	[XmlRoot("NewDataSet")]
	public class Shortcuts
	{
		[XmlElement("Shortcuts")]
		public List<ShortcutItem> Items { get; set; }
	}

}
