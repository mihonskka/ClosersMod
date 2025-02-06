using ClosersIseubi.Isouryoku.BLL;
using ClosersIseubi.Isouryoku.IBLL;
using ClosersIseubi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;

namespace ClosersIseubi.Isouryoku
{
    public class Gravity:GravityBLL
    {
        public Gravity()
        {
            base.ConfigList = new List<AuthorityConfigItem>()
            {
                new AuthorityConfigItem(){ Name=nameof(LV1), needExp=4, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV1Desc), needExp=4, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV2Desc), needExp=8, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV2_Shinratense), needExp=8, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV2_IgnoreDef), needExp=8, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV3), needExp=12, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV3Desc), needExp=12, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV4_PlusCCHit), needExp=16, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV4_Shinratense), needExp=16, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV4Desc), needExp=16, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV5), needExp=20, sect=CardType.Gravity },
                new AuthorityConfigItem(){ Name=nameof(LV5Desc), needExp=20, sect=CardType.Gravity },
            };
        }

        /// <summary>
        /// 友军被选定为目标时，可以提前打出一张【神罗天征】，让本次攻击无效。若如此做，这张牌将被放逐
        /// </summary>
        public override bool LV1()
        {
            if (base.CheckAuthority(nameof(LV1)))
                return base.LV1();
            return false;
        }
        /// <summary>
        /// 神罗天征可以解除自身的所有减益buff
        /// </summary>
        public override void LV2_Shinratense(BattleChar iseubi)
        {
            if (base.CheckAuthority(nameof(LV2_Shinratense)))
                base.LV2_Shinratense(iseubi);
        }
        /// <summary>
        /// 万象天引将无视防御
        /// </summary>
        public override Skill LV2_IgnoreDef(Skill C6sub)
        {
            if (base.CheckAuthority(nameof(LV2_IgnoreDef)))
                return base.LV2_IgnoreDef(C6sub);
            return C6sub;
        }

        /// <summary>
        /// 戒律之刃段数+1，产生碎片数+1
        /// </summary>
        public override bool LV3()
        {
            if (base.CheckAuthority(nameof(LV3)))
                return base.LV3();
            return false;
        }

        /// <summary>
        /// 场上每存在一名敌人，干扰成功率+5%
        /// </summary>
        public override void LV4_PlusCCHit(BattleChar iseubi)
        {
            if (base.CheckAuthority(nameof(LV4_PlusCCHit)))
                base.LV4_PlusCCHit(iseubi);
        }
        /// <summary>
        /// 神罗天征可以清除所有友军的减益buff
        /// </summary>
        public override void LV4_Shinratense()
        {
            if (base.CheckAuthority(nameof(LV4_Shinratense)))
                base.LV4_Shinratense();
        }
        /// <summary>
        /// 【抓取】将降低20%防御力。
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
