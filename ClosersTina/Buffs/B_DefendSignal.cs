using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Buffs
{
    public class B_DefendSignal : ClosersBaseBuff, IP_Dodge
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = 30 * this.StackNum;
            this.PlusStat.Strength = true;
        }
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (this.BChar.MyTeam.AliveChars.All(t => t.Info.GetData.Role.Key != "Role_Tank"))
            {
                var addBarrier = (int)(SP.SkillData.TargetDamage * SP.UseStatus.GetStat.atk) + 1;
                this.BChar.MyTeam.partybarrier.BarrierHP += addBarrier;
            }

        }
    }
}
