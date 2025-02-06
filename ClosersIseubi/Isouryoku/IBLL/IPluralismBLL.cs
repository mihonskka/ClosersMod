using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Isouryoku.IBLL
{
    public interface IPluralismBLL
    {
        void LV1(List<Skill> skills);
        void LV2();
        void LV3_Immediate();
        void LV3_AfterBattle();
        void LV4Effect();
    }
}
