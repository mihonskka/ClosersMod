using ClosersFramework.Templates;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_iseubiProxyBuff : ClosersBaseBuff, IP_SkillUse_User_After
    {
        public void SkillUseAfter(Skill SkillD)
        {
            var iseubi = IseubiService.FindIseubiInBattle();
            if (this.BChar != iseubi && !SkillD.PlusHit) IseubiService.addChip(1, iseubi, this.BChar);

            if(!SkillD.PlusHit) IseubiService.checkWarmHoleAbility(SkillD, iseubi);
        }
        public override void Init()
        {
            this.OnePassive = true;
            base.Init();
        }
    }
}
