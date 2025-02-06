using ClosersIseubi.Models;
using ClosersFramework;
using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Templates;

namespace ClosersIseubi.Buffs
{
    public class B_LethalStrike : ClosersBaseBuff
    {
        public override void Init()
        {
            base.Init();

            if (GlobalSetting.Allin)
            {
                this.PlusStat.cri = this.StackNum * 5f;
                this.PlusStat.PlusCriDmg = this.StackNum * 8f;
            }
            else
            {
                this.PlusStat.cri = this.StackNum * 3f;
                this.PlusStat.PlusCriDmg = this.StackNum * 5f;
            }
        }
    }
    public class B_LethalStrikeEX : Buff,IP_BuffAdd,IP_PlayerTurn_1
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar &&addedbuff.BuffData.Key!= "B_Neardeath" && addedbuff.BuffData.Debuff && this.StackNum>=4 && !used)
            {
                used = true;
                //addedbuff.LifeTime = 0;
                addedbuff.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();

                var tips = new TranslationItem()
                {
                    
                    SimplifiedChinese = "无懈可击！",
                    TraditionalChinese = "無懈可擊！",
                    English = "Imagine Break!",
                    Japanese = "無駄無駄！",
                    Korean = "쓸모없다！"
                };
                EffectView.SimpleTextout(this.BChar.transform, tips.TransToLocalization, 1f, false, 1f);
            }
        }

        public void Turn1()
        {
            this.used = false;
        }

        bool used = false;

        public override void Init()
        {
            base.Init();
            if (GlobalSetting.Allin)
            {
                this.PlusStat.cri = this.StackNum * 6f;
                this.PlusStat.PlusCriDmg = this.StackNum * 9f;
                
            }
            else
            {
                this.PlusStat.cri = this.StackNum * 3f;
                this.PlusStat.PlusCriDmg = this.StackNum * 5f;
            }
        }
    }
}
