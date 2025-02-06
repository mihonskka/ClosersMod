// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// 假设图像数据已经以某种方式加载到 byte 数组 imageBytes 中
using ClosersArtist;
using ClosersArtist.Models;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

/*
using (var client = new NamedPipeClientStream(".", ConfigReader.GetProcessHubName(), PipeDirection.InOut, PipeOptions.None))
{
	await client.ConnectAsync();

	ArtistMessage ReceivedMessage = new();
	// Receive ImageData from server
	using (var ms = new MemoryStream())
	{
		byte[] buffer = new byte[1920 * 1080 * 4 * 4]; // Adjust size as needed
		int bytesRead;
		while ((bytesRead = await client.ReadAsync(buffer, 0, buffer.Length)) > 0)
		{
			ms.Write(buffer, 0, bytesRead);
		}
		ms.Position = 0; // Reset the stream position to the beginning

		ReceivedMessage = await JsonSerializer.DeserializeAsync<ArtistMessage>(ms) ?? new();
	}

	ToolBox tb = new();
	byte[] resultBytes = tb.Drawing(ReceivedMessage);

	// Save the selected image as d.bmp (omitting actual image processing for brevity)
	// Note: In a real-world scenario, you would convert the byte array to an Image, process it if needed, and then save it.
	File.WriteAllBytes(@"D:\d.png", resultBytes); // Assuming the byte array is already in a format that can be saved as BMP

	// Send selected image bytes back to server
	await client.WriteAsync(resultBytes, 0, resultBytes.Length);
	Console.WriteLine("HelloWorld");
}*/

class Program
{
	//入参有6，1-图像1的名称，2-图像2的名称，3-图像3的名称，4-图像1亮，5-图像2亮，6-图像3亮。以0填空
	static void Main(string[] args)
	{
		try
		{
			if (args.Length == 0) Console.WriteLine("这是工具类软件，不可直接被打开。");
			//File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"));
			ToolBox tb = new();
			ArtistMessage ReceivedMessage = new();
			ReceivedMessage.CharacterName0 = args[0];
			ReceivedMessage.CharacterName1 = args[1];
			ReceivedMessage.CharacterName2 = args[2];
			ReceivedMessage.BrightCharacter0 = args[3] != "0";
			ReceivedMessage.BrightCharacter1 = args[4] != "0";
			ReceivedMessage.BrightCharacter2 = args[5] != "0";
			ReceivedMessage.CharacterNum = 0;
			if (ReceivedMessage.CharacterName0 != "0") ReceivedMessage.CharacterNum++;
			if (ReceivedMessage.CharacterName1 != "0") ReceivedMessage.CharacterNum++;
			if (ReceivedMessage.CharacterName2 != "0") ReceivedMessage.CharacterNum++;
			var result = tb.Drawing(ReceivedMessage);
			Console.WriteLine(result.ResultPath);

			//File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"), tb.LogText);
			Log(tb.LogText);
		}
		catch (Exception ex)
		{
			Console.WriteLine();
			//File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"), ex.Message+"\n"+ex.InnerException+"\n"+ex.StackTrace);
			Log(ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
		}
	}
	static void Log(string msg)
	{
		try
		{
			using StreamWriter sw = File.AppendText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"));
			sw.WriteLine(msg);
			sw.Close();
			//Console.WriteLine("文件写入成功！");
		}
		catch (Exception ex)
		{
			//Console.WriteLine("写入文件时发生错误: " + ex.Message);
		}
	}
}