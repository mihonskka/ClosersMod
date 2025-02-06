using ClosersIseubi.Service;
using static ClosersFramework.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersIseubi.Buffs.IBLL;
using ClosersIseubi.Isouryoku.IBLL;
using ClosersIseubi.Buffs.BLL;
using ClosersIseubi.Isouryoku.BLL;
using ClosersIseubi.Models;
using ClosersIseubi.KeyWords;
using ClosersFramework.Service;

namespace ClosersIseubi.Isouryoku
{
    public class Electrical : ElectricalBLL
    {
        public Electrical()
        {
            base.ConfigList = new List<AuthorityConfigItem>()
            {
                new AuthorityConfigItem(){ Name=nameof(LV1), needExp=4, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV1EC), needExp=4, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV1Desc), needExp=4, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV2), needExp=8, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV2Desc), needExp=8, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV3_ES), needExp=12, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV3_StormEye), needExp=12, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV3Desc), needExp=12, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV4), needExp=16, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV4Desc), needExp=16, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV5), needExp=20, sect=CardType.Electrical },
                new AuthorityConfigItem(){ Name=nameof(LV5Desc), needExp=20, sect=CardType.Electrical },
            };
        }
        /// <summary>
        /// 战斗开始时，增加3碎片
        /// </summary>
        /// <param name="iseubi"></param>
        public override void LV1(BattleChar iseubi)
        {
            if (base.CheckAuthority(nameof(LV1)))
                base.LV1(iseubi);
        }
        public override bool LV1EC()
        {
            if(base.CheckAuthority(nameof(LV1EC))) return base.LV1EC();
            return false;
        }
        /// <summary>
        /// 每当增加致命打击时，改为增加致命打击EX
        /// </summary>
        /// <param name="iseubi"></param>
        /// <param name="LethalStrike"></param>
        public override void LV2(BattleChar iseubi)
        {
            if (base.CheckAuthority(nameof(LV2)))
                base.LV2(iseubi);
        }

        /// <summary>
        /// 初始化时判断，电磁枪生成时判断，电磁枪前两次攻击消耗的法力值-1，且无视嘲讽
        /// </summary>
        /// <param name="ElectricShock"></param>
        public override void LV3_ES(Skill ElectricShock, int counter)
        {
            if (base.CheckAuthority(nameof(LV3_ES)))
                base.LV3_ES(ElectricShock, counter);
        }
        /// <summary>
        /// 命中时判断，风暴之眼命中后不解除
        /// </summary>
        public override bool LV3_StormEye()
        {
            if (base.CheckAuthority(nameof(LV3_StormEye)))
                return base.LV3_StormEye();
            return false;
        }

        /// <summary>
        /// 若发现自身没有碎片，则为自己增加1个碎片
        /// </summary>
        /// <param name="iseubi"></param>
        public override void LV4(BattleChar iseubi)
        {
            if (ThrottleService.SearchRegistration(ThrottleKeyWords.EMFLV4)?.isTimeout ?? true)
            {
                if (base.CheckAuthority(nameof(LV4)))
                    base.LV4(iseubi);
                ThrottleService.AddRegistrationMilliSeconds(ThrottleKeyWords.EMFLV4, 500);
            }
        }
        /// <summary>
        /// 任意非痛苦伤害均可触发【闪电链】的效果；若场上拥有【闪电链】的单位不多于2，则【闪电链】的伤害提升至25%；
        /// </summary>
        /// <returns></returns>
        public override bool LV5()
        {
            if (base.CheckAuthority(nameof(LV5)))
                return base.LV5();
            return false;
        }
        public override bool LV1Desc() => base.CheckAuthority(nameof(LV1Desc));
        public override bool LV2Desc() => base.CheckAuthority(nameof(LV2Desc));
        public override bool LV3Desc() => base.CheckAuthority(nameof(LV3Desc));
        public override bool LV4Desc() => base.CheckAuthority(nameof(LV4Desc));
        public override bool LV5Desc() => base.CheckAuthority(nameof(LV5Desc));
    }
}
