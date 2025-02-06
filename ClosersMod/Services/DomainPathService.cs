using ChronoArkMod;
using ChronoArkMod.ModData;
using ClosersFramework.KeyWords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChronoArkMod.ModData.ModAssetInfo;

namespace ClosersFramework.Services
{
	public static class DomainPathService
	{
		//public static string AssemblyFolderPath => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		public static string AssetBaseFolderPath => Path.Combine(ClosersModBasePath, "Assets");
		public static string AssemblyFolderPath => Path.Combine(ClosersModBasePath, "Assemblies");
		public static string ClosersModBasePath => ModManager.getModInfo(InfoKeyWords.Closers).DirectoryName.Replace("/","\\");
		public static string UnityAssetFilePath => Path.Combine(AssetBaseFolderPath, InfoKeyWords.AssetName);
		public static string AssetTempFolderPath => Path.Combine(AssetBaseFolderPath, "Temp");
		public static string TempFolderPath => Path.Combine(ClosersModBasePath, "Temp");
		public static string TempXMLPath => Path.Combine(AssetTempFolderPath, "CacheList.xml");
	}
}
