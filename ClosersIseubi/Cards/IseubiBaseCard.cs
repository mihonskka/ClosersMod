using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using ClosersFramework.Service.CodeManager;
using UnityEngine;
using static ClosersFramework.Services.Enum;
using ClosersFramework.Templates;
using ToolBox = ClosersIseubi.Service.ToolBox;

namespace ClosersIseubi.Cards
{
    /// <summary>
    /// 李瑟钰卡牌基类
    /// </summary>
    public abstract class IseubiBaseCard : ClosersBaseCard, IP_SkillMiss_User, IP_DamageChange, ICharacterSoundsToken
	{
        int _chipChangeNum;
        bool _isSpendChipCard;
        bool _isCreateChipCard;
        bool _allowInsufficient;
        CardType _type;
        ToolBox tb = new ToolBox();
        //bool _isPlusHit;
        public virtual int PlusChipUpdate(int origin)
        {
            return origin;
        }
        protected int PlusChip { 
            get 
            {
                return PlusChipUpdate(plusChip);
            }
            set => plusChip = value; }
        public BattleChar ComponentMaster { get => this.BChar; }
        public void chipChangeNum(int i) => _chipChangeNum = i;
        [NoReference]
        public bool NotCreate { get; set; }
        public IseubiBaseCard(int chipChangeNum, bool isSpendChipCard, bool isCreateChipCard, CardType type,bool allowInsufficient=false, bool notCreate=false)
        {
            _chipChangeNum = chipChangeNum;
            _isSpendChipCard = isSpendChipCard;
            _isCreateChipCard = isCreateChipCard;
            _allowInsufficient = allowInsufficient;
            _type = type;
            NotCreate = notCreate;
        }
        public override bool Terms()
        {
            if (BattleSystem.instance == null) return base.Terms();
            if (_allowInsufficient) return true;
            if (_chipChangeNum + PlusChip<0)
            {
                int chipNum = IseubiService.GetChipNum(this.BChar);
                return chipNum >= -(_chipChangeNum + PlusChip);
            }
            return true;
        }

        /// <summary>
        /// 改变碎片数量
        /// </summary>
        public void ChangeChipNum()
        {
            clog.iw($"正在更改碎片数量：{_chipChangeNum+PlusChip}");
            if (_chipChangeNum + PlusChip > 0)
            {
                IseubiService.addChip(_chipChangeNum + PlusChip, this.BChar, this.BChar);
            }
            else if (_chipChangeNum + PlusChip < 0)
            {
                clog.iw("准备消耗碎片");
                IseubiService.reduceChip(_chipChangeNum + PlusChip, this.BChar);
            }
            if (this.MySkill?.PlusHit == true) return;
            if ((_isSpendChipCard || _isCreateChipCard) && this.BChar.Info.KeyData==IseubiKeyWords.Iseubi)
            {
                this.BChar.BuffAdd(IseubiKeyWords.bls, this.BChar);
                new Electrical().LV2(this.BChar);
            }
		}
        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);
            clog.iw("技能使用，正在准备改变碎片数量");
            if (!this.MySkill.PlusHit) ChangeChipNum();
        }
		public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
		{
			base.AttackEffectSingle(hit, SP, DMG, Heal);
        }

        public override bool TargetHit(BattleChar Target)
        {
            bool hitFlag = false;
            if (_type == CardType.Electrical && Target.BuffFind(IseubiKeyWords.bse))
                hitFlag = true;
            if (_type == CardType.Teleport && Target.BuffFind(IseubiKeyWords.birsb))
                hitFlag = true;
            if(hitFlag)clog.iw($"TH检测通过");
            return hitFlag||base.TargetHit(Target);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            bool flag = false;
            if (_type == CardType.Electrical && Targets.Any(t => t.BuffFind(IseubiKeyWords.bse)))
            {
                flag = true;
                flag &= !new Electrical().LV3_StormEye();
                this.PlusStat.HitMaximum = true;
                this.PlusStat.hit += 999f;
                this.PlusStat.PlusCriDmg = 30f;
            }
            base.SkillUseSingle(SkillD, Targets);
            if (flag)
                Targets.ForEach(t => t.BuffRemove(IseubiKeyWords.bse));
        }
        bool needClearBSE { get; set; } = false;

        public Vector3 ComponentCoordinate => new Vector3();

        public Transform ComponentTransform => null;

        public virtual void MissEffect(BattleChar hit, SkillParticle SP)
        {
            //clog.iw("技能使用，正在准备改变碎片数量");
            //if (!this.MySkill.PlusHit) ChangeChipNum();
        }

        public virtual int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            //this.OnePassive = true;
            //Damage = new Teleport().LV4(Damage, this.BChar, View);
            return Damage;
        }

        ToolBox toolBox = new ToolBox();
        private int plusChip = 0;
    }
}
