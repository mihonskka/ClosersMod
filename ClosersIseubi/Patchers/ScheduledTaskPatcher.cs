using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClosersIseubi.Patchers
{
    internal class ScheduledTaskPatcher
    {
    }

    public class ExpDescTask
    {
        /*
        [HarmonyPostfix]
        [HarmonyPatch(typeof(FieldSystem), "Update")]
        public static void myfix()
        {
            if (ThrottleService.SearchRegistration(ThrottleKeyWords.ExpDescTask)?.isTimeout ?? true)
            {
                clog.w("第二等级系统定时任务");
                ExpService.PassiveDescCheckOutBattle();
                ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.ExpDescTask, 1000);
            }
        }

        public void myfix2()
        {
            new Task(() =>
            {
                while (true)
                {
                    if (ThrottleService.SearchRegistration(ThrottleKeyWords.ExpDescTask)?.isTimeout ?? true)
                    {
                        clog.w("第二等级系统定时任务");
                        ExpService.PassiveDescCheckOutBattle();
                        ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.ExpDescTask, 1000);
                    }
                }
            }).Start();
        }
        */
    }
}
