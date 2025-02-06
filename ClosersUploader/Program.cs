// See https://aka.ms/new-console-template for more information
using ChronoArkMod.ModData;
using ChronoArkMod;
using ChronoArkMod.ModEditor;
using UnityEngine.Events;
using Steamworks;
using ClosersUploader;
using System.Text.Json;

Console.WriteLine("Hello, World!");
string str1 = File.ReadAllText(@"D:\Steam\steamapps\workshop\content\1188930\ClosersMod\ChronoArkMod.json");
var modInfo = ModInfo.Deserialize(str1);

if (true)
{
	if (modInfo.WorkShopId.IsNullOrEmpty())
	{
		Extends.CreateItem("D:\\Steam\\steamapps\\workshop\\content\\1188930\\ClosersMod\\Assets", modInfo, EWorkshopFileType.k_EWorkshopFileTypeFirst, modInfo.Visibility, modInfo.ChangeNote);
		return;
	}
	SteamAPI.Init();
	Extends.UploadItemUpdate("D:\\Steam\\steamapps\\workshop\\content\\1188930\\ClosersMod\\Assets", modInfo, EWorkshopFileType.k_EWorkshopFileTypeFirst, modInfo.Visibility, modInfo.ChangeNote, false);
}

Console.ReadKey();

