using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Patchers.Registration
{
    public class ClosersBroadcast
    {
        public virtual void mainfunction(string Text, Vector3 Pos, Transform PosT = null)
        {

        }

        public void InstBattleTextAlly_Co(string Text, Vector3 Pos)
        {
            mainfunction(Text, Pos);
        }

        public void InstFieldText(string Text, Transform Pos)
        {
            mainfunction(Text, new Vector3(), Pos);
        }

        public void CustomText(string Text, Vector3 Pos)
        {
            mainfunction(Text, Pos);
        }
        public void InstBattleText_Co(string Text, Vector3 Pos)
        {
            mainfunction(Text, Pos);
        }
        public void InstCampText_Co(string Text, Vector3 Pos, Transform CampTr)
        {
            mainfunction(Text, Pos);
        }
        public void InstFieldText_CO(string Text, Transform Pos)
        {
            mainfunction(Text, new Vector3(), Pos);
        }
    }
}
