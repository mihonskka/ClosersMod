using ChronoArkMod;
using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework
{
	public class Startup
	{
		public void Configure()
		{
			clog.iw($"CloDll: {ModManager.getModInfo(InfoKeyWords.Closers).DirectoryName}");
			if (!Directory.Exists(DomainPathService.AssetTempFolderPath))
			{
				Directory.CreateDirectory(DomainPathService.AssetTempFolderPath);
				clog.w("已创建临时文件夹");
			}
			else
			{
				//try
				//{
				//	// 获取文件夹下所有 .png 文件
				//	string[] pngFiles = Directory.GetFiles(DomainPathService.AssetTempFolderPath, "*.png");

				//	clog.iw("发现临时文件夹，正在清空");
				//	// 遍历并删除每个 .png 文件
				//	foreach (string file in pngFiles)
				//	{
				//		File.Delete(file);
				//	}
				//	clog.iw("临时文件夹已被清空");
				//}
				//catch (Exception ex)
				//{
				//	clog.iw($"清空临时文件夹时出错：{ex.Message}");
				//}

				ProcessMessengerService.LoadCacheXMLToStatic();
				ProcessMessengerService.CheckStatic();
			}
		}
	}
}
