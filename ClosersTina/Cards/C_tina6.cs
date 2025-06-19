using ClosersTina.Cards;
using ClosersTina.KeyWords;
using ClosersTina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
    public class C_tina6:TinaBaseCard
    {
        public C_tina6():base()
        {
            this.DamageThreshold = 50;
            this.AudioName = TinaKeyWords.Closers_Tina_Rifle_Audio;
			this.Weapon = TinaWeapons.Rifle;
		}
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			base.SkillUseSingle(SkillD, Targets);
            TinaSoundService.RandomSound(TinaKeyWords.V_TinaShoot, 6, this);
        }
    }
}
