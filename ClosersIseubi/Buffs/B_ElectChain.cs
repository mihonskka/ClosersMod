using ClosersIseubi.Isouryoku;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework;
using ClosersFramework.Models;
using ClosersFramework.Service;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ClosersFramework.Templates;

namespace ClosersIseubi.Buffs
{
    public class B_ElectChain : ClosersBaseBuff, IP_Hit
    {
        public override void Init()
        {
            if (GlobalSetting.Allin) this.BuffData.MaxStack = 5;
            base.Init();
        }
        public override string ClosersDesc(string desc)
        {
            var t = new TranslationItem()
            {
                
                SimplifiedChinese = "额外攻击、反击",
                TraditionalChinese = "額外攻擊、反擊",
                English = "additional attacks or counterattacks",
                Japanese = "追加攻撃ど反擊",
                Korean = "추가 공격、반격을"
            };
            var te = new TranslationItem()
            {
                
                SimplifiedChinese = "攻击",
                TraditionalChinese = "攻擊",
                English = "attacks",
                Japanese = "攻撃",
                Korean = "공격"
            };
            var dst = desc;
            var plusDmg = 0;
            if (new Electrical().LV1EC()) plusDmg = 2;
            if (GlobalSetting.Allin) dst = dst.Replace("&a", (((int)(base.Usestate_F.GetStat.atk * 0.25f) + plusDmg) * base.StackNum + 1).ToString());
            else dst = dst.Replace("&a", (((int)(base.Usestate_F.GetStat.atk * 0.1f) + plusDmg) * base.StackNum + 1).ToString());
            if (new Electrical().LV5()) dst = dst.Replace("&b", te.TransToLocalization);
            else dst = dst.Replace("&b", t.TransToLocalization);
            return dst;

        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            //受到痛苦伤害
            if (SP != null && (new Electrical().LV5() || SP.SkillData.PlusHit) && SP.TargetChar.All(t => t is BattleEnemy))
                BattleSystem.instance.EnemyTeam.AliveChars.Where(t => t.BuffFind(IseubiKeyWords.bec)).ToList().ForEach(t =>
                {
                    clog.iw("闪电链-遍历-触发效果");
                    var plusDmg = 0;
                    if (new Electrical().LV1EC()) plusDmg = 2;
                    if (BattleSystem.instance.EnemyTeam.AliveChars.Count(u => u.BuffFind(IseubiKeyWords.bec)) <= 2 && new Electrical().LV5()) BattleSystem.DelayInput(this.Damage((int)((base.Usestate_F.GetStat.atk * 0.25f + plusDmg) * base.StackNum + 1), t));
                    else if (GlobalSetting.Allin) BattleSystem.DelayInput(this.Damage((int)((base.Usestate_F.GetStat.atk * 0.15f + plusDmg) * base.StackNum + 1), t));
                    else BattleSystem.DelayInput(this.Damage((int)((base.Usestate_F.GetStat.atk * 0.1f + plusDmg) * base.StackNum + 1), t));
                    clog.iw("闪电链-遍历-单次结束");
                });
        }

        public IEnumerator Damage(int damage, BattleChar bc)
        {
            yield return new WaitForSeconds(0.07f);
            //闪电链特效
            //"asset/closersmod/iseubi/electchain.prefab"
            //new GDEGameobjectDatasData("electchain").Gameobject_Path
            clog.iw("闪电链-准备播放特效");
            AddressableLoadManager.Instantiate(new GDEGameobjectDatasData("ElectChain").Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
            clog.iw("闪电链-特效播放完毕");
            bc.Damage(base.Usestate_F, damage, false, true, false, 0, false, false, false);
            clog.iw("闪电链-成功给予伤害");
            yield break;
        }
    }
}
