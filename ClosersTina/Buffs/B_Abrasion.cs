using ClosersFramework.Models;
using ClosersFramework.Templates;
using ClosersTina.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Buffs
{
    public class B_Abrasion : ClosersBaseBuff, IP_PlayerTurn_1
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = (int)(-0.5 * this.StackNum);
            this.PlusPerStat.MaxHP = (int)(-1 * this.StackNum);

        }

        public override string ClosersDesc(string desc)
        {
            if (this.StackNum >= 10)
                return desc + "\n" + descExt.TransToLocalization;
            return desc;
        }

        TranslationItem descExt = new TranslationItem()
        {
            
            SimplifiedChinese = "每到偶数回合，过热量+1。",
            TraditionalChinese = "每到偶數回合，過熱量+1。",
            English = "",
            Japanese = "",
            Korean = ""
        };

        public void Turn1()
        {
            if (this.StackNum >= 10 && BattleSystem.instance.TurnNum > 0 && BattleSystem.instance.TurnNum % 2 == 0)
                this.BChar.BuffAdd(TinaKeyWords.B_Overheat, this.BChar);
        }
    }
}
