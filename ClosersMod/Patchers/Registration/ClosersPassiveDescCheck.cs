using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Patchers.Registration
{
    public abstract class ClosersPassiveDescCheck
    {
        public abstract void NormalCheck();
        public abstract void ReplaceCheck(ref CharacterCollection __instance);
        public abstract void ReplaceCheck(ref StartPartySelect __instance);
        public abstract void ReplaceCheck(ref CharSelectMainUIV2 __instance);
        public abstract void Rollback(ref CharacterCollection __instance);
        public abstract void Rollback(ref StartPartySelect __instance);
        public abstract void Rollback(ref CharSelectMainUIV2 __instance);
    }
}
