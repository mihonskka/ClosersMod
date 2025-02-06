using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersDebugMode.Expedition
{
	[HarmonyPatch(typeof(RecordWindow))]
	public class RecordWindowPatch
	{
		[HarmonyPatch("Init")]
		[HarmonyPostfix]
		public static void InitPost(RecordWindow __instance)
		{
			clog.iw("观察组报告：记录窗口初始化！");
			RecordInfo[] array = Resources.LoadAll<RecordInfo>("Records");
			clog.iw($"观察组报告：0号记录的GUID为：{array[0].RecordDialogue_add.AssetGUID}");
			clog.iw($"观察组报告：0号记录的Desc为：{array[0].Desc}");
		}
		[HarmonyPatch("VoiceStart")]
		[HarmonyPostfix]
		public static void VSPost(RecordWindow __instance)
		{
			clog.iw("观察组报告：调用了VoiceStart！");
		}
		[HarmonyPatch("OpenRecord")]
		[HarmonyPostfix]
		public static void ORPost(RecordWindow __instance)
		{
			clog.iw("观察组报告：调用了OpenRecord！");
		}
	}
}
