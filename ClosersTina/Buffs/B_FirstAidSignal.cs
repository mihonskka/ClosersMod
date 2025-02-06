using ClosersFramework.Templates;
using ClosersTina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Buffs
{
    public class B_FirstAidSignal : ClosersBaseBuff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(BattleSystem.instance != null && TinaService.FindTinaInBattle() != null)
            {
                this.SelfDestroy();
            }
        }
    }
}
