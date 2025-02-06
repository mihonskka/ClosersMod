using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Models;
using ClosersIseubi.Service;
using ClosersFramework.Models;
using ClosersFramework.Service;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;
using ChronoArkMod.ModEditor;

namespace ClosersIseubi.Cards
{
	public class C_iseubi8 : IseubiBaseCard
	{
		public C_iseubi8() : base(3, false, true, CardType.Teleport)
		{
		}

		TranslationItem ExtDesc = new TranslationItem() { 
			Id = 1,
			SimplifiedChinese = "\n击杀敌方时，生成一张【空间·虫洞穿梭】，附带放逐，增加1点费用，二回合后弃牌。",
			TraditionalChinese = "\n擊殺敵方時，生成一張【空間·蟲洞穿梭】，附帶放逐，增加1點費用，二回合後棄牌。",
			English = "\nWhen killing target, get a '[S]WormHole Buffer' with Exclude, add 1 cost, discard after 2 turns.",
			Japanese= "\n敵を撃った時、「飛雷神・ディメンションチェイス」が生成され、除外が付き、AP+1、2ラウンド後にカードを捨てる。",
			Korean= "\n적을 처치한 경우 【[S]웜홀 생성】 1장이 생성되고 제외가 부여되며, 비용이 1증가하고 2턴 후 버려집니다."
        };

        public override string ClosersDesc(string desc)
        {
			if(new Teleport().LV2Desc())
				desc += ExtDesc.TransToLocalization;
            return base.ClosersDesc(desc);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			base.AttackEffectSingle(hit, SP, DMG, Heal);

			if (SP.TargetChar.Any(t => t.BuffFind(IseubiKeyWords.birsb)))
				BattleSystem.instance.AllyTeam.WaitCount++;
			//int seq = 0;
			//SP.TargetChar.ForEach(t =>
			//{
			//    if (!SP.Dodge[seq]) IseubiService.addIraishinBeacon(this.BChar,t);
			//    seq++;
			//});
		}

		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			Skill skill = new Skill();
			var gdesd = new GDESkillData(IseubiKeyWords.C_iseubi8_0);
			gdesd.Target = new GDEs_targettypeData("enemy");
            skill.Init(gdesd, this.MySkill.Master, this.BChar.MyTeam);

            skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
            skill.NotCount = false;
			skill.isExcept = true;
			skill.AutoDelete = 1;
			
            this.BChar.MyTeam.Add(skill.CloneSkill(true, null, null, false), false);
			////自身拥有飞雷神准备，且场上有嘲讽的敌方目标，且选中的敌方目标没有嘲讽，且选中的敌方目标没有飞雷神信标。
			//if (this.BChar.BuffFind(KeyWords.birsm) && BattleSystem.instance.EnemyTeam.AliveChars.Any(t => (t as BattleEnemy).istaunt) && Targets.All(t => !(t as BattleEnemy).istaunt) && Targets.All(t => !t.BuffFind(KeyWords.birsb)))
			//	this.BChar.Buffs.OrderBy(t => t.LifeTime).FirstOrDefault().SelfStackDestroy();
			base.SkillUseSingle(skill, Targets);
		}
		public override void SkillKill(SkillParticle SP)
		{
			clog.iw("神速-成功击杀");
			base.SkillKill(SP);
			IseubiSoundService.RandomSound(IseubiKeyWords.V_Shinsoku, 1, this);
			BattleSystem.instance.AllyTeam.AP++;
            new Teleport().LV2_Kill(this.BChar);
        }
	}
	public class C_iseubi8_0 : IseubiBaseCard
	{
		public C_iseubi8_0() : base(-3, true, false, CardType.Teleport)
		{
		}
        TranslationItem ExtDesc = new TranslationItem()
        {
            Id = 1,
            SimplifiedChinese = "\n击杀敌方时，生成一张【空间·虫洞穿梭】，附带放逐，增加1点费用，二回合后弃牌。",
            TraditionalChinese = "\n擊殺敵方時，生成一張【空間·蟲洞穿梭】，附帶放逐，增加1點費用，二回合後棄牌。",
            English = "\nWhen killing target, get a '[S]WormHole Buffer' with Exclude, add 1 cost, discard after 2 turns.",
            Japanese = "\n敵を撃った時、「飛雷神・ディメンションチェイス」が生成され、除外が付き、AP+1、2ラウンド後にカードを捨てる。",
            Korean = "\n적을 처치한 경우 【[S]웜홀 생성】 1장이 생성되고 제외가 부여되며, 비용이 1증가하고 2턴 후 버려집니다."
        };
        public override string ClosersDesc(string desc)
        {
            if (new Teleport().LV2Desc())
                desc += ExtDesc.TransToLocalization;
            return base.ClosersDesc(desc);
        }

        public override void SkillKill(SkillParticle SP)
		{
			clog.iw("神速二段-成功击杀");
			base.SkillKill(SP);
            this.BChar.Overload = 0;
			
            Skill skill = new Skill();
            var gdesd = new GDESkillData(IseubiKeyWords.C_iseubi8);
            gdesd.Target = new GDEs_targettypeData("enemy");
            skill.Init(gdesd, this.MySkill.Master, this.BChar.MyTeam);
            //skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
			skill.NotCount = true;
			skill.isExcept = true;
			skill.IgnoreTaunt = true;
			skill.AutoDelete = 1;
            skill.MySkill.Target = new GDEs_targettypeData("enemy");
            skill.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
            new Teleport().LV2_Kill(this.BChar);
            IseubiSoundService.RandomSound(IseubiKeyWords.V_Shinsoku, 1, this);
			var skill0 = skill.CloneSkill(true, null, null, false);

			//var skill = Skill.TempSkill(IseubiKeyWords.C_iseubi8, this.BChar, this.BChar.MyTeam);

            this.BChar.MyTeam.Add(skill0, true);
        }
	}
}
