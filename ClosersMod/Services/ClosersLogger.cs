using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
	public static class clog
	{
		public static void w(string s, bool mandatory = false)
		{
			if (!GlobalSetting.ClosersDebugMode && !mandatory) return;
			if (s.StartsWith("CloFrameworkMsg: ")) UnityEngine.Debug.Log(s);
			else UnityEngine.Debug.Log("CloFrameworkMsg：" + s);
		}
		public static void iw(string s, bool mandatory = false)
		{
			if (!GlobalSetting.ClosersDebugMode && !mandatory) return;
			if (s.StartsWith("이슬비")) UnityEngine.Debug.Log(s);
			else UnityEngine.Debug.Log("이슬비：" + s);
		}
        public static void tw(string s, bool mandatory = false)
        {
            if (!GlobalSetting.ClosersDebugMode && !mandatory) return;
            if (s.StartsWith("티나")) UnityEngine.Debug.Log(s);
            else UnityEngine.Debug.Log("티나：" + s);
        }
    }
}
