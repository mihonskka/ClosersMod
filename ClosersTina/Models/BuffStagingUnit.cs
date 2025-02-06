using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Models
{
    public class BuffStagingUnit
    {
        public BattleEnemy Owner { get; set; }
        //public List<Buff> Buffs { get; set; }
        public List<ClosersRegistBuff> Buffs { get; set; }
    }
}
