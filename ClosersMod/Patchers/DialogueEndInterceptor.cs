using ClosersFramework.Service;
using ClosersFramework.Services;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers
{
	public static class DialogueEndInterceptorData
	{
		public static List<Action> RecordWindowEndAction = new List<Action>();
		public static List<Action> FriendShipWindowEndAction = new List<Action>();
	}

	[HarmonyPatch(typeof(RecordWindow), "DialogueEndDel")]
	public class DialogueEndInterceptorA
	{
		
		[HarmonyPostfix]
		public static void RWPostfix()
		{
			clog.w("检测到对话结束。RecordWindow");
			DialogueEndInterceptorData.RecordWindowEndAction.ForEach(x => x());
			SoundService.StopLooping();
		}
	}
	[HarmonyPatch(typeof(FriendShipWindow), "DialogueEndDel")]
	public class DialogueEndInterceptorB
	{
		[HarmonyPostfix]
		public static void FWPostfix()
		{
			clog.w("检测到对话结束。FriendShipWindow");
			DialogueEndInterceptorData.RecordWindowEndAction.ForEach(x => x());
			SoundService.StopLooping();
		}
	}
}
