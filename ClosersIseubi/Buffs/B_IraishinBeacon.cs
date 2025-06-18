using ClosersIseubi.Isouryoku;
using ClosersIseubi.Service;
using ClosersFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersFramework.Templates;
using ToolBox = ClosersIseubi.Service.ToolBox;

namespace ClosersIseubi.Buffs
{
	public class B_IraishinBeacon : ClosersBaseBuff
    {
        public override void Init()
        {
            if (BattleSystem.instance != null)
            {
                
            }
            new Teleport().LV2_Beacon(this);
            base.Init();
        }
        ToolBox tb = new ToolBox();
	}
}
