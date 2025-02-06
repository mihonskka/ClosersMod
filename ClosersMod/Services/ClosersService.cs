using ClosersFramework.Data;
using ClosersFramework.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Service
{
    public static class ClosersService
    {
        public static void Rebirth(BattleChar c,double healHP = 0.5)
        {
            var MyBT = new BattleText();
            if (BattleSystem.instance != null)
            {
                c.Info.Hp = (int)(c.Info.get_stat.maxhp * healHP);
                c.Recovery = c.Info.Hp;
                c.IsDead = false;
                BattleSystem.instance.AllyTeam.Skills_Deck.AddRange(c.Skills.Select(u => u.CloneSkill(false, null, u.AllExtendeds, false)));

                MyBT = BattleText.CustomText(c.GetTopPos(), ClosersExtendText.RebirthInBattleText[c.Info.KeyData].NextRandom().TransToLocalization);
            }

            if (MyBT != null)
            {
                BattleSystem.instance.StartCoroutine(new IEnumToolBoxForClosersService().RebirthTextClose(MyBT));
            }

        }

        public static void RefreshBasicSkill(BattleChar bchar,Skill skill)
        {
            if ((bchar as BattleAlly).MyBasicSkill.buttonData == null || (bchar as BattleAlly).MyBasicSkill.ThisSkillUse)
            {
                (bchar as BattleAlly).MyBasicSkill.SkillInput(skill.CloneSkill(false, null, null, false));
            }
            if ((bchar as BattleAlly).MyBasicSkill.ThisSkillUse)
            {
                (bchar as BattleAlly).MyBasicSkill.InActive = false;
                (bchar as BattleAlly).MyBasicSkill.ThisSkillUse = false;
            }
            if ((bchar as BattleAlly).MyBasicSkill.InActive)
            {
                (bchar as BattleAlly).MyBasicSkill.InActive = false;
            }
        }
        public static List<Skill> FindAllySkill(this List<Skill> list, BattleChar ally) => list.Where(t => t.Master == ally).ToList();
        
    }

    public class IEnumToolBoxForClosersService
    {
        public IEnumerator RebirthTextClose(BattleText mybt)
        {
            yield return new WaitForSecondsRealtime(2f);
            mybt.End();
            mybt = null;
            yield break;
        }
    }
}
