using ClosersFramework.Data;
using ClosersFramework.Templates;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_PursueAndAttack : ClosersBaseBuff, IP_Targeted
    {

        public void Targeted(Skill SkillD, List<BattleChar> Targets)
        {
            if(SkillD.Master.HP <= SkillD.Master.Info.BeforeMaxHP*0.10)
            {
                SkillD?.AllExtendeds.Clear();
                //var nullMS = toolbox.DeepClone(SkillD.MySkill);
                var nullMS = SkillD.MySkill.DeepClone();
                //var nullMS = new GDESkillData(ShareSkill.MySkill.Key);
                if (nullMS.Effect_Target != null) nullMS.Effect_Target.DMG_Base = 0;
                if (nullMS.Effect_Target != null) nullMS.Effect_Target.DMG_Per = 0;
                try
                {
                    nullMS?.Effect_Target?.Buffs?.Clear();
                    nullMS?.Effect_Target?.BuffPlusTagPer?.Clear();
                    nullMS?.SkillExtended?.Clear();
                    nullMS?.SKillExtendedItem?.Clear();
                }
                catch { }
                SkillD.MySkill = nullMS;
                var iseubi = IseubiService.FindIseubiInBattle();
                /*if (iseubi!=null)
                {
                    ((iseubi as BattleAlly).Info.Passive as P_Iseubi).NeedReloadEnemySkills = true;
                }*/
                TurnResetInfo.NeedReloadEnemySkill = true;
                
            }
        }
        public override void SelfdestroyPlus()
        {
            BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => t.Skills = Skill.CharToSkills(t, BattleSystem.instance.EnemyTeam));
            base.SelfdestroyPlus();
        }
        ToolBox toolbox = new ToolBox();
    }
}
