using ClosersFramework.Templates;
using ClosersIseubi.Isouryoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_Iseubi_grab : ClosersBaseBuff
    {
        /*public override void TurnUpdate()
        {
            if (!this.BChar.Info.Ally)
            {
                base.SelfDestroy();
                return;
            }
            if (!this.flag)
            {
                this.flag = true;
                return;
            }
            base.SelfDestroy();
        }*/
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = -100;
            this.PlusStat.Stun = true;
            if(new Gravity().LV5())
            {
                this.PlusStat.def = -20;
            }
        }

        /*public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (skill.Master == this.BChar&&skill.Master is BattleAlly)
            {
                base.SelfDestroy();
            }
        }*/

        public bool flag;
    }
}
