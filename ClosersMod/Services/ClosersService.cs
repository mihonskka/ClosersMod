using ClosersFramework.Data;
using ClosersFramework.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Services
{
    public interface IP_ClosersRebirthInBattle
    {
        void OnRebirthInBattle(BattleChar c, double healHP = 0.5);
	}
	public interface IP_ClosersRebirthInBattle_After
	{
		void OnRebirthInBattleAfter(BattleChar c, double healHP = 0.5);
	}

	public static class ClosersService
    {
        public static void Rebirth(BattleChar c,double healHP = 0.5)
        {
            clog.w("rebirth-c:" + c.Info.KeyData);
            
   //         if (BattleSystem.instance != null)
   //         {
				
			//}
			//BattleSystem.instance.IReturn<IP_ClosersRebirthInBattle>().ForEach(t => t.OnRebirthInBattle(c, healHP));

			c.IsDead = false;
			clog.w("rebirth-c33");
			c.Info.Incapacitated = false;
			clog.w("rebirth-c35");
			c.Info.Hp = (int)(c.Info.get_stat.maxhp * healHP);
			clog.w("rebirth-c37");
			c.Recovery = c.Info.Hp;
			clog.w("rebirth-c39");
			c.IsDead = false;
			clog.w("rebirth-c41");
			c.Info.Incapacitated = false;
			clog.w("rebirth-c43");
			BattleSystem.instance.AllyTeam.Skills_Deck.AddRange(c.Skills.Select(u => u.CloneSkill(false, null, u.AllExtendeds, false)));

			var MyBT = new BattleText();
			MyBT = BattleText.CustomText(c.GetTopPos(), ClosersExtendText.RebirthInBattleText[c.Info.KeyData].NextRandom().TransToLocalization);

			
			if (MyBT != null)
            {
                BattleSystem.instance.StartCoroutine(new IEnumToolBoxForClosersService().RebirthTextClose(MyBT));
            }
			//BattleSystem.instance.IReturn<IP_ClosersRebirthInBattle_After>().ForEach(t => t.OnRebirthInBattleAfter(c, healHP));

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
