using ClosersFramework.Service;
using HarmonyLib;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersDebugMode.Expedition
{
	[HarmonyPatch(typeof(FriendShipWindow))]
	public class FriendShipWindowPatch
	{
		[HarmonyPatch("Init")]
		[HarmonyPostfix]
		public static void InitPost(FriendShipWindow __instance)
		{
			clog.iw("观察组报告：好感度窗口初始化！");
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

		public static IEnumerable<CodeInstruction> InitPost(IEnumerable<CodeInstruction> instructions, MethodBase original)
		{
			clog.iw("观察组报告：获取好感度窗口Init的IL语句！");
			var codes = instructions.ToList();

			//29-33
			if (codes[33].opcode == OpCodes.Brfalse)
			{
				codes.RemoveAt(33);
				codes.RemoveAt(32);
				codes.RemoveAt(31);
				codes.RemoveAt(30);
				codes.RemoveAt(29);
				clog.iw("观察组报告：好感度窗口Init的IL语句已被修改！");
			}
			else
			{
				clog.iw("观察组报告：警告！好感度窗口Init已被篡改，补丁方法已暂停行动。");
			}
			return codes.AsEnumerable();
		}
	}
}
