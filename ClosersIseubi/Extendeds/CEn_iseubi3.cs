using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.KeyWords;
using ClosersFramework.Service;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosersFramework.Service.Enum;
using ClosersFramework.Templates;

namespace ClosersIseubi.Extendeds
{
    public class CEn_iseubi3 : ClosersBaseExtend
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return (MainSkill.TargetTypeKey=="enemy" || MainSkill.TargetTypeKey=="all_enemy" || MainSkill.TargetTypeKey== "random_enemy" || MainSkill.TargetTypeKey== "all_onetarget") && base.CanSkillEnforce(MainSkill);
        }
        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
        }
        public override void Init()
        {
            base.Init();
            var iseubi = IseubiService.FindIseubiInInvest();
            if (iseubi == null) return;
            var sect = (CardType)ExpService.getSect().Obj;
            

            switch (sect)
            {
                case CardType.Electrical:
                    this.TargetBuff.Add(GetBuff(IseubiKeyWords.bec));
                    break;
                case CardType.Teleport:
                    this.TargetBuff.Add(GetBuff(IseubiKeyWords.birsb));
                    break;
                case CardType.Gravity:
                    this.TargetBuff.Add(GetBuff(IseubiKeyWords.big));
                    break;
                case CardType.Pluralism:
                    this.TargetBuff.Add(GetBuff(new List<string>() { IseubiKeyWords.bec, IseubiKeyWords.birsb, IseubiKeyWords.big }.Random()));
                    break;
                case CardType.Closers:
                    this.TargetBuff.Add(GetBuff(IseubiKeyWords.bec));
                    this.TargetBuff.Add(GetBuff(IseubiKeyWords.birsb));
                    this.TargetBuff.Add(GetBuff(IseubiKeyWords.big));
                    break;
                default:
                    this.TargetBuff.Add(GetBuff(new List<string>() { IseubiKeyWords.bec, IseubiKeyWords.birsb, IseubiKeyWords.big }.Random()));
                    break;
            }
        }

        public BuffTag GetBuff(string buffName)
        {
            var buff = new BuffTag();
            buff.BuffData = new GDEBuffData(buffName);
            buff.PlusTagPer = 100;
            buff.User = this.BChar;
            return buff;
        }
    }
}
