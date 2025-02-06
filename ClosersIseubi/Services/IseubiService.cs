using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using ClosersFramework.Service.CodeManager;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Service
{
    public static class IseubiService
    {
        public static bool ClearChip() => ClearChip(FindIseubiInBattle());
        public static bool ClearChip(BattleChar bc)
        {
            try
            {
                bc?.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.SelfDestroy();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool reduceHalfChipWithBuff(BattleChar bc)
        {
            var rv = reduceHalfChip(FindIseubiInBattle());
            if (rv) bc?.BuffAdd(IseubiKeyWords.bls, bc);
            return rv;
        }
        public static bool reduceHalfChipWithBuff() => reduceHalfChipWithBuff(FindIseubiInBattle());
        public static bool reduceHalfChip() => reduceHalfChip(FindIseubiInBattle());
        public static bool reduceHalfChip(BattleChar bc)
        {
            try
            {
                int count = bc?.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.StackNum ?? 0;
                reduceChip(-(count / 2), bc);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 战斗时存活成员中寻找李瑟钰
        /// </summary>
        /// <returns></returns>
        public static BattleChar FindIseubiInBattle() => BattleSystem.instance?.AllyTeam?.AliveChars?.FirstOrDefault(t => t.Info.KeyData == IseubiKeyWords.Iseubi);

        public static Character FindIseubiInInvest() => PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == IseubiKeyWords.Iseubi);
        /// <summary>
        /// 战斗时所有成员中寻找李瑟钰
        /// </summary>
        /// <returns></returns>
        public static BattleAlly FindIseubiPDBattleAlly() => PlayData.Battleallys.FirstOrDefault(t => t.Info.KeyData == IseubiKeyWords.Iseubi);
        public static GDECharacterData FindIseubiOriginal()
        {
            var iseubi = new GDECharacterData(IseubiKeyWords.Iseubi);
            if (!iseubi.Off) return iseubi;
            return null;
        }

        public static int GetChipNum() => GetChipNum(FindIseubiInBattle());
        public static int GetChipNum(BattleChar bc) => bc?.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.StackNum ?? 0;
        public static bool addChip(int a, BattleChar bc) => addChip(a, FindIseubiInBattle(), bc);
        public static bool addChip(int a, BattleChar iseubi, BattleChar bc)
        {
            try
            {
                for (var i = 0; i < a; i++)
                {
                    if (GetChipNum(iseubi) < 25)
                        iseubi?.BuffAdd(IseubiKeyWords.bc, bc);
                    else
                    {
                        clog.iw("为露西增加魔法碎片");
                        BattleSystem.instance.AllyTeam.LucyChar.BuffAdd(IseubiKeyWords.blmc, iseubi);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool addChipWithBuff(int a, BattleChar bc)
        {
            var iseubi = FindIseubiInBattle();
            var rv = addChip(a, iseubi, bc);
            if (rv) iseubi?.BuffAdd(IseubiKeyWords.bls, bc);
            return rv;
        }
        public static bool addChipWithBuff(int a, BattleChar iseubi, BattleChar bc)
        {
            var rv = addChip(a, iseubi, bc);
            if (rv) iseubi?.BuffAdd(IseubiKeyWords.bls, bc);
            return rv;
        }
        public static bool reduceChip(int a) => reduceChip(a, FindIseubiInBattle());
        public static bool reduceChip(int a, BattleChar Iseubi)
        {
            try
            {
                if (GetChipNum(Iseubi) >= -a)
                {
                    clog.iw("이슬비：正在消耗碎片");
                    for (var i = 0; i < -a; i++)
                        Iseubi?.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.SelfStackDestroy();
                }
                else Iseubi?.Buffs?.FirstOrDefault(t => t.BuffData.Key == IseubiKeyWords.bc)?.SelfDestroy();
                new Pluralism().LV2();
                return true;
            }
            catch { return false; }
        }
        public static bool reduceChipWithBuff(int a)
        {
            var iseubi = FindIseubiInBattle();
            var rv = reduceChip(a, iseubi);
            if (rv) iseubi?.BuffAdd(IseubiKeyWords.bls, iseubi);
            return rv;
        }
        public static bool reduceChipWithBuff(int a, BattleChar iseubi)
        {
            var rv = reduceChip(a, iseubi);
            if (rv) iseubi?.BuffAdd(IseubiKeyWords.bls, iseubi);
            return rv;
        }

        public static bool addIraishinBeacon(BattleChar user, BattleChar target, int tagPer = 500)
        {
            try
            {
                target.BuffAdd(IseubiKeyWords.birsb, user, PlusTagPer: tagPer);
                return true;
            }
            catch { return false; }
        }


        public static void checkWarmHoleAbility(Skill skill, BattleChar iseubi)
        {
            clog.iw($"检测固定能力的虫洞穿梭");
            var BAiseubi = (iseubi as BattleAlly);
            if (BAiseubi.BasicSkill.MySkill.KeyID == IseubiKeyWords.C_iseubi4 && !skill.PlusHit && skill.MySkill.KeyID != IseubiKeyWords.C_iseubi4 && BAiseubi.MyBasicSkill.InActive)
                iseubi.BuffAdd(IseubiKeyWords.B_iseubi4, iseubi);
        }
        public static void checkLawDaggereAbility(Skill skill, BattleChar iseubi)
        {
            var toolBox = new ToolBox();
            clog.iw($"使用的牌KeyID为{skill.MySkill.KeyID}，{toolBox.IsSpendChip(skill.MySkill.KeyID)}");
            if (toolBox.IsSpendChip(skill.MySkill.KeyID))
            {
                clog.iw("检测到使用碎片消耗技能，尝试刷新固定能力");
                iseubi.MyTeam.BasicSkillRefill(iseubi, iseubi.BattleBasicskillRefill);
            }
        }

        public static void addLSBuff(int a, BattleChar iseubi)
        {
            for(int i = 0; i < a; i++)
            {
                iseubi.BuffAdd(IseubiKeyWords.bls, iseubi);
                new Electrical().LV2(iseubi);
            }
        }

        /// <summary>
        /// 判断原理为 先判断是是否有BattleChar 若可取到，则判断是否为李瑟钰
        /// 若无法取到BattleChar，则以位置进行判断，战斗内用立体向量（Vector3），战斗外用变形（Transform）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool isIseubi(ICharacterSoundsToken model) => model.ComponentMaster?.Info?.KeyData == IseubiKeyWords.Iseubi || ((BattleSystem.instance != null) ? model.ComponentCoordinate.IsAdjacentVector((FindIseubiInBattle() as BattleAlly)?.GetTopPos()) : model.ComponentTransform.localPosition.IsAdjacentVector(FindIseubiInInvest()?.GetAllyWindow?.TextPos?.localPosition));
        /*
         * public static bool isIseubi(ISoundsComponent model)
        {
            if (model.ComponentMaster?.Info?.KeyData == IseubiKeyWords.Iseubi)
                return true;
            if (BattleSystem.instance != null)
            {
                return model.ComponentCoordinate.IsAdjacentVector(FindIseubiInBattle()?.GetPos());
            }
            else
            { 
                return model.ComponentTransform == FindIseubiInInvest()?.GetAllyWindow?.TextPos;
            };
        }
        */
        [NoReference]
        public static Skill clearCreateSign(Skill skill)
        {
            skill.AllExtendeds.RemoveAll(t => t.Data.Key == GDEItemKeys.SkillExtended_SilverStein_Ex_0 || t.Data.Key == GDEItemKeys.SkillExtended_Mement_Ex_0);
            return skill;
        }
        [NoReference]
        public static async Task clearSignAsync(Skill skill)
        {
            await Task.Delay(200);
            skill.AllExtendeds.RemoveAll(t => t.Data.Key == GDEItemKeys.SkillExtended_SilverStein_Ex_0 || t.Data.Key == GDEItemKeys.SkillExtended_Mement_Ex_0);
        }
        /*
        public static void changeChipNum(int a,BattleChar bc)
        {
            if (a == 0) return;
            
            if (a > 0)
            {
                for(var i =0;i<a;i++)
                {
                   Iseubi.BuffAdd(KeyWords.bc, bc);
                }
            }
            else
            {

            }
        }*/

        public static bool CheckPresence(bool inBattle)
        {
            bool cont = false;
            if (FindIseubiInInvest() != null)
            {
                if (inBattle)
                {
                    if (FindIseubiInBattle() != null)
                        cont = true;
                }
                else
                    cont = true;
            }
            return cont;
        }
    }
}
