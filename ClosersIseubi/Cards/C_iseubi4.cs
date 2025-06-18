using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Templates;

namespace ClosersIseubi.Cards
{
    public class C_iseubi4 : IseubiBaseCard
    {
        public C_iseubi4() : base(-1, false, false, CardType.Teleport)
        {
        }
        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            clog.iw("이슬비：使用虫洞穿梭");
            base.SkillUseSingleAfter(SkillD, Targets);
            this.BChar.BuffAdd(IseubiKeyWords.B_iseubi4, this.BChar);
        }
    }
}
namespace ClosersIseubi.Buffs
{
    public class B_iseubi4 : ClosersBaseBuff, IP_BuffAdd, IP_BuffUpdate
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff) => check(addedbuff);
        public void BuffUpdate(Buff MyBuff) => check(MyBuff);

        public override void BuffStat()
        {
            base.BuffStat();
        }

        void check(Buff buff)
        {
            if (buff.BuffData.Key == this.BuffData.Key)
            {
                if (this.StackNum >= 4)
                {
                    clog.iw($"이슬비：刷新固定能力");
                    this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
                    clog.iw($"이슬비：销毁计数器");
                    SelfDestroy();
                }
            }
        }
    }
}