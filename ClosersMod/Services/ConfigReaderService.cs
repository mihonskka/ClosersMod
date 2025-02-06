using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClosersFramework.Services
{
	public static class ConfigReaderService
	{
		public static string ConfigXMLPath => Path.Combine(DomainPathService.ClosersModBasePath, "ClosersConfig.xml");
		public static XDocument Read() => XDocument.Load(ConfigXMLPath);

		public const string NodeName_MainPipeName = "MainPipeName";
		public const string NodeName_SubProgramList = "SubProgramList";
		public const string NodeName_ListItem = "ListItem";
		public const string NodeName_ClosersConfig = "ClosersConfig";
		public const string AttributeName_Name = "Name";
		public const string AttributeName_Path = "Path";
	}
}
