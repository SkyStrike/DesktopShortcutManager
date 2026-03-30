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
	/// Provides central access to application configuration settings, including directory paths and file locations.
	/// </summary>
	class AppConfig
	{
		/// <summary>
		/// Gets the directory path where the application's executable is located.
		/// </summary>
		public static string CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);

		/// <summary>
		/// Gets the path to the folder where extracted icons are stored.
		/// </summary>
		public static string IconFolder = CurrentDirectory + @"\Icons\";

		/// <summary>
		/// Gets the path to the folder where shortcut configuration files are stored.
		/// </summary>
		public static string ShortcutFolder = CurrentDirectory + @"\Shortcut\";

		/// <summary>
		/// Gets the path to the folder where general application configuration files are stored.
		/// </summary>
		public static string ConfigFolder = CurrentDirectory + @"\Config\";

		/// <summary>
		/// Gets the path to the base shortcut configuration file which contains group settings.
		/// </summary>
		public static string BaseShortcutFile = ConfigFolder + Properties.Settings.Default.ShortcutGroupSettings;

		/// <summary>
		/// Gets the path to the default icon mapping configuration file.
		/// </summary>
		public static string DefaultIconMappingFile = ConfigFolder + Properties.Settings.Default.DefaultIconMapping;

		/// <summary>
		/// Gets the path to the patcher utility configuration file.
		/// </summary>
		public static string PatcherConfig = ConfigFolder + Properties.Settings.Default.PatcherConfig;

		/// <summary>
		/// Gets the full path to the shortcut XML file for a specified shortcut group.
		/// </summary>
		/// <param name="strGroupName">The name of the shortcut group.</param>
		/// <returns>The full path to the group's shortcut configuration file.</returns>
		public static string GetShortcutFile(string strGroupName)
		{
			return Path.Combine(ShortcutFolder, strGroupName + ".xml");
		}

		/// <summary>
		/// Gets the full path for an icon file based on the provided filename.
		/// </summary>
		/// <param name="strFilename">The filename of the icon.</param>
		/// <returns>The full path to the icon file within the application's icon folder.</returns>
		public static string GetIconMapFile(string strFilename)
		{
			return Path.Combine(AppConfig.IconFolder, strFilename);
		}

		/// <summary>
		/// Gets a standard set of XML writer settings used for saving configuration files.
		/// </summary>
		/// <returns>An <see cref="XmlWriterSettings"/> object configured for indented XML output.</returns>
		public static XmlWriterSettings GetXmlWritterSettings()
		{
			return new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = ("\t"),
				OmitXmlDeclaration = true
			};
		}

		/// <summary>
		/// Gets a standard set of XML serializer namespaces to ensure clean XML output.
		/// </summary>
		/// <returns>An <see cref="XmlSerializerNamespaces"/> object configured with an empty namespace.</returns>
		public static XmlSerializerNamespaces GetXmlSerializerNamespaces() {
			return new XmlSerializerNamespaces(new[] {
					XmlQualifiedName.Empty
			});
		}
	}
}
