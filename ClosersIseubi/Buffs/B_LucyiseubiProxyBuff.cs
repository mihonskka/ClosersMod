using ClosersFramework.Templates;
using ClosersIseubi.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Buffs
{
    public class B_LucyiseubiProxyBuff : ClosersBaseBuff, IP_Discard
    {
        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (Click && BattleSystem.instance.AllyTeam.AliveChars.Any(t => t.BuffFind(IseubiKeyWords.B_PursueAndAttack)))
            {
                BattleSystem.instance.AllyTeam.Draw(1);
                BattleSystem.instance.AllyTeam.AP++;
            }
        }
    }
}
