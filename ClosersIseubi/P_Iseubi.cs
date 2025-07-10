using ClosersIseubi.Cards;
using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Templates;
using ChronoArkMod;
using ClosersFramework.Data;
using ToolBox = ClosersIseubi.Service.ToolBox;
using ChronoArkMod.ModData;
using ClosersIseubi.FrontScripts;
using UnityEngine;
using System.Xml.Serialization;

namespace ClosersIseubi
{
    public class P_Iseubi : Passive_Char, IP_SpecialEnemyTargetSelect, IP_SkillUseHand_Team, IP_Discard, IP_SkillUse_User_After, IP_BattleStart_Ones, IP_BattleEnd, IP_TargetedAlly, IP_PlayerTurn_1, IP_Draw, IP_WaitButton, IP_DamageChange, IP_UsedDeckToDeck, IP_Dodge, IP_BuffUpdate, IP_BuffRemove, IP_BuffAdd, IP_Dead, IP_ClosersRebirthInBattle_After
    {
        readonly ToolBox toolBox = new ToolBox();
        readonly Electrical EMF = new Electrical();
        readonly Gravity Gra = new Gravity();
        readonly Pluralism Plu = new Pluralism();
        readonly Teleport Tel = new Teleport();

        /// <summary>
        /// 对于拥有标记的目标，无视嘲讽
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public bool SpecialEnemyTargetSelect(Skill skill, BattleEnemy Target)
        {
            if (skill.Master == this.BChar)
            {
                return Target.BuffFind(IseubiKeyWords.birsb, false) || (skill.MySkill.KeyID == IseubiKeyWords.C_iseubi8 && this.BChar.BuffFind(IseubiKeyWords.birsm));
            }

            return false;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if ((this.BChar.MyTeam.Skills_Basic.FirstOrDefault(t => t.Master == this.BChar).MySkill.KeyID == IseubiKeyWords.C_iseubi0) && !skill.PlusHit)
                IseubiService.checkLawDaggereAbility(skill, this.BChar);
            if (((this.BChar as BattleAlly).BasicSkill.MySkill.KeyID == IseubiKeyWords.C_iseubi4 && skill.Master == this.BChar) && !skill.PlusHit)
                IseubiService.checkWarmHoleAbility(skill, this.BChar);
        }



        public void BattleStart(BattleSystem Ins)
        {
            if (Ins != null)
            {
				var _ProgressBar = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(IseubiKeyWords.Closers_Sylvi_ProgressBar).Gameobject_Path, AddressableLoadManager.ManageType.Character);
				_ProgressBar.transform.SetParent(this.BChar.transform, false);
                _ProgressBar.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                _ProgressBar.transform.position += new Vector3(0.05f * 22, 0.1f * 12, 0);
				ProgressBar = _ProgressBar.AddComponent<ProgressBar_Sylvi_Script>();
				//_ProgressBar.AddComponent<SandAnimation>();
				ProgressBar.ChangeNumber(IseubiService.GetChipNum());



				Ins.AllyTeam.AliveChars.ForEach(t =>
                {
                    if (t != this.BChar)
                        t.BuffAdd(IseubiKeyWords.bipb, this.BChar);
                });
                Ins.AllyTeam.LucyChar.BuffAdd(IseubiKeyWords.bipb, this.BChar);
                Ins.AllyTeam.LucyChar.BuffAdd(IseubiKeyWords.B_LucyiseubiProxyBuff, this.BChar);

                //clog.w("清空神罗天征的消息注册");
                //EventDispatcher.PrefixRemove(EventKeys.NoticeC7);
                EMF.LV1(this.BChar);
                Gra.LV4_PlusCCHit(this.BChar);
                if (!Plu.LV0Desc())
                {
                    this.BChar.MyTeam.Skills.RemoveAll(t => t.MySkill.KeyID == IseubiKeyWords.CL_iseubi1);
                    this.BChar.MyTeam.ALLSKILLLIST.RemoveAll(t => t.MySkill.KeyID == IseubiKeyWords.CL_iseubi1);
                    this.BChar.MyTeam.Skills_Deck.RemoveAll(t => t.MySkill.KeyID == IseubiKeyWords.CL_iseubi1);
                    PlayData.TSavedata.LucySkills.RemoveAll(t => t == IseubiKeyWords.CL_iseubi1);
                    Plu.LV0_Immediate_Activate();
                }
                /*else
                {
                    #region 任务手册模块
                    var mypluginP1 = PluginUnitService.GetPlugin(PluginKeyWords.TaskHandbook) as TaskHandbookPlugin;
                    mypluginP1.Init(new TaskHandBookConfig()
                    {
                        PageList = new List<TaskHandBookPage>
                    {
                        new TaskHandBookPage()
                        {
                            TaskName = TaskHandBookKeyWords.PluLV1ISkill,
                            EventId = EventKeys.PluLV1ISkill,
                            InvokeAction = () =>
                            {
                                new Pluralism().LV1_Immediate();
                            }
                        }
                    }
                    });
                    mypluginP1.Invoke();
                    #endregion
                }
                */
            }
        }
		[XmlIgnore]
		public ProgressBar_Sylvi_Script ProgressBar { get; set; }
		public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            if (this.MyChar != null)
            {
                ExpService.PassiveDescCheckOutBattle(ref IseubiService.FindIseubiPDBattleAlly().Info);
            }

            Tel.LV1_Passive(this);
            /*
            clog.w($"battleallynum:{PlayData.Battleallys.Count}");
            
            clog.w($"fioi:{IseubiService.FindIseubiOutInvest() == null}");
            if (BattleSystem.instance == null)
                ExpService.PassiveDescCheckOutBattle(ref IseubiService.FindIseubiOutInvest().Info);
            else
                this.BChar.Info.PassiveDes = ExpService.PassiveDescCheck(this.BChar);
            */
        }

        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (skill.Master != this.BChar) IseubiService.addChip(1, this.BChar);
        }

        public void SkillUseAfter(Skill SkillD)
        {
            if (SkillD.Master != this.BChar && !SkillD.PlusHit) IseubiService.addChip(1, this.BChar, this.BChar);
        }

        public void BattleEnd()
        {
            clog.iw("战斗胜利！");
            ExpService.AddExp();
            clog.iw("刷新被动能力描述");
            ExpService.PassiveDescCheckOutBattle(ref IseubiService.FindIseubiPDBattleAlly().Info);

            if (BattleSystem.instance.CurseBattle)
            {
                Plu.LV3_AfterBattle();
            }

            //clog.w("清空神罗天征的消息注册");
            //EventDispatcher.PrefixRemove(EventKeys.NoticeC7);
            EventDispatcher.ClearInBattleAction();
            //Electrical
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            clog.iw("被选中！");

            var BAiseubi = (this.BChar as BattleAlly);
            var ShinratenseInHand = this.BChar.MyTeam.Skills?.FirstOrDefault(t => t?.MySkill?.KeyID == IseubiKeyWords.C_iseubi7);
            var ShinratenseBasic = this.BChar.MyTeam.Skills_Basic?.FirstOrDefault(u => u?.MySkill?.KeyID == IseubiKeyWords.C_iseubi7);
            if (ShinratenseInHand != null || (ShinratenseBasic != null&&((!BAiseubi.MyBasicSkill?.InActive)??false)))
            {
                var sendId = ShinratenseInHand ?? ShinratenseBasic;
                clog.iw("打包消息并进行前缀分发");
                var c7pack = new C7Pack()
                {
                    Attacker = Attacker,
                    SaveTargets = SaveTargets,
                    skill = skill,
                    id = (sendId.AllExtendeds.FirstOrDefault(t => t is C_iseubi7) as C_iseubi7).myGuid
                };
                clog.iw($"打包完成，id为{c7pack.id}");
                EventDispatcher.Dispatch(IseubiEventKeys.NoticeC7, c7pack);
            }
            yield break;
        }

        public void Turn1()
        {
            Plu.LV1(this.BChar.MyTeam.Skills);

            var BAiseubi = (this.BChar as BattleAlly);
            /*if ((this.BChar.MyTeam?.Skills?.Any(t => t?.MySkill?.KeyID == IseubiKeyWords.C_iseubi7) ?? false) || (BAiseubi.BasicSkill.MySkill.KeyID == IseubiKeyWords.C_iseubi4 && !BAiseubi.MyBasicSkill.InActive))
            {
                EventDispatcher.Dispatch(EventKeys.ReNoticeC7);
            }*/

            var mybasic = BattleSystem.instance.AllyTeam.Skills_Basic.FirstOrDefault(t => t.Master == this.BChar);
            
            if (mybasic == null) return;
            var whitelist = new List<string>(){
                IseubiKeyWords.C_iseubi0, IseubiKeyWords.C_iseubi4, IseubiKeyWords.C_iseubi7
            };

            if ((this.BChar as BattleAlly).MyBasicSkill.CoolDownNum < 1 && whitelist.Contains(mybasic.MySkill.KeyID))
            {
                //CharacterService.RefreshBasicSkill(this.BChar, this.BChar.BattleBasicskillRefill);
                ClosersService.RefreshBasicSkill(this.BChar, BattleSystem.instance.AllyTeam.Skills_Basic.FirstOrDefault(t=>t.Master==this.BChar));
            }


        }
        //public bool NeedReloadEnemySkills { get;set; }=false;
        public IEnumerator Draw(Skill Drawskill, bool NotDraw)
        {            
            var BAiseubi = (this.BChar as BattleAlly);
            if ((this.BChar.MyTeam?.Skills?.Any(t => t?.MySkill?.KeyID == IseubiKeyWords.C_iseubi7)??false) || (BAiseubi.BasicSkill.MySkill.KeyID == IseubiKeyWords.C_iseubi4 && !BAiseubi.MyBasicSkill.InActive))
            {
                EventDispatcher.Dispatch(IseubiEventKeys.ReNoticeC7);
            }
            yield return null;
        }

        public override void FixedUpdate()
        {
            EMF.LV4(this.BChar);
            base.FixedUpdate();
            if (Tel.LV5()) LV5Check();
        }

        public void UseWaitButton()
        {
            Plu.LV2();
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if(SkillD.IsDamage && !Target.Info.Ally)
                Damage = new Teleport().LV4(Damage, this.BChar, View);
            return Damage;
        }

        public IEnumerator UsedDeckToDeck()
        {
            if (Plu.LV5())
            {
                this.BChar.MyTeam.AliveChars.ForEach(t => t.Overload = 0);
                this.BChar.MyTeam.Draw(this.BChar.MyTeam.Chars.Count);
                this.BChar.MyTeam.AP = this.BChar.MyTeam.MAXAP;
            }
            yield return null;
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            DodgeCount++;
            if (Tel.LV5())
            {
                this.BChar.Buffs.Where(t => t.BuffData.Debuff).ToList().ForEach(t => t.SelfDestroy());
                LV5Check();
            }
        }
        void LV5Check() => this.PlusPerStat.Damage = 2 * DodgeCount;

        public void BuffUpdate(Buff MyBuff)
        {
            if (MyBuff.BuffData.Key == IseubiKeyWords.bc)
            {
                if (ProgressBar != null)
                {
                    ProgressBar.ChangeNumber(IseubiService.GetChipNum(), IseubiService.GetChipBuff());
                }
            }
        }

        public void BuffRemove(BattleChar buffMaster, Buff buff)
        {
            if (buff.BuffData.Key == IseubiKeyWords.bc && buffMaster == this.BChar)
            {
                if (ProgressBar != null)
                {
					ProgressBar.ChangeNumber(IseubiService.GetChipNum(), IseubiService.GetChipBuff());
				}
            }
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (addedbuff.BuffData.Key == IseubiKeyWords.bc)
            {
                if (ProgressBar != null)
                {
					ProgressBar.ChangeNumber(IseubiService.GetChipNum(), IseubiService.GetChipBuff());
				}
            }
        }

		public void Dead()
		{
			if (ProgressBar != null)
			{
                ProgressBar.Hide();
			}
		}

		public void OnRebirthInBattleAfter(BattleChar c, double healHP = 0.5)
		{
			if (ProgressBar != null)
			{
				ProgressBar.Show();
			}
		}

		public int DodgeCount { get; set; }
    }
}
