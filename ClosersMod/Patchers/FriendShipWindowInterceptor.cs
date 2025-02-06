using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers
{
	[HarmonyPatch(typeof(FriendShipWindow))]
	public class FriendShipWindowInterceptor
	{
		[HarmonyTranspiler]
		[HarmonyPatch("Init")]
		public static IEnumerable<CodeInstruction> PostFix(IEnumerable<CodeInstruction> instructions, MethodBase original)
		{
			clog.w("FSW补丁方法：正在获取好感度窗口Init的IL语句！");
			var codes = instructions.ToList();

			//29-33
			if (codes[33].opcode == OpCodes.Brfalse)
			{
				codes.RemoveAt(33);
				codes.RemoveAt(32);
				codes.RemoveAt(31);
				codes.RemoveAt(30);
				codes.RemoveAt(29);
				clog.w("FSW补丁方法：好感度窗口Init的IL语句已被修改！");
			}
			else
			{
				clog.w("FSW补丁方法：警告！好感度窗口Init已被修改，补丁方法已暂停行动。");
			}
			return codes.AsEnumerable();
		}
	}
}
