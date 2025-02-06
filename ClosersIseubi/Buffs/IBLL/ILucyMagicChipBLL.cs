using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs.IBLL
{
    interface ILucyMagicChipBLL
    {
        void checkbuff(Buff thisbuff, Buff buff = null, bool permit = false);
    }
    public interface ILucyMagicChipForAllyBLL
    {
        void check(Buff thisbuff);
    }
}
