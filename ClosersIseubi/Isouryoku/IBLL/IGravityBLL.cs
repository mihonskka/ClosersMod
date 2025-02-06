using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Isouryoku.IBLL
{
    public interface IGravityBLL
    {
        bool LV1();
        void LV2_Shinratense(BattleChar iseubi);
        Skill LV2_IgnoreDef(Skill C6sub);
    }
}
