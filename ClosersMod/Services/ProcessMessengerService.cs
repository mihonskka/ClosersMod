using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Runtime.Serialization.Json;
using ClosersFramework.Service;
using ClosersFramework.Service.CodeManager;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ClosersFramework.Services
{
	public class ProcessMessengerService
	{
		[NoReference]
		public string GetProcessHubName() => ConfigReaderService.Read().Element(ConfigReaderService.NodeName_MainPipeName).Value;
		/// <summary>
		/// 查根节点下的SubProgramList节点，再获取其全部的ListItem节点，选择其Name和Path属性并整理为列表输出。
		/// </summary>
		/// <returns></returns>
		[NoReference]
		public List<SubProgramRegistration> GetSubProgramList() => ConfigReaderService.Read().Element(ConfigReaderService.NodeName_SubProgramList).Elements(ConfigReaderService.NodeName_ListItem).Select(t => new SubProgramRegistration() { 
				Name = t.Attribute(ConfigReaderService.AttributeName_Name).Value,
				Path = t.Attribute(ConfigReaderService.AttributeName_Path).Value
			}).ToList();


		public static string ArtistExePath => Path.Combine(DomainPathService.ClosersModBasePath, "Debug", "net8.0", "ClosersArtist.exe");

		public static List<(ArtistMessage Message, string Path)> SentMessages { get; set; } = new List<(ArtistMessage Message, string Path)>();



		public static List<(string Path,string Name)> OriginPicCache { get; set; } = new List<(string Path, string Key)>();
		public static void CleanCache()
		{
			clog.w("OpenCV缓存区清理中");
				foreach (var i in OriginPicCache)
				{
					try
					{
						File.Delete(Path.Combine(DomainPathService.AssetTempFolderPath, i.Name));
					}
					catch
					{
					}
				}

		}

		public static void SyncCacheXML(List<(ArtistMessage Message, string Path)> model)
		{
			if (!File.Exists(DomainPathService.TempXMLPath))
			{
				File.Create(DomainPathService.TempXMLPath).Dispose();
			}

			using (var sw = new StringWriter())
			{
				var xz = new XmlSerializer(model.GetType());
				xz.Serialize(sw, model);
				var data = sw.ToString();
				File.WriteAllText(DomainPathService.TempXMLPath, data);
				sw.Close();
			}
		}
		public static void SyncCacheXML()
		{
			SyncCacheXML(SentMessages);
		}

		public static List<(ArtistMessage Message, string Path)> LoadCacheXML()
		{
			var rv = new List<(ArtistMessage Message, string Path)>();
			if (!File.Exists(DomainPathService.TempXMLPath))
			{
				File.Create(DomainPathService.TempXMLPath).Dispose();
			}
			try
			{
				var fs = File.Open(DomainPathService.TempXMLPath, FileMode.Open);
				using (var sr = new StreamReader(fs, Encoding.UTF8))
				{
					var xz = new XmlSerializer(typeof(List<(ArtistMessage Message, string Path)>));
					var dept = (List<(ArtistMessage Message, string Path)>)xz.Deserialize(sr);
					rv = dept ?? new List<(ArtistMessage Message, string Path)>();
				}
				fs.Close();
			}
			catch
			{
				clog.w("缓存登记表不完整，放弃读取。");
			}
			return rv;
		}

		public static void LoadCacheXMLToStatic()
		{
			SentMessages = LoadCacheXML();
		}

		public static void CheckStatic()
		{
			var update = new List<(ArtistMessage Message, string Path)>();
			foreach (var i in SentMessages)
			{
				var FullPath = Path.Combine(DomainPathService.AssetBaseFolderPath, i.Path);
				if (i.Message != null && !string.IsNullOrWhiteSpace(i.Path) && File.Exists(FullPath) && new FileInfo(FullPath).Length > 2048)
				{
					update.Add(i);
				}
				else
				{
					continue;
				}
			}
			SentMessages = update;
		}



		static string SetOne(string AssetPath)
		{
			string p0Name = string.Empty;
			var CacheItem = OriginPicCache.FirstOrDefault(t => t.Path == AssetPath);
			if (string.IsNullOrWhiteSpace(CacheItem.Name) || string.IsNullOrWhiteSpace(CacheItem.Path))
			{
				//clog.iw("c0Item是空的");
				p0Name = SnowService.instance.nextId() + ".png";
				ImageService.GetTextureFromAsset(AssetPath).SaveAsPNG(Path.Combine(DomainPathService.AssetTempFolderPath, p0Name));
				OriginPicCache.Add((AssetPath, p0Name));
			}
			else
			{
				p0Name = CacheItem.Name;
			}
			return p0Name;
		}

		/// <summary>
		/// 返回图像路径
		/// </summary>
		/// <returns></returns>
		public static string ContactWithArtist(ArtistMessage model)
		{
			var ExistMsg = SentMessages.FirstOrDefault(t => t.Message.CharacterAssetPath0 == model.CharacterAssetPath0 && t.Message.CharacterAssetPath1 == model.CharacterAssetPath1 && t.Message.CharacterAssetPath2 == model.CharacterAssetPath2 && t.Message.BrightCharacter0 == model.BrightCharacter0 && t.Message.BrightCharacter1 == model.BrightCharacter1 && t.Message.BrightCharacter2 == model.BrightCharacter2);
			if (ExistMsg.Path!=null)
			{
				return ExistMsg.Path;
			}

			string argument = string.Empty;
			argument += " "+SetOne(model.CharacterAssetPath0);

			if (model.CharacterNum > 1)
			{
				argument += " " + SetOne(model.CharacterAssetPath1);
			}
			else argument += " 0";
			if (model.CharacterNum > 2)
			{
				argument += " " + SetOne(model.CharacterAssetPath2);
			}
			else argument += " 0";

			if (model.BrightCharacter0) argument += " 1"; else argument += " 0";
			if (model.BrightCharacter1) argument += " 1"; else argument += " 0";
			if (model.BrightCharacter2) argument += " 1"; else argument += " 0";

			ProcessStartInfo startInfo = new ProcessStartInfo()
			{
				FileName = ArtistExePath,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
				Arguments = argument
			};

			using (Process process = new Process())
			{
				process.StartInfo = startInfo;
				StringBuilder output = new StringBuilder();

				// 异步读取标准输出流
				process.OutputDataReceived += (sender, e) =>
				{
					if (!string.IsNullOrEmpty(e.Data))
					{
						output.AppendLine(e.Data);
					}
				};



				process.Start();
				process.BeginOutputReadLine();
				process.WaitForExit();

				// 获取完整的路径字符串
				string PathString = output.ToString().Trim();

				//var texture = ImageService.FileToTexture(PathString);

				SentMessages.Add((model, PathString));

				//clog.iw($"PMS.CA: {PathString}");
				return PathString;
			}
		}
	}
}
