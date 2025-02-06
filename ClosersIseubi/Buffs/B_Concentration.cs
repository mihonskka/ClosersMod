using ClosersFramework.Templates;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_Concentration : ClosersBaseBuff, IP_WaitButton,IP_DamageTake
    {
        int hpr { get; set; } = 0;
        int hpg { get; set; } = 0;

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (this.BChar.HP <= 0)
            {
                resist = true;
                this.SelfDestroy();
            }
        }

        public override void Init()
        {
            this.PlusStat.dod = 15;
            this.PlusStat.def = 5;
            this.PlusStat.RES_CC = 50;
            this.PlusStat.RES_DOT = 50;
            this.PlusStat.RES_DEBUFF = 50;
            this.hpr = this.BChar.HP;
            this.hpg = this.BChar.Recovery;
            base.Init();
        }
        public override string ClosersDesc(string desc)
        {
            return desc.Replace("&hpr", hpr.ToString()).Replace("&hpg", (hpg-hpr).ToString());
        }

        public void UseWaitButton()
        {
            this.BChar.Overload = 0;
        }
        public override void SelfdestroyPlus()
        {
            this.BChar.HP = hpr;
            this.BChar.Recovery = hpg;
            base.SelfdestroyPlus();
        }
    }
}
