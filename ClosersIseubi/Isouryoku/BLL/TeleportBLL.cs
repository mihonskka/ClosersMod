using ClosersIseubi.Isouryoku.IBLL;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Service;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Isouryoku.BLL
{
    public abstract class TeleportBLL:IsouryokuBLL, ITeleportBLL
    {
        /// <summary>
        /// 【飞雷神准备】每一层改为15%全抵抗、15%闪避率；
        /// </summary>
        /// <returns></returns>
        public virtual bool LV1_IraishinMode()
        {
            return true;
        }
        /// <summary>
        /// 自身受攻击概率增加；
        /// </summary>
        /// <returns></returns>
        public virtual void LV1_Passive(Passive_Char p)
        {
            p.PlusStat.AggroPer = 10;
        }
        /// <summary>
        /// 【飞雷神信标】可以将受到的伤害增加25%
        /// </summary>
        /// <returns></returns>
        public virtual Buff LV2_Beacon(Buff Beacon)
        {
            Beacon.PlusStat.DMGTaken = 25f;
            return Beacon;
        }
        public virtual void LV2_Kill(BattleChar iseubi)
        {
            var sc4 = Skill.TempSkill(IseubiKeyWords.C_iseubi4, iseubi, iseubi.MyTeam);
            sc4.APChange = 1;
            sc4.AutoDelete = 2;
            sc4.isExcept = true;
            iseubi.MyTeam.Add(sc4,true);
        }
        /// <summary>
        /// 拥有【飞雷神准备】并成功闪避时，可以选择一张手牌中自身的牌不消耗法力直接打出；
        /// </summary>
        /// <returns></returns>
        public virtual bool LV3()
        {
            return true;
        }
        /// <summary>
        /// 若碎片数量达到15，下一次攻击将额外消耗5碎片并且造成攻击力50%的额外伤害；
        /// </summary>
        public virtual int LV4(int damage, BattleChar iseubi,bool view)
        {
            if (IseubiService.GetChipNum(iseubi) >= 20)
            {
                clog.iw($"空间四级-增加伤害,view:{view}");
                if(!view) IseubiService.reduceChipWithBuff(-8, iseubi);
                return damage += (int)(iseubi.GetStat.atk * 0.5);
            }
            return damage;
        }
        /// <summary>
        /// 闪避时，将清空自身的痛苦减益并永久提升4%攻击力；
        /// </summary>
        /// <returns></returns>
        public virtual bool LV5()
        {
            return true;
        }
    }
}
