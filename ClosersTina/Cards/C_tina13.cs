using ClosersTina.KeyWords;
using ClosersTina.Services;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Cards
{
	/// <summary>
	/// submachinegun
	/// </summary>
	public class C_tina13 : TinaBaseCard
	{
		public C_tina13() : base(true, 2)
		{ 
			this.AudioName = TinaKeyWords.Closers_Tina_SubmachineGun5Combo_Audio;
		}
		public override void Init()
		{
			base.Init();
		}
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
			TinaSoundService.RandomSound(TinaKeyWords.V_TinaBlade, 8, this);
		}
		public override bool TargetHit(BattleChar Target)
		{
			return Target.GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count != 0;
		}

	}
}
