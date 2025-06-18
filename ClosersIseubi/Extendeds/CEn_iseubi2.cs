using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Services;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Templates;

namespace ClosersIseubi.Extendeds
{
    public class CEn_iseubi2 : ClosersBaseExtend
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.AP>=2&&base.CanSkillEnforce(MainSkill);
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);
            var iseubi = IseubiService.FindIseubiInBattle();
            if (iseubi == null) return;
            var sect = (CardType)ExpService.getSect().Obj;
            switch (sect)
            {
                case CardType.Electrical:
                    GetCard(IseubiKeyWords.C_iseubi0, iseubi);
                    break;
                case CardType.Teleport:
                    GetCard(IseubiKeyWords.C_iseubi10, iseubi);
                    break;
                case CardType.Gravity:
                    GetCard(IseubiKeyWords.C_iseubi7, iseubi);
                    break;
                case CardType.Pluralism:
                    GetCard(new List<string>() { IseubiKeyWords.C_iseubi0, IseubiKeyWords.C_iseubi10, IseubiKeyWords.C_iseubi7 }.Random(), iseubi);
                    break;
                case CardType.Closers:
                    List<Skill> list = new List<Skill>
                    {
                        Skill.TempSkill(IseubiKeyWords.C_iseubi0, this.MySkill.Master, this.MySkill.Master.MyTeam),
                        Skill.TempSkill(IseubiKeyWords.C_iseubi10, this.MySkill.Master, this.MySkill.Master.MyTeam),
                        Skill.TempSkill(IseubiKeyWords.C_iseubi7, this.MySkill.Master, this.MySkill.Master.MyTeam),
                        Skill.TempSkill(IseubiKeyWords.C_iseubi_Cancel, this.MySkill.Master, this.MySkill.Master.MyTeam)
                    };
                    BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, false, true, false, false));
                    break;
                default:
                    GetCard(new List<string>() { IseubiKeyWords.C_iseubi0, IseubiKeyWords.C_iseubi10, IseubiKeyWords.C_iseubi7 }.Random(), iseubi);
                    break;
            }

        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            var iseubi = IseubiService.FindIseubiInBattle();
            if (iseubi == null) return;
            GetCard(Mybutton.Myskill.MySkill.KeyID, iseubi);
        }

        void GetCard(string cardName, BattleChar iseubi)
        {
            var sc4 = Skill.TempSkill(cardName, iseubi, iseubi.MyTeam);
            sc4.APChange = 1;
            sc4.isExcept = true;
            sc4.ExtendedAdd(DataToExtended(new GDESkillExtendedData(IseubiKeyWords.CS_iseubi0)));
            iseubi.MyTeam.Add(sc4, true);
        }
    }
}
