using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers
{
	public class LoadReadyInterceptorsData
	{
		public static List<Action> Data = new List<Action>();
	}
	[HarmonyPatch(typeof(SaveManager), "TempSaveLoad")]
	public class LoadReadyInterceptors
	{
		[HarmonyPostfix]
		public static void PostFix()
		{
			LoadReadyInterceptorsData.Data.ForEach(x => x());
		}
	}
}
