using ClosersArtist.Models;
using OpenCvSharp;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;
using Point = OpenCvSharp.Point;
using Size = OpenCvSharp.Size;

namespace ClosersArtist
{
	public class ToolBox
	{
		public Mat GetTransparentBackGround()
		{
			//Mat TPImage = new Mat(1080, 1920, DepthType.Cv32S, 4);
			Mat TPImage = new Mat(1080, 1920, MatType.CV_8UC4);
			return TPImage;
		}
		public Mat TwoCharacter()
		{
			Mat BG = GetTransparentBackGround();
			

			return GetTransparentBackGround();
		}
		public Mat ThreeCharacter()
		{
			return GetTransparentBackGround();
		}
		/*public Mat Base64ToMat(byte[] base64data)
		{
			return bufImg2Mat(base64ToBufferedImage(base64), BufferedImage.TYPE_3BYTE_BGR, CvType.CV_8UC3);
		}*/

		public Mat ByteToMat(byte[] Picture)
		{
			Mat imageData = new Mat();
			imageData = Cv2.ImDecode(Picture, ImreadModes.Unchanged);

			return imageData;
		}
		public byte[] MatToByte(Mat mat)
		{
			return mat.ImEncode();
		}
		/*
		public byte[] Drawing(ArtistMessage model)
		{
			int characterNum = model.CharacterNum;

			Mat character0 = Cv2.ImDecode(model.CharacterPic0, ImreadModes.Unchanged);
			Mat character1 = Cv2.ImDecode(model.CharacterPic1, ImreadModes.Unchanged);
			Mat character2 = Cv2.ImDecode(model.CharacterPic2, ImreadModes.Unchanged);

			Mat BG = GetTransparentBackGround();
			var colorScalar = new Scalar(0,0,0,0);
			Cv2.CopyMakeBorder(character0, character0, 0, 0, 30, 1920 - 30 - character0.Width, BorderTypes.Constant, colorScalar);
			Cv2.CopyMakeBorder(character0, character0, 0, 0, 1920 - 30 - character0.Width, 30, BorderTypes.Constant, colorScalar);
			Cv2.CopyMakeBorder(character0, character0, 0, 0, (int)(960 - character0.Width * 0.5), (int)(960 - character0.Width * 0.5), BorderTypes.Constant, colorScalar);
			Cv2.AddWeighted(BG, 0, character0, 1, 0, BG);
			Cv2.AddWeighted(BG, 0, character1, 1, 0, BG);
			Cv2.AddWeighted(BG, 0, character2, 1, 0, BG);

			character0.Dispose();
			character1.Dispose();
			character2.Dispose();
			Bitmap bitmap = BG.ToBitmap();
			byte[] pngData;
			using (MemoryStream ms = new MemoryStream())
			{
				bitmap.Save(ms, ImageFormat.Png);
				pngData = ms.ToArray();
			}
			bitmap.Dispose();
			return pngData;
		}*/

		public Mat AddShadow(Mat src, double alpha=0.8)
		{
			Mat[] mats = new Mat[4];
			Cv2.Split(src, out mats);
			Cv2.Threshold(mats[3], mats[3], 99, 255, ThresholdTypes.BinaryInv);
			//Mat se = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3, 3), new Point(-1, -1));

			//Cv2.ImShow("alpha",mats[3]);

			//膨胀
			//Cv2.Dilate(mats[3], mats[3], se, new Point(-1, -1), 1);

			//腐蚀
			//Cv2.Erode(mats[3], mats[3], se, new Point(-1, -1), 1);

			Mat mask = new(src.Size(), src.Type(), new Scalar(0, 0, 0, 100));
			Mat m4 = new(src.Size(), src.Type(), new Scalar(0, 0, 0, 0));
			Cv2.CopyTo(mask, m4, mats[3]);
			//var MaskColor = Cv2.Split(mask);
			//Cv2.Merge([MaskColor[0], MaskColor[1], MaskColor[2], mats[3]], mask);


			Cv2.AddWeighted(src, 0.7, mask, alpha, 0, src, -1);

			mask.Dispose();
			m4.Dispose();
			//for(var i = MaskColor.Length-1; i >= 0; i--) MaskColor[i].Dispose();
			//se.Dispose();
			for (var i = mats.Length-1; i >= 0; i--) mats[i].Dispose();

			return src;
		}


		public Mat DrawOne(Mat BG, Mat Character, Rect Pos, bool Shadow)
		{
			//Resize(Character, Character);
			if (Shadow) Character = AddShadow(Character);
			Mat[] mats = new Mat[4];
			Cv2.Split(Character, out mats);
			Cv2.Threshold(mats[3], mats[3], 99, 255, ThresholdTypes.Binary);//灰度图二值化，高于1的变成黑色，其它白色
			Mat BGroi = new Mat(BG, Pos);
			Character.CopyTo(BGroi, mats[3]);

			mats[0].Dispose();
			mats[1].Dispose();
			mats[2].Dispose();
			mats[3].Dispose();
			BGroi.Dispose();
			return BG;
		}

		public void Resize(Mat src, Mat dst)
		{
			double rating = 1080.0 / (double)src.Height;
			int height = 1080;
			int width = (int)Math.Ceiling(src.Width * rating);
			Cv2.Resize(src, dst, new OpenCvSharp.Size(), rating, rating, InterpolationFlags.Linear);
		}

		public ArtistMessage Drawing(ArtistMessage model)
		{
			
			Mat BG = GetTransparentBackGround();
			var colorScalar = new Scalar(0, 0, 0, 0);

			if (model.CharacterNum == 1)
			{
				Mat character0 = Cv2.ImRead(NameToPath(model.CharacterName0), ImreadModes.Unchanged);

				BG = DrawOne(BG, character0, new Rect((int)(960 - character0.Width * 0.5), 0, character0.Width, character0.Height), !model.BrightCharacter0);

				character0.Dispose();
			}
			else if (model.CharacterNum == 2)
			{
				Mat character0 = Cv2.ImRead(NameToPath(model.CharacterName0), ImreadModes.Unchanged);
				Mat character1 = Cv2.ImRead(NameToPath(model.CharacterName1), ImreadModes.Unchanged);

				BG = DrawOne(BG, character0, new Rect(400, 0, character0.Width, character0.Height), !model.BrightCharacter0);
				BG = DrawOne(BG, character1, new Rect(1920 - 400 - character1.Width, 0, character1.Width, character1.Height), !model.BrightCharacter1);

				character0.Dispose();
				character1.Dispose();
			}
			else
			{
				Mat character0 = Cv2.ImRead(NameToPath(model.CharacterName0), ImreadModes.Unchanged);
				Mat character1 = Cv2.ImRead(NameToPath(model.CharacterName1), ImreadModes.Unchanged);
				Mat character2 = Cv2.ImRead(NameToPath(model.CharacterName2), ImreadModes.Unchanged);

				BG = DrawOne(BG, character0, new Rect(30, 0, character0.Width, character0.Height), !model.BrightCharacter0);
				BG = DrawOne(BG, character1, new Rect((int)(960 - character1.Width * 0.5), 0, character1.Width, character1.Height), !model.BrightCharacter1);
				BG = DrawOne(BG, character2, new Rect(1920 - 30 - character2.Width, 0, character2.Width, character2.Height), !model.BrightCharacter2);

				character0.Dispose();
				character1.Dispose();
				character2.Dispose();
			}
			
			string name = DateTime.UtcNow.Ticks.ToString() + ".png";
			model.ResultPath = NameToPathForModManager(name);
			string realPath = NameToPath(name);
			Cv2.ImWrite(realPath, BG);
			BG.Dispose();

			LogText += $"CharacterName0={model.CharacterName0}\n";
			LogText += $"CharacterName1={model.CharacterName1}\n";
			LogText += $"CharacterName2={model.CharacterName2}\n";
			LogText += $"ResultPath={model.ResultPath}\n";
			LogText += $"RealPath={realPath}\n";

			return model;
		}

		public string LogText = "";

		public string AssetTempFolderPath => Path.Combine(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)!)!)!, "Assets"), "Temp");

		public string NameToPath(string Name) => Path.Combine(AssetTempFolderPath, Name);
		public string NameToPathForModManager(string Name) => "Temp\\" + Name;
	}
}
