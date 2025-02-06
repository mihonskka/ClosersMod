using ClosersIseubi.Isouryoku;
using ClosersIseubi.Models;
using ClosersFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Templates;

namespace ClosersIseubi.Buffs
{
    public class B_StormEyes : ClosersBaseBuff
    {
        TranslationItem ExtDesc = new TranslationItem()
        {
            
            SimplifiedChinese = "触发时解除。",
            TraditionalChinese = "觸發時解除。",
            English = "Removed when activated.",
            Japanese = " 発動すると解除される。",
            Korean = "발동하면 해제됩니다."
        };
        public override string ClosersDesc(string desc)
        {
            if (new Electrical().LV3Desc())
                return desc;
            return desc + ExtDesc.TransToLocalization;
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 10;
        }
    }
}
