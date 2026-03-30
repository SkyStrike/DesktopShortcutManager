using DesktopShortcutMgr.Entity;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DesktopShortcutMgr.Modules
{
	/// <summary>
	/// IconMapperUtil
	/// Mainly a class for any CRUD operations to the IconMap configuration file
	/// </summary>
	class IconMapperUtil
	{

		public static List<IconMapItem> GetMappedIcons() {

			string cfgFile = AppConfig.DefaultIconMappingFile;

			List<IconMapItem> iconMapItems = new List<IconMapItem>();
			if (System.IO.File.Exists(cfgFile))
			{
				using (FileStream fileStream = new FileStream(cfgFile, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(IconMap));
					IconMap result = (IconMap)serializer.Deserialize(fileStream);

					if (result != null && result.Items != null)
					{
						foreach (IconMapItem item in result.Items)
						{
							iconMapItems.Add(item);
						}
					}
					else
					{
						System.IO.File.Delete(cfgFile);
					}
				}
			}
			return iconMapItems;
		}

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

		public static void UpdateIconMapping(IconMap iconMap)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(IconMap));
			using (XmlWriter writer = XmlWriter.Create(AppConfig.DefaultIconMappingFile, AppConfig.GetXmlWritterSettings()))
			{
				writer.WriteWhitespace("");
				serializer.Serialize(writer, iconMap, AppConfig.GetXmlSerializerNamespaces());
				writer.Close();
			}
		}

		public static void UpdateIconMapping(DataTable dt)
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
			XmlNode list = doc.SelectSingleNode(string.Format("//map[@ext='{0}']", fileExtension));
			if (list != null)
			{
				strIconFile = list.Attributes.GetNamedItem("icon").Value;
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
	}
}
