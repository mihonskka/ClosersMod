using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersHumanity.KeyWords
{
	public static class SoundKeyWords
	{
		//public static (string Name, int Duration) M_ClosersReadyToGo = (nameof(M_ClosersReadyToGo), 216);
		public static BGMUnit M_ClosersReadyToGo = new BGMUnit() { SoundType = nameof(M_ClosersReadyToGo), Duration = 216, Loop = true };
		//public static (string Name, int Duration) COM_OutBreak = (nameof(COM_OutBreak), 86);
		public static BGMUnit COM_OutBreak = new BGMUnit() { SoundType = nameof(COM_OutBreak), Duration = 86, Loop = true };
		//public static (string Name, int Duration) COM_ArkSight = (nameof(COM_ArkSight), 66);
		public static BGMUnit COM_ArkSight = new BGMUnit() { SoundType = nameof(COM_ArkSight), Duration = 66, Loop = true };
		//public static (string Name, int Duration) COM_CampAmbi = (nameof(COM_CampAmbi), 52);
		public static BGMUnit COM_CampAmbi = new BGMUnit() { SoundType = nameof(COM_CampAmbi), Duration = 52, Loop = true };
		public static BGMUnit COM_bangjoo = new BGMUnit() { SoundType = nameof(COM_bangjoo), Duration = 50, Loop = true, Intro = new BGMUnit() { SoundType = nameof(COM_bangjoo) + "_Intro", Duration = 50, Loop = false } };
		/// <summary>
		/// 惊讶
		/// </summary>
		public static string COA_iM = nameof(COA_iM);
		public static string COA_NoiseMemory = nameof(COA_NoiseMemory);
		public static string COA_Fail = nameof(COA_Fail);
		public static string COA_Walking = nameof(COA_Walking);
		/// <summary>
		/// 打击声
		/// </summary>
		public static string COA_sh = nameof(COA_sh);
		/// <summary>
		/// 灵光一闪
		/// </summary>
		public static string COA_fl = nameof(COA_fl);
		public static string COA_fl2 = nameof(COA_fl2);
		public static string COA_Idea = nameof(COA_Idea);
		public static string COA_DoorOpen = nameof(COA_DoorOpen);
		public static string A_Knockout = nameof(A_Knockout);
	}
}
