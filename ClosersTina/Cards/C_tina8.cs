using ClosersTina.Cards;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    public class C_tina8:TinaBaseCard
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public C_tina8():base(false)
        {
            this.AudioName = TinaKeyWords.Closers_Tina_Shotgun_Audio;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaShotgun, 3, this);
        }

        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            this.SkillBasePlus.Target_BaseDMG = 0;
            if (Target is BattleEnemy && (Target as BattleEnemy).istaunt)
            {
                Damage += BattleChar.CalculationResult(this.BChar.Info.get_stat.atk, 33, 0);
            }
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 33f)).ToString()).ToString();
        }
    }
}
