using ClosersFramework.Service;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    public class C_tina5:TinaBaseCard
    {
        public C_tina5():base(false,0) { }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            //clog.tw("冰箱sus");
            this.BChar.Buffs.FirstOrDefault(t => t.BuffData.Key == TinaKeyWords.B_Overheat)?.SelfDestroy();
            this.BChar.Buffs.Where(t => t.BuffData.BuffTag.Key == "DOT")?.ToList().ForEach(t => t.SelfDestroy());
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaFridge, 2, this);
        }
    }
}
