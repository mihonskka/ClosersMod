using ClosersFramework.Data;
using ClosersFramework.Service;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gamepad_HoldKey;

namespace ClosersFramework.Patchers
{
	public class LoadOverInterceptorData
	{
		public static List<(string id, List<string> data)> TalkingData { get; set; } = new List<(string, List<string>)>();
	}
	

	[HarmonyPatch(typeof(SaveManager), "TempSaveLoad")]
	public class LoadOverInterceptorA
	{
		[HarmonyPostfix]
		public static void Postfix()
		{
			LoadOverInterceptorData.TalkingData.ForEach(t =>
			{
				GDEDataManager.GetStringList(t.id, "Text_Field_GetItem").ForEach(i=>clog.iw($"LOI: TFG文本：{i}"));
				GDEDataManager.GetStringList(t.id, "Dialogue_NomalGiftTalk");
				GDEDataManager.SetStringList(t.id, "Dialogue_NomalGiftTalk", t.data);
				GDEDataManager.SetStringList(t.id, "Dialogue_GoodGiftTalks", t.data);
				GDEDataManager.SetStringList(t.id, "Dialogue_FriendShipLVTalks", new List<string>() { t.data[0] , t.data[0] , t.data[0] });
				clog.w("LOI: id:" + t.id + "; List0: " + t.data[0]);
			});
		}
	}
}
