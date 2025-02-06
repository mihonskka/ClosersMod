using ClosersFramework.Patchers.Registration;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Patcher.Registration
{
    public class TinaPassiveDescCheck : ClosersPassiveDescCheck
    {
        public override void NormalCheck()
        {
            ExpService.PassiveDescCheckOutBattle();
        }

        public override void ReplaceCheck(ref CharacterCollection __instance)
        {
            var tina = __instance.CharacterList.FirstOrDefault(t => t.Key == TinaKeyWords.Tina);
            if (tina != null) tina.PassiveDes = tina?.PassiveDes.Signal2Real();
        }

        public override void ReplaceCheck(ref StartPartySelect __instance)
        {
            var tina = __instance.Chars.FirstOrDefault(t => t.Key == TinaKeyWords.Tina);
            if (tina != null) tina.PassiveDes = tina?.PassiveDes.Signal2Real();
        }

        public override void ReplaceCheck(ref CharSelectMainUIV2 __instance)
        {
            var tina = __instance.CharDatas.FirstOrDefault(t => t.Key == TinaKeyWords.Tina);
            if (tina != null) tina.PassiveDes = tina?.PassiveDes.Signal2Real();
        }

        public override void Rollback(ref CharacterCollection __instance)
        {
            var tina = __instance.CharacterList.FirstOrDefault(t => t.Key == TinaKeyWords.Tina);
            if (tina != null) tina.PassiveDes = tina?.PassiveDes.Real2Signal();
        }

        public override void Rollback(ref StartPartySelect __instance)
        {
            var tina = __instance.Chars.FirstOrDefault(t => t.Key == TinaKeyWords.Tina);
            if (tina != null) tina.PassiveDes = tina?.PassiveDes.Real2Signal();
        }

        public override void Rollback(ref CharSelectMainUIV2 __instance)
        {
            var tina = __instance.CharDatas.FirstOrDefault(t => t.Key == TinaKeyWords.Tina);
            if (tina != null) tina.PassiveDes = tina?.PassiveDes.Real2Signal();
        }
    }
}
