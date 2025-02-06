using ClosersTina.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    public class C_tina3:TinaBaseCard, IP_SkillCastingStart
    {
        public C_tina3() : base(false,0)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            ThisSkill.TargetReturn().ForEach(t => t.BuffAdd(TinaKeyWords.B_SpaceDodge, this.BChar));
        }


        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            Targets.ForEach(t => t.BuffRemove(TinaKeyWords.B_SpaceDodge));
        }
    }
}
