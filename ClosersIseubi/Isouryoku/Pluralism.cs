using ClosersIseubi.Isouryoku.BLL;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Models;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;

namespace ClosersIseubi.Isouryoku
{
    public class Pluralism:PluralismBLL
    {
        public Pluralism()
        {
            base.ConfigList = new List<AuthorityConfigItem>()
            {
                new AuthorityConfigItem(){ Name=nameof(LV1), needExp=4, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV0_Immediate), needExp=0, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV0_Immediate_Activate), needExp=0, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV0Desc), needExp=0, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV1Desc), needExp=4, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV2), needExp=8, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV2Desc), needExp=8, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV3_Immediate), needExp=12, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV3_AfterBattle), needExp=12, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV3Desc), needExp=12, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV4Effect), needExp=16, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV4Desc), needExp=16, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV5), needExp=20, sect=CardType.Pluralism },
                new AuthorityConfigItem(){ Name=nameof(LV5Desc), needExp=20, sect=CardType.Pluralism },
            };
        }
        /// <summary>
        /// 回合开始时，若手中没有露西的牌，则优先抽取一张露西的牌 EXP4
        /// </summary>
        public override void LV1(List<Skill> skills)
        {
            if (base.CheckAuthority(nameof(LV1)))
                base.LV1(skills);
        }
        /// <summary>
        /// 立即获得【协同作战】技能书；
        /// </summary>
        public override void LV0_Immediate()
        {
            if (base.CheckAuthority(nameof(LV0_Immediate))&& PlayData.TSavedata.LucySkills.All(t=>t!=IseubiKeyWords.CL_iseubi1) && PlayData.TSavedata.LucySkillList_Legendary.All(t=>t!=IseubiKeyWords.CL_iseubi1))
                base.LV0_Immediate();
        }
        public override void LV0_Immediate_Activate()
        {
            if (base.CheckAuthority(nameof(LV0_Immediate_Activate)))
                base.LV0_Immediate_Activate();
        }
        /// <summary>
        /// 每当消耗碎片或等待时，清空露西和对应调查员的的过载。
        /// </summary>
        //[ExpHandler(8, CardType.Pluralism)]
        public override void LV2()
        {
            if (base.CheckAuthority(nameof(LV2)))
                base.LV2();
        }
        /// <summary>
        /// 立即获得2个道具卷轴；
        /// </summary>
        //[ExpHandler(12, CardType.Pluralism)]
        public override void LV3_Immediate()
        {
            if (base.CheckAuthority(nameof(LV3_Immediate)))
                base.LV3_Immediate();
        }
        /// <summary>
        /// 完成诅咒战斗时，获得一个道具卷轴；
        /// </summary>
        //[ExpHandler(12, CardType.Pluralism)]
        public override void LV3_AfterBattle()
        {
            if (base.CheckAuthority(nameof(LV3_AfterBattle)))
                base.LV3_AfterBattle();
        }
        /// <summary>
        /// 回合开始时，若露西拥有魔法碎片，则获得1点法力值；
        /// </summary>
        //[ExpHandler(16, CardType.Pluralism)]
        public override void LV4Effect()
        {
            if (base.CheckAuthority(nameof(LV4Effect)))
                base.LV4Effect();
        }
        /// <summary>
        /// 【协同作战】取消一次性；每当牌堆洗牌时，清空所有角色的过载，恢复法力值至上限，并抽取等同于角色数量的牌。
        /// </summary>
        /// <returns></returns>
        public override bool LV5()
        {
            if (base.CheckAuthority(nameof(LV5)))
                return base.LV5();
            return false;
        }
        public bool LV0Desc() => base.CheckAuthority(nameof(LV0Desc));
        public override bool LV1Desc() => base.CheckAuthority(nameof(LV1Desc));
        public override bool LV2Desc() => base.CheckAuthority(nameof(LV2Desc));
        public override bool LV3Desc() => base.CheckAuthority(nameof(LV3Desc));
        public override bool LV4Desc() => base.CheckAuthority(nameof(LV4Desc));
        public override bool LV5Desc() => base.CheckAuthority(nameof(LV5Desc));
    }
}
