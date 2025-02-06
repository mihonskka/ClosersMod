using ClosersIseubi.Isouryoku.IBLL;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Isouryoku.BLL
{
    public abstract class ElectricalBLL :IsouryokuBLL, IElectricalBLL
    {
        public virtual void LV1(BattleChar iseubi)
        {
            clog.iw("闪电一级-增加碎片！");
            IseubiService.addChip(3, iseubi);
        }

        public virtual bool LV1EC()
        {
            return true;
        }

        public virtual void LV2(BattleChar iseubi)
        {
            clog.iw("闪电二级-替换致命打击！");
            iseubi.BuffRemove(IseubiKeyWords.bls);
            iseubi.BuffAdd(IseubiKeyWords.blsex, iseubi);
        }

        public virtual void LV3_ES(Skill ElectricShock, int counter)
        {
            if (counter <= 2)
            {
                ElectricShock.NotCount = true;
                ElectricShock.APChange -= 1;
            }
        }

        public virtual bool LV3_StormEye()
        {
            return true;
        }

        public virtual void LV4(BattleChar iseubi)
        {
            //clog.iw("闪电四级检测一次");
            if (IseubiService.GetChipNum(iseubi) <= 0)
            {
                IseubiService.addChip(1, iseubi);
            }
        }
        /// <summary>
        /// 任意非痛苦伤害均可触发【闪电链】的效果；若场上拥有【闪电链】的单位不多于2，则【闪电链】的伤害提升至25%；
        /// </summary>
        /// <returns></returns>
        public virtual bool LV5()
        {
            return true;
        }
    }
}
