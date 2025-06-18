using ClosersFramework.Patchers.Registration;
using ClosersFramework.Services;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Patchers.Registration
{
    public class IseubiPassiveDescCheck : ClosersPassiveDescCheck
    {
        public override void NormalCheck()
        {
            ExpService.PassiveDescCheckOutBattle();
        }

        public override void ReplaceCheck(ref CharacterCollection __instance)
        {
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }

        public override void ReplaceCheck(ref StartPartySelect __instance)
        {
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
        public override void ReplaceCheck(ref CharSelectMainUIV2 __instance)
        {
            var iseubi = __instance.CharDatas.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Signal2Real();
        }
        public override void Rollback(ref CharacterCollection __instance)
        {
            var iseubi = __instance.CharacterList.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }

        public override void Rollback(ref StartPartySelect __instance)
        {
            var iseubi = __instance.Chars.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
        public override void Rollback(ref CharSelectMainUIV2 __instance)
        {
            var iseubi = __instance.CharDatas.FirstOrDefault(t => t.Key == IseubiKeyWords.Iseubi);
            if (iseubi != null) iseubi.PassiveDes = iseubi?.PassiveDes.Real2Signal();
        }
    }
}
