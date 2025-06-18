using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClosersTina.Buffs
{
    public class B_Overheat : ClosersBaseBuff, IP_BuffAdd, IP_BuffRemove, IP_BuffUpdate
    {
        public decimal dotDmg = (decimal)0.1;
        public void BuffRemove(BattleChar buffMaster, Buff buff)
        {
            BuffCheck();
        }

        public void BuffUpdate(Buff MyBuff)
        {
            BuffCheck();
        }
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Key == this.BuffData.Key && this.StackNum >= 15)
            {
                this.BChar.Damage(this.BChar.MyTeam.LucyChar, (int)(this.BChar.GetStat.maxhp * dotDmg), false, true, false, 0, false, false, false);
            }
            BuffCheck();
        }

        public override void Init()
        {
            base.Init();
            BuffCheck();
        }

        public void BuffCheck()
        {
            this.PlusPerStat.Damage = -2 * this.StackNum;
            if (BattleSystem.instance != null && this.BChar.Overload <= this.StackNum / 5) this.BChar.Overload = this.StackNum / 5;
        }

        public override string ClosersDesc(string desc)
        {            
            var translationItem = new TranslationItem()
            {
                
                SimplifiedChinese = "过载+&a",
                TraditionalChinese = "過載+&a",
                English = "Overload+&a",
                Japanese = "オーバーチャージ Overload+&a",
                Korean = "과부하+&a"
            };

            if (this.StackNum >= 5) desc += "\n" + translationItem.TransToLocalization.Replace("&a", ((int)(this.StackNum / 5)).ToString());
            return desc.Replace("&b", ((int)(this.BChar.GetStat.maxhp * dotDmg)).ToString());
        }
    }
}
