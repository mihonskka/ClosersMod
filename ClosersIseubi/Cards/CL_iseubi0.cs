using ClosersIseubi.Extendeds;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Service;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using ClosersFramework.Templates;

namespace ClosersIseubi.Cards
{
	public class CL_iseubi0 : ClosersBaseCard
    {
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
			clog.iw($"이슬비：使用红桃Q");
			List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(IseubiKeyWords.CL_iseubi0_0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.CL_iseubi0_1, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(IseubiKeyWords.CL_iseubi0_2, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
			_Targets = Targets;
		}
		List<BattleChar> _Targets;

		public void Del(SkillButton Mybutton)
		{
			Mybutton.Myskill.FreeUse = true;
			clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
			if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.CL_iseubi0_0)
				this.BChar.ParticleOut(Skill.TempSkill(IseubiKeyWords.CL_iseubi0_0, this.BChar, this.BChar.MyTeam), _Targets);
			if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.CL_iseubi0_1)
				this.BChar.ParticleOut(Skill.TempSkill(IseubiKeyWords.CL_iseubi0_1, this.BChar, this.BChar.MyTeam), _Targets);
			if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.CL_iseubi0_2)
			{
				clog.iw("红桃Q-选择重力");
				this.BChar.ParticleOut(Skill.TempSkill(IseubiKeyWords.CL_iseubi0_2, this.BChar, this.BChar.MyTeam), _Targets);
			}
		}
	}
	public class CL_iseubi0_0 : ClosersBaseCard
    {
		public override void Init()
		{
			clog.iw($"红桃Q-闪电");
			base.Init();
		}
		public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			clog.iw($"이슬비：红桃Q-闪电-使用");
			BattleSystem.DelayInputAfter(this.Draw());
			BattleSystem.DelayInputAfter(this.Draw());
			clog.iw($"红桃Q-闪电-抽卡完毕");
			var iseubi = IseubiService.FindIseubiInBattle();
			IseubiService.addChipWithBuff(25, iseubi);
			IseubiService.addLSBuff(8, iseubi);
			Ex_L_iseubi0_0 iseubiEx = DataToExtended(new GDESkillExtendedData(IseubiKeyWords.Ex_L_iseubi0_0)) as Ex_L_iseubi0_0;
			BattleSystem.instance.AllyTeam.Skills.Where(t => toolbox.IsLightning(t.MySkill.KeyID)).ToList().ForEach(t => t.ExtendedAdd_Battle(iseubiEx));
			clog.iw($"红桃Q-闪电-使用完毕");
			base.AttackEffectSingle(hit, SP, DMG, Heal);
		}
		public IEnumerator Draw()
		{
			clog.iw($"红桃Q-闪电-准备抽卡");
			Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => toolbox.IsLightning(skill.MySkill.KeyID));
			if (skill2 == null) BattleSystem.instance.AllyTeam.Draw();
			else yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
			yield return null;
			yield break;
		}
		ToolBox toolbox = new ToolBox();
    }
    public class CL_iseubi0_1 : ClosersBaseCard
    {
		public override void Init()
		{
			clog.iw($"红桃Q-空间-初始化");
			base.Init();
		}
		public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			clog.iw($"이슬비：红桃Q-空间-使用");
			BattleSystem.DelayInputAfter(this.Draw());
			BattleSystem.DelayInputAfter(this.Draw());
			clog.iw($"红桃Q-空间-抽卡完毕，准备施加标记");
			IseubiService.addIraishinBeacon(this.BChar, SP.TargetChar[0]);
			var iseubi = IseubiService.FindIseubiInBattle();
			iseubi?.BuffAdd(IseubiKeyWords.birsm, this.BChar);
			if(iseubi!=null) iseubi.Overload = 0;
			BattleSystem.instance.AllyTeam.WaitCount++;
			clog.iw($"红桃Q-空间-释放完毕");
			base.AttackEffectSingle(hit, SP, DMG, Heal);
		}
		public IEnumerator Draw()
		{
			clog.iw($"红桃Q-空间-准备抽卡");
			Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => toolbox.IsIraishin(skill.MySkill.KeyID));
			if (skill2 == null) BattleSystem.instance.AllyTeam.Draw();
			else yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
			yield return null;
			yield break;
		}
		ToolBox toolbox = new ToolBox();
	}
    public class CL_iseubi0_2 : ClosersBaseCard
    {
		public override void Init()
		{
			clog.iw($"红桃Q-重力-初始化");
			base.Init();
		}

		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			clog.iw("红桃Q-SUSA");
			base.SkillUseSingleAfter(SkillD, Targets);
		}

		public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			clog.iw($"이슬비：红桃Q-重力-使用");
			BattleSystem.DelayInputAfter(this.Draw());
			BattleSystem.DelayInputAfter(this.Draw());
			clog.iw($"红桃Q-重力-抽卡完毕");
			var iseubi = IseubiService.FindIseubiInBattle();
			if (iseubi != null && IseubiService.GetChipNum(iseubi) >= 3)
			{
				clog.iw($"이슬비：红桃Q-重力-施加重压");
				IseubiService.reduceChipWithBuff(-3, iseubi);
				//SP.TargetChar.ForEach(t => clog.w($"红桃Q-重力-施加重压-含有目标-{t.Info.Name}"));
				//SP.TargetChar.ForEach(t => t.BuffAdd(KeyWords.B_NRT_grab, this.BChar, PlusTagPer: 100));
				BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => t.BuffAdd(IseubiKeyWords.B_Iseubi_grab, this.BChar, PlusTagPer: 100));
			}
			clog.iw($"红桃Q-重力-释放完毕");
			base.AttackEffectSingle(hit, SP, DMG, Heal);
		} 
		public IEnumerator Draw()
		{
			clog.iw($"红桃Q-重力-准备抽卡");
			Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => toolbox.IsGravity(skill.MySkill.KeyID));
			if (skill2 == null) BattleSystem.instance.AllyTeam.Draw();
			else yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
			yield return null;
			yield break;
		}
		ToolBox toolbox = new ToolBox();
	}
}
namespace ClosersIseubi.Buffs
{
    public class B_L_iseubi0_2 : Buff
    {
        public override void Init()
        {
            clog.iw("红桃Q-重力-施加debuff");
            this.PlusStat.def = -12;
            this.PlusPerStat.Damage = -30;
            base.Init();
        }
    }
}

namespace ClosersIseubi.Extendeds
{
    public class Ex_L_iseubi0_0 : ClosersBaseExtend
    {
        public override void Init()
        {
            clog.iw($"红桃Q-闪电-施加增益");
            this.PlusSkillStat.PlusCriDmg = 15;
            base.Init();
        }
    }
}