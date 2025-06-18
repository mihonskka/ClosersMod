using ChronoArkMod;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using ClosersFramework.Service.CodeManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Services
{
	public static partial class ImageService
	{
		public static Texture2D Base64ToTexture(this string base64String)
		{
			try
			{
				byte[] imageBytes = Convert.FromBase64String(base64String);
#pragma warning disable CS0219 // 变量已被赋值，但从未使用过它的值
				string tips = "这里的像素和格式定义无意义，因为LoadImage会覆盖掉这些信息";
#pragma warning restore CS0219 // 变量已被赋值，但从未使用过它的值
				Texture2D pic = new Texture2D(1920, 1080, TextureFormat.RGBA32, false);
				pic.LoadImage(imageBytes);
				pic.Apply();
				return pic;
			}
			catch (Exception ex)
			{
				clog.w("ImageService.Base64ToTexture出错，请排查以下三项：1.是否被用于非base64编码的字符串。2.程序会否能正常创建Texture2D对象。3.程序是否能正确执行Texture2D.LoadImage方法，该方法被定义于UnityEngine.ImageConversionModule。");
				return null;
			}
		}
		public static string TextureToBase64(this Texture2D texture2D)
		{
			try
			{
				byte[] imageData = texture2D.EncodeToPNG();
				string baser64 = Convert.ToBase64String(imageData);
				return baser64;
			}
			catch (Exception ex)
			{
				clog.w("ImageService.TextureToBase64出错，请排查以下两项：1.程序会否能正常创建Texture2D对象。2.程序是否能正确执行Texture2D.EncodeToPNG方法，该方法被定义于UnityEngine.ImageConversionModule.dll。");
				return null;
			}
		}
		public static byte[] TextureToByte(this Texture2D texture2D)
		{
			try
			{
				return texture2D.EncodeToPNG();
			}
			catch (Exception ex)
			{
				clog.w("ImageService.TextureToByte出错，请排查以下两项：1.程序会否能正常创建Texture2D对象。2.程序是否能正确执行Texture2D.EncodeToPNG方法，该方法被定义于UnityEngine.ImageConversionModule.dll。");
				return null;
			}
		}

		public static Texture2D GetTextureFromAsset(string assetPath)
		{
			try
			{
				return GetReadableTexture(ModManager.getModInfo(InfoKeyWords.Closers).assetInfo.LoadFromAsset<Sprite>(InfoKeyWords.AssetName, assetPath));
			}
			catch
			{
				clog.w($"ImageService.GetTextureFromAsset: 从Asset中读取Texture的过程出错，assetPath为{assetPath}，请检查Asset路径是否正确。");
				return null;
			}
		}

		public static bool SaveAsPNG(this Texture2D texture, string path)
		{
			try
			{
				var data = texture.EncodeToPNG();
				File.WriteAllBytes(path, data);
				clog.w($"ImageService.SaveAsPNG：材质被成功保存至 {path}；datalength: {data.Length}");
				return true;
			}
			catch (System.UnauthorizedAccessException ex)
			{
				clog.w("ImageService.SaveAsPNG：由于没有目标文件夹的访问权限，故无法保存材质。 " + ex.Message);
				return false;
			}
			catch (System.IO.IOException ex)
			{
				clog.w("ImageService.SaveAsPNG：由于系统IO出错，故无法保存材质。" + ex.Message);
				return false;
			}
			catch (System.Exception ex)
			{
				clog.w("ImageService.SaveAsPNG：无法保存材质。" + ex.Message);
				return false;
			}
		}
		[NoReference]
		public static Texture2D FileToTexture(string filePath)
		{
			// 确保路径是有效的
			if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
			{
				// 读取文件的字节数据
				byte[] fileData = File.ReadAllBytes(filePath);

				// 创建一个Texture2D对象，宽度和高度设置为图片的原始大小（这里需要你知道或预先定义）
				// 注意：对于未知大小的图片，你可能需要先使用其他方法来确定其尺寸（比如使用外部库解析图片头）
				// 这里假设图片是256x256的PNG文件
				int width = 256;
				int height = 256;
				Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);

				// 如果图片不是正方形，你需要根据实际情况设置width和height
				// texture = new Texture2D(actualWidth, actualHeight, TextureFormat.RGBA32, false);

				// 加载图像数据到Texture2D对象中
				// 注意：这里假设图片是PNG格式，且没有alpha通道透明度问题（如果有，可能需要额外处理）
				bool success = texture.LoadImage(fileData);

				// 检查是否成功加载
				if (success)
				{
					// 应用纹理（比如将其设置为某个Material的mainTexture）
					// Renderer renderer = GetComponent<Renderer>();
					// renderer.material.mainTexture = texture;

					// 或者简单地将其赋给一个Texture2D变量以供后续使用
					// this.someTexture2DVariable = texture;

					// 在这里，我们只是为了演示而打印出纹理的宽度和高度
					clog.w("ImageService.FileToTexture：材质导入成功！");
					return texture;
				}
				else
				{
					clog.w("ImageService.FileToTexture：导入失败！");
					return null;
				}

				// 注意：对于JPG和其他非PNG格式的图片，你可能需要额外的处理来正确加载它们
				// 因为JPG图片可能包含颜色空间信息（如YCbCr），这需要在加载时进行转换
				// Unity的Texture2D.LoadImage方法通常能够处理这些转换，但你可能需要确保你的JPG图片没有损坏或格式问题
			}
			else
			{
				clog.w($"ImageService.FileToTexture：对应路径的图片不存在：{filePath}");
				return null;
			}
		}

		public static Texture2D GetReadableTexture(Texture2D source)
		{
			RenderTexture renderTex = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);

			Graphics.Blit(source, renderTex);
			RenderTexture previous = RenderTexture.active;
			RenderTexture.active = renderTex;
			Texture2D readableText = new Texture2D(source.width, source.height);
			readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
			readableText.Apply();
			RenderTexture.active = previous;
			RenderTexture.ReleaseTemporary(renderTex);
			return readableText;
		}
		public static Texture2D GetReadableTexture(Sprite source)
		{
			return GetReadableTexture(source.texture);
		}
	}
}
