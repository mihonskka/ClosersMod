using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Isouryoku.IBLL
{
    public interface IElectricalBLL
    {
        void LV1(BattleChar iseubi);
        void LV2(BattleChar iseubi);
        void LV3_ES(Skill ElectricShock, int counter);
        bool LV3_StormEye();
        void LV4(BattleChar iseubi);
    }
}
