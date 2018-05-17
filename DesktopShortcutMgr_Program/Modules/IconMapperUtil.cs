using System.Data;
using System.Drawing;
using System.Xml;

namespace DesktopShortcutMgr.Modules
{
	class IconMapperUtil
	{
		public static DataTable GetIconMapDataTable() {
			DataSet ds = new DataSet();
			ds.ReadXml(AppConfig.DefaultIconMappingFile);

			DataTable dt = ds.Tables[0];
			foreach (DataColumn dc in dt.Columns)
			{
				dc.ColumnMapping = MappingType.Attribute;
			}
			return ds.Tables[0];
		}

		public static void UpdateIconMap(DataTable dt)
		{
			dt.WriteXml(AppConfig.DefaultIconMappingFile);
		}

		//Loads from the XML file for default mappings
		public static Icon GetDefaultIcon(string fileExtension)
		{
			//Load the XML Icon Mapping File
			XmlDocument doc = new XmlDocument();
			doc.Load(AppConfig.DefaultIconMappingFile);

			string strIconFile = string.Empty;
			XmlNode list = doc.SelectSingleNode(string.Format("//Map[@Ext='{0}']", fileExtension));
			if (list != null)
			{
				strIconFile = list.Attributes.GetNamedItem("Icon").Value;
			}

			Icon icn = null;

			string strIconPath = string.Empty;
			if (string.IsNullOrEmpty(strIconFile))
			{
				icn = Properties.Resources.unknown;
			}
			else
			{
				strIconPath = AppConfig.GetIconMapFile(strIconFile);
				if (System.IO.File.Exists(strIconPath))
				{
					icn = new Icon(strIconPath);
				}
				else
				{
					icn = Properties.Resources.unknown;
				}
			}

			doc = null;

			return icn;
		}

		public static void SaveOrdering() {

		}
	}
}
