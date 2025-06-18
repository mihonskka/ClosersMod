//using Emgu.CV.CvEnum;
//using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChronoArkMod;
using UnityEngine;
//using Emgu.CV.Features2D;
//using Emgu.CV.Reg;
//using Emgu.CV.Structure;
using System.Drawing;
using ClosersFramework.Services;

namespace ClosersFramework.Services
{
	/*
	public class OpenCVService
	{
		string notice = "最初，我希望使用GDI制作这一功能。但是GDI是属于DirectX的，而现在的Unity游戏大多都是OpenGL的，潮州也不例外。故我改用我第二熟悉的OpenCVSharp。然而OpenCVSharp的Nuget包在安装时，必须安装对应系统的运行时包。而其作者并未制作用于Unity的运行时包，故OpenCVSharp也宣布失效。因此，最终我选择了EmguCV，和OpenCVSharp一样，是封装了OpenCV的Nuget包。";
		public Mat GetTransparentBackGround()
		{
			Mat TPImage = new Mat(1080, 1920, DepthType.Cv32S, 4);
			return TPImage;
		}
		public Mat TwoCharacter()
		{
			Mat BG = GetTransparentBackGround();
			var CharacterA = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, "").texture;
			var CharacterB = ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, "").texture;
			
			return GetTransparentBackGround();
		}
		public Mat ThreeCharacter()
		{
			return GetTransparentBackGround();
		}

		public void Texture2DToMat(Texture2D texture2D)
		{
			var s = DateTime.UtcNow.Ticks;
			if (texture2D != null)
			{
				// 获取Texture2D的像素数据
				Color32[] pixels = texture2D.GetPixels32();

				// 创建与Texture2D尺寸相同的Mat对象（4通道，即BGRA）
				var mat = new Mat(texture2D.height, texture2D.width, DepthType.Cv8U, 4);


				// 计算每行像素数据的字节大小
				int stride = texture2D.width * 4; // 因为是4通道，所以每个像素占4个字节

				// 遍历Texture2D的像素数据，并将其复制到Mat对象中
				for (int y = 0; y < texture2D.height; y++)
				{
					for (int x = 0; x < texture2D.width; x++)
					{
						int index = y * stride + x * 4;
						Color32 pixel = pixels[y * texture2D.width + x];

						Mat mask = new Mat(mat.Size, DepthType.Cv8U, 1);
						mask.SetTo(new MCvScalar(255)); // 将掩码初始化为全白（255），表示所有位置都有效

						// 注意：Emgu.CV的Mat对象通常使用BGR格式，而不是RGB格式
						// 因此，我们需要交换R和B的值
						var newColor = new MCvScalar(pixel.b, pixel.g, pixel.r, pixel.a);
						mat.SetTo(newColor, mask);
						//mat.SetTo()
						//matData[index] = pixel.b; // B
						//matData[index + 1] = pixel.g; // G
						//matData[index + 2] = pixel.r; // R
						//matData[index + 3] = pixel.a; // A
						mask.Dispose();
					}
				}
				CvInvoke.Imwrite("C:\\Users\\MiHonskka\\Desktop\\超时空方舟工作区域\\剧情&语音相关\\剧情立绘\\dst\\opt1.png", mat);
				mat.Dispose();
			}
			var e = DateTime.UtcNow.Ticks;
			clog.iw("本次TTM用时: " + (e - s) + "ticks");
		}


		public void sample()
		{
			// 加载背景图片和源图片
			Mat background = CvInvoke.Imread("background.png", ImreadModes.Color);
			Mat source = CvInvoke.Imread("source.png", ImreadModes.Unchanged); // 使用Unchanged保留Alpha通道

			if (background.IsEmpty || source.IsEmpty)
			{
				Console.WriteLine("无法加载图片");
				return;
			}
			CvInvoke.AddWeighted(background, 1.0, source, 1.0, 0.0, background);

			// 释放资源
			background.Dispose();
			source.Dispose();
		}
	}*/
}
