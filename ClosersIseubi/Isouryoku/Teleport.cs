using ClosersIseubi.Isouryoku.BLL;
using ClosersIseubi.Models;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Isouryoku
{
    public class Teleport:TeleportBLL
    {
        public Teleport()
        {
            base.ConfigList = new List<AuthorityConfigItem>()
            {
                new AuthorityConfigItem(){ Name=nameof(LV1_IraishinMode), needExp=4, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV1Desc), needExp=4, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV1_Passive), needExp=4, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV2_Beacon), needExp=8, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV2Desc), needExp=8, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV2_Kill), needExp=8, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV3), needExp=12, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV3Desc), needExp=12, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV4), needExp=16, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV4Desc), needExp=16, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV5), needExp=20, sect=CardType.Teleport },
                new AuthorityConfigItem(){ Name=nameof(LV5Desc), needExp=20, sect=CardType.Teleport },
            };
        }
        //[ExpHandler(4,CardType.Teleport)]
        public override bool LV1_IraishinMode()
        {
            if (base.CheckAuthority(nameof(LV1_IraishinMode)))
                return base.LV1_IraishinMode();
            return false;
        }
        //[ExpHandler(4,CardType.Teleport)]
        public override void LV1_Passive(Passive_Char p)
        {
            if (base.CheckAuthority(nameof(LV1_Passive)))
                base.LV1_Passive(p);
        }

        //[ExpHandler(8,CardType.Teleport)]
        public override Buff LV2_Beacon(Buff Beacon)
        {
            if (base.CheckAuthority(nameof(LV2_Beacon)))
                return base.LV2_Beacon(Beacon);
            return Beacon;
        }

        public override void LV2_Kill(BattleChar iseubi)
        {
            if (base.CheckAuthority(nameof(LV2_Kill)))
                base.LV2_Kill(iseubi);
        }

        //[ExpHandler(12,CardType.Teleport)]
        public override bool LV3()
        {
            if (base.CheckAuthority(nameof(LV3)))
                return base.LV3();  
            return false;
        }

        //[ExpHandler(16,CardType.Teleport)]
        public override int LV4(int damage, BattleChar iseubi, bool view)
        {
            if (base.CheckAuthority(nameof(LV4))) return base.LV4(damage, iseubi, view);
            return damage;
        }
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
