using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;

namespace ClosersIseubi.Cards
{
    public class C_iseubi10:IseubiBaseCard
    {
        public C_iseubi10():base(1,false,true,CardType.Teleport)
        {

        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            IseubiSoundService.RandomSound(IseubiKeyWords.V_Overture, 2, this);
            if (BattleSystem.instance.TurnNum == 1)
            {
                this.BChar.BuffAdd(IseubiKeyWords.birsm, this.BChar);
                IseubiService.addChip(1, this.BChar);
            }
            base.SkillUseSingle(SkillD, Targets);
        }
    }
}
