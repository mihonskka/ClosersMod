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
    public class C_iseubi14: IseubiBaseCard
    {
        public C_iseubi14():base(-2,true,false,CardType.Gravity)
        {
            
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            IseubiSoundService.RandomSound(IseubiKeyWords.V_MultiGravity, 1, this);
        }
    }
}
