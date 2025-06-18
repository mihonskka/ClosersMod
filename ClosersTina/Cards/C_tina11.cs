using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Services;
using ClosersFramework.Service.CodeManager;
using ClosersTina.KeyWords;
using GameDataEditor;

namespace ClosersTina.Cards
{
    /// <summary>
    /// Defibrillator
    /// </summary>
    public class C_tina11 : TinaBaseCard
    {
        public C_tina11() : base(false) { }
        [AccidentProne]
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            var allytargets = this.BChar.MyTeam.Chars.ToList();
            var list = new List<Skill>();
            foreach (var battleChar in allytargets)
            {
                Skill skill = Skill.TempSkill(TinaKeyWords.C_tina11_Target, battleChar, battleChar.MyTeam);
                list.Add(skill);
            }
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), "", false, false, true, false, true));



            base.SkillUseSingle(SkillD, Targets);
            /*if (Targets.Any(t => t.IsDead))
            {
                Targets.ForEach(t =>
                {
                    t.IsDead = false;
                    t.HP = (int)(t.Info.get_stat.maxhp * 0.5);
                    t.Recovery = t.HP;
                    this.MySkill.MyTeam.Skills_Deck.AddRange(t.Skills.Select(u => u.CloneSkill(false, null, u.AllExtendeds, false)));
                });
            }
            else
                Targets.Where(t => t.HP < t.Recovery && t.HP < 0).ToList().ForEach(t => t.Heal(this.BChar, t.Recovery - t.HP, false, false, null));
            */
        }

        [AccidentProne]
        public void Del(SkillButton Mybutton)
        {
            var target = Mybutton.Myskill.Master;

            if(target.IsDead)
                ClosersService.Rebirth(target, 0.5);
            else if(target.HP<0)
                target.Heal(this.BChar, target.Recovery - target.HP, false, false, null);

            //Skill skill = Skill.TempSkill(GDEItemKeys.Skill_S_LBossFirst_2_Plus_Hit, this.BChar, this.BChar.MyTeam);
            //this.BChar.ParticleOut(skill, Mybutton.Myskill.Master);
            //Mybutton.Myskill.Master.BuffAdd(GDEItemKeys.Buff_B_LBossFirst_2_T, this.BChar, false, 0, false, -1, false);
        }
    }
}
