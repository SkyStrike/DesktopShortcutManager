using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using IWshRuntimeLibrary;
using System.Drawing;

namespace DesktopShortcutMgr.Modules
{
	/// <summary>
	/// Class for storing application configurations like the directory for icons, shortcuts, config files
	/// </summary>
	class AppConfig
	{
		public static string CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);
		public static string IconFolder = CurrentDirectory + @"\Icons\";
		public static string ShortcutFolder = CurrentDirectory + @"\Shortcut\";
		public static string ConfigFolder = CurrentDirectory + @"\Config\";
		public static string BaseShortcutFile = ConfigFolder + Properties.Settings.Default.ShortcutGroupSettings;
		public static string DefaultIconMappingFile = ConfigFolder + Properties.Settings.Default.DefaultIconMapping;
		public static string PatcherConfig = ConfigFolder + Properties.Settings.Default.PatcherConfig;

		//Gets the shortcut file for the shortcut group
		public static string GetShortcutFile(string strGroupName)
		{
			return Path.Combine(ShortcutFolder, strGroupName + ".xml");
		}

		//Get the icon for the selected file
		public static string GetIconMapFile(string strFilename)
		{
			return Path.Combine(AppConfig.IconFolder, strFilename);
		}


		public static XmlWriterSettings GetXmlWritterSettings()
		{
			return new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = ("\t"),
				OmitXmlDeclaration = true
			};
		}

		public static XmlSerializerNamespaces GetXmlSerializerNamespaces() {
			return new XmlSerializerNamespaces(new[] {
					XmlQualifiedName.Empty
			});
		}
	}
}
