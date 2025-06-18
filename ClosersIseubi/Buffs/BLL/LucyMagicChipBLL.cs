using ClosersIseubi.Buffs.IBLL;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs.BLL
{
    public class LucyMagicChipBLL:ILucyMagicChipBLL
    {
        public void checkbuff(Buff thisbuff,Buff buff = null, bool permit = false)
        {
            ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.LucyMagicChipChecking, 300);
            if (permit || buff.BuffData.Key != thisbuff.BuffData.Key)
                EventDispatcher.Dispatch(IseubiEventKeys.CheckLucyMagicChip);
        }
    }
    public class LucyMagicChipForAllyBLL : ILucyMagicChipForAllyBLL
    {
        public void check(Buff thisbuff)
        {
            if (BattleSystem.instance != null)
            {
                clog.iw("碎片协助-正在进行第一次检测");
                int lucyChipCount = BattleSystem.instance.AllyTeam?.LucyChar?.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.blmc)?.StackNum ?? 0;
                clog.iw($"碎片协助-首次检测露西碎片数量为{lucyChipCount}");
                thisbuff.PlusStat.hit = 1f * lucyChipCount;
                thisbuff.PlusStat.dod = 1f * lucyChipCount;
                thisbuff.PlusStat.cri = 1f * lucyChipCount;
            }
        }
    }
}
