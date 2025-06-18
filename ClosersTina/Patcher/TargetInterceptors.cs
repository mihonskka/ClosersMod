using ClosersFramework.Services;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using GameDataEditor;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Patcher
{
    public class TargetInterceptors
    {

    }

    [HarmonyPatch(typeof(BattleSystem), "IsSelect")]
    public class SelectInterceptors
    {
        [HarmonyPostfix]
        public static void Postfix(BattleChar Target, Skill skill, ref bool __result)
        {
            __result = (!__result) ? skill.Master.Info.KeyData == TinaKeyWords.Tina && skill.MySkill.KeyID == TinaKeyWords.C_tina4 && Target.GetStat.Vanish && !Target.Info.Ally && (skill.TargetTypeKey == GDEItemKeys.s_targettype_all_onetarget || skill.TargetTypeKey == GDEItemKeys.s_targettype_all_enemy || skill.TargetTypeKey == GDEItemKeys.s_targettype_enemy || skill.TargetTypeKey == GDEItemKeys.s_targettype_random_enemy || skill.TargetTypeKey == GDEItemKeys.s_targettype_enemy_PlusRandom) && !Target.IsDead && !skill.AllExtendeds.Any(t => t.TargetSelectExcept(Target)) : __result;
        }
    }

    //[HarmonyPatch(typeof(BattleSystem), "ForceAction")]
    public class ForceActionInterceptor
    {
        public static ForceActionInterceptor instance = new ForceActionInterceptor();
        [HarmonyPrefix]
        public static bool Prefix(ref IEnumerator __result, Skill skill, BattleChar Target, bool UseButton, bool Debuff, bool Quick, Skill skilltarget = null)
        {
            __result = instance.ForceAction(skill, Target, UseButton, Debuff, Quick, skilltarget);
            return false;
        }
        public IEnumerator ForceAction(Skill skill, BattleChar Target, bool UseButton, bool Debuff, bool Quick, Skill skilltarget = null)
        {
            if (!UseButton || !(skill.MyButton == null))
            {
                if (!UseButton)
                {
                    skill.FreeUse = true;
                }
                BattleSystem.instance.ActWindow.On = false;
                while (GameObject.FindGameObjectsWithTag("EffectView").Length != 0 || GameObject.FindGameObjectsWithTag("Tutorial").Length != 0 || BattleSystem.instance.ListWait || BattleSystem.instance.Particles.Count != 0)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                skill.ForceAction = true;
                if (skill.Master.Info.Ally)
                {
                    BattleChar.SkillNameOutOrigin(BattleSystem.instance, skill.MySkill.Name, true);
                    BattleSystem.instance.ActWindow.Cast = true;
                    if (!Quick)
                    {
                        GameObject Temptooltip = ToolTipWindow.SkillToolTip(BattleSystem.instance.ActWindow.ItemSkillView, skill, skill.Master as BattleAlly, 0, 1, true, true, false);
                        Temptooltip.transform.SetParent(BattleSystem.instance.ActWindow.ItemSkillView);
                        yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.WaitForSecondSkip(1.5f));
                        UnityEngine.Object.Destroy(Temptooltip);
                        Temptooltip = null;
                    }
                    try
                    {
                        if (skill.IsTargetSkill)
                        {
                            bool flag = false;
                            try
                            {
                                if (Target == null || (Target.GetStat.Vanish && skill.MySkill.KeyID != TinaKeyWords.C_tina4) || Target.IsDead)//there modified
                                {
                                    clog.tw("检测到无目标技能，准备阻止");
                                    flag = true;
                                }
                            }
                            catch
                            {
                            }
                            if (flag)
                            {
                                int num = 0;
                                RandomClass randomClass = RandomClass.CreateRandomClass(skill.Master.GetRandomClass().Target);
                                BattleChar battleChar;
                                for (; ; )
                                {
                                    num++;
                                    battleChar = BattleSystem.instance.GetGlobalChar().Random(randomClass);
                                    if (BattleSystem.IsSelect(battleChar, skill))
                                    {
                                        break;
                                    }
                                    if (num >= 100)
                                    {
                                        goto Block_17;
                                    }
                                }
                                Target = battleChar;
                                goto IL_259;
                            Block_17:
                                BattleSystem.instance.StopCoroutine("ForceAction");
                                BattleSystem.instance.ActWindow.Cast = false;
                            }
                        }
                    IL_259:
                        BattleSystem.instance.ActionAlly = (skill.Master as BattleAlly);
                        BattleSystem.instance.SelectedSkill = skill;
                        if (!Debuff)
                        {
                            BattleSystem.instance.SelectedSkill.FreeUse = true;
                        }
                        if (!skill.IsTargetSkill)
                        {
                            if (skilltarget != null)
                            {
                                BattleSystem.instance.SkillTargetAdd(skilltarget);
                            }
                            else
                            {
                                BattleSystem.instance.SkillTargetAdd(skill);
                            }
                        }
                        else
                        {
                            BattleSystem.instance.SkillTargetAdd(Target);
                        }
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(0.7f);
                    while (BattleSystem.instance.Particles.Count != 0 || GameObject.FindGameObjectsWithTag("EffectView").Length != 0)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    BattleSystem.instance.ActWindow.Cast = false;
                }
                else
                {
                    CastingSkill skill2 = new CastingSkill
                    {
                        skill = skill,
                        Target = Target,
                        Usestate = skill.Master,
                        CastSpeed = 0,
                        IsEnemyForceTarget = true
                    };
                    yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.EnemyActionScene(skill2, false));
                }
            }
            yield break;
        }
    }
}
