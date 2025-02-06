using ClosersTina.KeyWords;
using ClosersTina.Services;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Patcher
{

    [HarmonyPatch(typeof(SkillParticle), "End")]
    public class PassiveInterceptors
    {
        [HarmonyPrefix]
        public static void Prefix(ref SkillParticle __instance)//ref SkillParticle SP, ref bool Dodge
        {
            //if (SP.LastHit && SP.SkillData.PlusHit && BattleSystem.instance.AllyTeam.AliveChars.Any(t => t.Info.KeyData == TinaKeyWords.Tina))
            /*if (SP.LastHit && BattleSystem.instance.AllyTeam.AliveChars.Any(t => t.Info.KeyData == TinaKeyWords.Tina))
            {
                TinaService.AddPassiveCounter();
            }*/
            try
            {
                if (__instance?.SkillData?.Master == null) return;
                if (__instance?.SkillData?.Master is BattleEnemy) return;
                TinaService.AddPassiveCounter();
            }
            catch (Exception) { }
        }
    }

}
