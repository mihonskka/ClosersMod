using ClosersIseubi.Isouryoku.IBLL;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Windows.Speech;

namespace ClosersIseubi.Isouryoku.BLL
{
    public abstract class GravityBLL: IsouryokuBLL, IGravityBLL
    {
        /// <summary>
        /// 友军被选定为目标时，可以提前打出一张【神罗天征】，让本次攻击无效。若如此做，这张牌将被放逐
        /// </summary>
        public virtual bool LV1()
        {
            return true;
        }
        /// <summary>
        /// 神罗天征可以解除自身的所有减益buff
        /// </summary>
        public virtual void LV2_Shinratense(BattleChar iseubi)
        {
            iseubi.Buffs.Where(t => t.BuffData.Debuff).ToList().ForEach(t => t.StackDestroy());
        }
        /// <summary>
        /// 万象天引将无视防御
        /// </summary>
        public virtual Skill LV2_IgnoreDef(Skill C6sub)
        {
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.PlusSkillStat.Penetration = 100f;
            C6sub.ExtendedAdd(skill_Extended);
            return C6sub;
        }

        /// <summary>
        /// 戒律之刃段数+1，产生碎片数+1
        /// </summary>
        public virtual bool LV3()
        {
            return true;
        }

        /// <summary>
        /// 场上每存在一名敌人，干扰成功率+5%
        /// </summary>
        public virtual void LV4_PlusCCHit(BattleChar iseubi)
        {
            iseubi.BuffAdd(IseubiKeyWords.B_MyiseubiProxyBuff, iseubi);
        }
        /// <summary>
        /// 神罗天征可以清除所有友军的减益buff
        /// </summary>
        public virtual void LV4_Shinratense()
        {
            BattleSystem.instance.AllyTeam.AliveChars.ForEach(t => t.Buffs.Where(u => u.BuffData?.Debuff ?? false).ToList().ForEach(u => u.SelfDestroy()));
        }
        /// <summary>
        /// 【抓取】将降低20%防御力。
        /// </summary>
        /// <returns></returns>
        public virtual bool LV5()
        {
            return true;
        }
    }
}
