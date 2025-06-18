using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Models;
using ClosersIseubi.Service;
using ClosersFramework.Models;
using ClosersFramework.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Data;
using ToolBox = ClosersIseubi.Service.ToolBox;

namespace ClosersIseubi.Cards
{
    public class C_iseubi7 : IseubiBaseCard
    {
        public C_iseubi7() : base(-1, true, false, CardType.Gravity)
        { 
        }
        public Guid myGuid;
        public override void Init()
        {
            myGuid = Guid.NewGuid();
            clog.iw($"이슬비：神罗天征初始化，当前guid为{myGuid}");
            base.Init();
            this.OnePassive = true;
            this.CanUseStun = true;

            if (BattleSystem.instance != null)
            {
                clog.iw($"神罗天征初始化-增加事件");
                EventDispatcher.AddAction(IseubiEventKeys.NoticeC7, (object obj)=>ActivateShinratense(obj));
                EventDispatcher.AddAction(IseubiEventKeys.ReNoticeC7, _=> {
                    myGuid = Guid.NewGuid();
                    clog.iw($"이슬비：神罗天征重新分配guid，当前guid为{myGuid}");
                    //EventDispatcher.AddAction(EventKeys.NoticeC7, new Action<object>(ActivateShinratense));
                    });
            }
        }

        TranslationItem GLV1 = new TranslationItem() { Id=0,
            SimplifiedChinese= "每回合限一次，友军被选定为目标时，可以消耗5枚碎片提前打出这个技能，让本次攻击无效。若如此做，这张牌将被放逐。", 
            TraditionalChinese="每回合限一次，友軍被選定為目標時，可以消耗5枚碎片提前打出這個技能，讓本次攻擊無效。若如此做，這張牌將被放逐。", 
            English= "Limited to once per turn. When this skill is in the hand or in the fixed ability, and allies are going to be attacked, 'Forced Cancel' can cost 5 chips and invalidate the effect of the skill in this turn. If Lucy casting 'Forced Cancel' by this way, this 'Forced Cancel' will be excluded;", 
            Japanese= "ターンに1回限り、味方がターゲットに選定された場合、5枚のビットを消費してこの技を繰り出し、今回の攻撃を無効にすることができる。そうすれば、このカードは除外されるだろう。", 
            Korean= "매 라운드 마다 한 번 제한 하다，아군이 대상으로 선정된 경우 이 스킬을 사전에 내어 해당 스킬을 무효화 할 수 있습니다 그리고 비트 5개를 소모합니다. 이렇게 하면 이 덱은 제외됩니다."
        };
        TranslationItem GLV2 = new TranslationItem() { Id=0,
            SimplifiedChinese= "解除自身的所有减益。\n", 
            TraditionalChinese="解除自身的所有減益。\n", 
            English= "Clear all of the debuff belong to Sylvi", 
            Japanese= "自身のすべての減益を解除する。", 
            Korean= "자신의 모든 디버프를 해제합니다."
        };
        TranslationItem GLV4 = new TranslationItem() { Id=0,
            SimplifiedChinese= "清除所有友军的减益。\n", 
            TraditionalChinese="清除所有友軍的減益。\n", 
            English= "Clear all of the debuff belong to allies", 
            Japanese= "すべての友軍の減益を一掃する。", 
            Korean= "모든 아군의 디버프를 제거합니다."
        };
        TranslationItem GLV0 = new TranslationItem() { Id=0,
            SimplifiedChinese= "清除自身的干扰减益。\n", 
            TraditionalChinese="清除自身的干擾減益。\n", 
            English= "Clear all of the CC debuff belong to Sylvi", 
            Japanese= "自身の干渉<sprite=2>を除去して減益にする。", 
            Korean= "자신을 방해하는 디버프를 제거합니다<sprite=2>."
        };

        public override string ClosersDesc(string desc)
        {
            if(new Gravity().LV4Desc())
            {
                desc += GLV4.TransToLocalization;
            }
            else if(new Gravity().LV2Desc())
            {
                desc += GLV2.TransToLocalization;
            }
            else
            {
                desc += GLV0.TransToLocalization;
            }

            if(new Gravity().LV1Desc())
            {
                desc += GLV1.TransToLocalization;
            }
            
            return base.ClosersDesc(desc);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            clog.iw("이슬비：释放神罗天征");
            clog.iw($"이슬비：神罗天征-this.BChar.Info.Name：{this.BChar.Info.Name}");
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.AllyList.ForEach(t =>
            {
                clog.iw($"이슬비：神罗天征-AllyList.Info.Name：{t.Info.Name}");
            });
            if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.CC, true, true).Any())
            {
                RemoveCC();
                clog.iw("이슬비：神罗天征-解除");
                IseubiSoundService.Sound(IseubiKeyWords.V_Shinratense, this);
            }
            //EventDispatcher.RemoveAction(EventKeys.NoticeC7);
        }

        public void RemoveCC()
        {
            clog.iw("이슬비：神罗天征-解除不可解除");
            this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.CC, true, true).ForEach(t =>
            {
                t.CantDisable = true;
                t.SelfDestroy();
            });
            this.BChar.Buffs.RemoveAll(t => t.BuffData.BuffTag.Key == "CrowdControl");
            new Gravity().LV2_Shinratense(this.BChar);
            new Gravity().LV4_Shinratense();
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;

            clog.iw($"이슬비：Mybutton_KeyID：{Mybutton.Myskill.MySkill.KeyID}");
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi_Cancel)
            {
                clog.iw("选择迎击");
                //this.BChar.ParticleOut(Skill.TempSkill(KeyWords.C_iseubi_Cancel, this.BChar, this.BChar.MyTeam), new List<BattleChar>());
                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == IseubiKeyWords.C_iseubi7)
            {
                clog.iw("选择神罗天征");
                var skill = new Skill();
                //skill.Init(new GDESkillData(IseubiKeyWords.C_iseubi7), this.MySkill.Master, this.BChar.MyTeam);
                skill = Skill.TempSkill(IseubiKeyWords.C_iseubi7, this.BChar, this.BChar.MyTeam);
                skill.NotCount = true;
                skill.isExcept = true;
                skill.UsedApNum = 0;
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars);
                IseubiSoundService.Sound(IseubiKeyWords.V_Shinratense, this);
                clog.iw($"이슬비：神罗天征使对方攻击无效化");
                ShareSkill?.AllExtendeds.Clear();

                if (ShareSkill.MySkill.Effect_Target != null) ShareSkill.MySkill.Effect_Target.DMG_Base = 0;
                if (ShareSkill.MySkill.Effect_Target != null) ShareSkill.MySkill.Effect_Target.DMG_Per = 0;
                try
                {
                    ShareSkill.MySkill?.Effect_Target?.Buffs?.Clear();
                    ShareSkill.MySkill?.Effect_Target?.BuffPlusTagPer?.Clear();
                    ShareSkill.MySkill?.SkillExtended?.Clear();
                    ShareSkill.MySkill?.SKillExtendedItem?.Clear();
                }
                catch { }

                //var nullMS = toolbox.DeepClone(ShareSkill.MySkill);
                //var nullMS = ShareSkill.MySkill.DeepClone();
                //var nullMS = new GDESkillData(ShareSkill.MySkill.Key);
                /*if (nullMS.Effect_Target != null ) nullMS.Effect_Target.DMG_Base = 0;
                if (nullMS.Effect_Target != null) nullMS.Effect_Target.DMG_Per = 0;
                try
                {
                    nullMS?.Effect_Target?.Buffs?.Clear();
                    nullMS?.Effect_Target?.BuffPlusTagPer?.Clear();
                    nullMS?.SkillExtended?.Clear();
                    nullMS?.SKillExtendedItem?.Clear();
                }
                catch { }
                ShareSkill.MySkill = nullMS;*/
                TurnResetInfo.NeedReloadEnemySkill = true;

                RemoveCC();
                IseubiService.reduceChipWithBuff(-5,this.BChar);
                //EventDispatcher.RemoveAction(EventKeys.NoticeC7 + myGuid);
                clog.iw($"이슬비：神罗天征移除事件");
                var tem = BattleSystem.instance.AllyTeam.Skills?.FirstOrDefault(t => t.MySkill.KeyID == IseubiKeyWords.C_iseubi7);
                if (tem != null) tem?.Except();
                else 
                {
                    clog.iw($"이슬비：神罗天征固定能力被禁用");
                    var BAiseubi = (this.BChar as BattleAlly);
                    if (BAiseubi.MyBasicSkill != null)
                    {
                        BAiseubi.MyBasicSkill.ThisSkillUse = true;
                        BAiseubi.MyBasicSkill.InActive = true;
                        //BAiseubi.MyBasicSkill = null;
                    }
                }
                this.BChar.BuffAdd(IseubiKeyWords.B_ShinratenseExhausted, this.BChar);
                clog.iw($"이슬비：神罗天征里侧除外");
                //this?.UseWaste();
                //BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, Skill.TempSkill(KeyWords.C_iseubi6_1)));
            }
        }
        /*public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
		{
			clog.w("이슬비：准备触发选中防反！");
			using (List<BattleChar>.Enumerator enumerator = SaveTargets.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Info.Ally && SaveTargets.Contains(this.BChar))
					{
						clog.w($"이슬비：选中防反成功！当前碎片数量：{IseubiService.GetChipNum(this.BChar)}");
						if (IseubiService.GetChipNum(this.BChar) >= 1)
						{
                            clog.w($"이슬비：神罗天征列表初始化");
                            List<Skill> list = new List<Skill>
							{
								this.MySkill,
								Skill.TempSkill(KeyWords.C_iseubi_Cancel, this.MySkill.Master, this.MySkill.Master.MyTeam)
							};
                            clog.w($"이슬비：神罗天征选择入队");
                            BattleSystem.instance.StartCoroutine(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
							if(passiveUse)
							{
                                clog.w("神罗天征将对方攻击无效化");
                                skill.MySkill.Effect_Target.DMG_Base = 0;
								skill.MySkill.Effect_Target.DMG_Per = 0;
								skill.MySkill.Effect_Target.Buffs.Clear();
							}
						}
						yield return new WaitForSeconds(0.2f);
						break;

					}
				}
			}
			//List<BattleChar>.Enumerator enumerator = default(List<BattleChar>.Enumerator);
			yield break;
			yield break;
		}*/
        public Skill ShareSkill { get; set; }
        public void ActivateShinratense(object a)
        {
            clog.iw("收到消息-发动神罗天征！");
            if (!new Gravity().LV1()) return;
            clog.iw("神罗天征-重力等级合格！");
            if (this.BChar.BuffFind(IseubiKeyWords.B_ShinratenseExhausted)) return;
            clog.iw("神罗天征-自身无疲惫！");
            if (IseubiService.GetChipNum(this.BChar) < 5) return;
            clog.iw("神罗天征-碎片数量足够！");

            if (!(a is C7Pack)) return;
            var input = a as C7Pack;
            var receiverId = input.id;
            if (receiverId != myGuid) return;
            clog.iw("神罗天征-ID匹配成功");
            var SaveTargets = input.SaveTargets;
            var skill = input.skill;
            var Attacker = input.Attacker;
            ShareSkill = skill;
            clog.iw($"이슬비：神罗天征-被选中");
            if (IseubiService.GetChipNum(this.BChar) >= 1 && SaveTargets.Any(t => t.Info.Ally))
            {
                clog.iw($"이슬비：神罗天征列表初始化");
                List<Skill> list = new List<Skill>
                            {
                                this.MySkill,
                                Skill.TempSkill(IseubiKeyWords.C_iseubi_Cancel, this.MySkill.Master, this.MySkill.Master.MyTeam)
                            };
                clog.iw($"이슬비：神罗天征选择入队");
                BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
                clog.iw($"이슬비：选择函数执行完毕");
            }
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);
            //EventDispatcher.RemoveAction(EventKeys.NoticeC7 + myGuid);
        }
        public override void SelfDestroy()
        {
            //EventDispatcher.RemoveAction(EventKeys.NoticeC7 + myGuid);
            base.SelfDestroy();
        }
        public override void UseWaste()
        {
            //EventDispatcher.RemoveAction(EventKeys.NoticeC7 + myGuid);
            base.UseWaste();
        }

        ToolBox toolbox = new ToolBox();
    }
    public class C7Pack
    {
        public BattleChar Attacker { get; set; }
        public List<BattleChar> SaveTargets { get; set; }
        public Skill skill { get; set; }
        public Guid id { get; set; }
    }
}
