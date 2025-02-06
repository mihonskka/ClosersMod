using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_MultiGravity : ClosersBaseBuff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.spd = -2;
            this.PlusStat.RES_CC = -35;
            this.PlusStat.dod = -50;
            this.PlusStat.DMGTaken = (float)Math.Log(this.BChar?.HP ?? 0) * 5;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            this.PlusStat.DMGTaken = (float)Math.Log(this.BChar?.HP ?? 0) * 5;
        }
    }
}
