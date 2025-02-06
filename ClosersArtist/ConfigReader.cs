using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClosersArtist
{
	public static class ConfigReader
	{
		public static string GetProcessHubName() => XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClosersConfig.xml")).Element("MainPipeName")?.Value ?? "ClosersPipeHub";
	}
}
