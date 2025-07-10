using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    /// <summary>
    /// first aid kit
    /// </summary>
    public class C_tina10:TinaBaseCard
    {
        public C_tina10():base(false) { }
        public override void BeforeHeal(BattleChar hit, SkillParticle SP, float Heal, bool Cri)
        {
            if (this.MySkill.IsCreatedInBattle)
            {
                Heal /= 2;
            }
            Heal += (int)(hit.GetStat.maxhp * 0.25 + 1);
            base.BeforeHeal(hit, SP, Heal, Cri);
        }
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			TinaService.SwitchWeapon(TinaWeapons.NoneOrOther);
			base.SkillUseSingle(SkillD, Targets);
		}
        public override void Init()
        {
            base.Init();
            
        }
		public override IEnumerator DrawAction()
		{
			if (BattleSystem.instance != null && this.MySkill.IsCreatedInBattle && this.MySkill.AllExtendeds.All(t => t?.Data?.Key != TinaKeyWords.Ex_tina10))
			{
				this.MySkill.ExtendedAdd(TinaKeyWords.Ex_tina10);
				this.APChange = -1;
			}
			return base.DrawAction();
		}
	}
}
namespace ClosersTina.Extendeds
{
    public class Ex_tina10:ClosersBaseExtend
    {
        
    }
}
