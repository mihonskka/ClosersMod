using ClosersIseubi.Buffs;
using ClosersIseubi.Isouryoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;

namespace ClosersIseubi.Cards
{
    public class C_iseubi15:IseubiBaseCard
    {
        public C_iseubi15():base(0,false,false,CardType.Gravity)
        {

        }
    }

    public class C_iseubi15_0 : IseubiBaseCard
    {
        public C_iseubi15_0() : base(0, false, false, CardType.Gravity)
        {

        }

        public override int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            Damage += (int)this.BChar.MyTeam.Chars.Sum(t => (t.Buffs.FirstOrDefault(u => u.BuffData.Key == "B_Gravitational_singularity") as B_Gravitational_singularity).Absorption);
            this.BChar.MyTeam.Chars.ForEach(t => t.Buffs.FirstOrDefault(u => u.BuffData.Key == "B_Gravitational_singularity").StackDestroy());
            return base.DamageChange(SkillD, Target, Damage, ref Cri, View);
        }
    }
}

namespace ClosersIseubi.Buffs
{
    public class B_Gravitational_singularity : Buff, IP_DamageTakeChange
    {
        public decimal Absorption { get; set; }
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            var gra = new Gravity();
            decimal absorption = 0;
            if (gra.LV4Desc())
            {
                if (NODEF) absorption = (decimal)(Dmg * 0.2);
                else absorption = (decimal)(Dmg * 0.3);
            }
            else if (gra.LV3Desc())
            {
                if (NODEF) absorption = (decimal)(Dmg * 0.2);
                else absorption = (decimal)(Dmg * 0.3);
            }
            else if (gra.LV2Desc())
            {
                if (NODEF) absorption = (decimal)(Dmg * 0.2);
                else absorption = (decimal)(Dmg * 0.3);
            }
            else if (gra.LV1Desc())
            {
                if (NODEF) absorption = (decimal)(Dmg * 0.2);
                else absorption = (decimal)(Dmg * 0.3);
            }
            Absorption += absorption;
            return (int)(Dmg - absorption);
        }
    }
}
