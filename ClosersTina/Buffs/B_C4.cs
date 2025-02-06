using ClosersFramework.Service;
using ClosersFramework.Templates;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina.Buffs
{
    public class B_C4 : ClosersBaseBuff
    {
        //todo
        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            BattleSystem.DelayInput(Damage((int)(this.Usestate_F.GetStat.atk * 1f * base.StackNum), this.BChar, true));
            this.BChar.MyTeam.Chars.ForEach(t =>
            {
                if (t != this.BChar)
                    BattleSystem.DelayInput(Damage((int)(this.Usestate_F.GetStat.atk * 0.4f * base.StackNum), t, false));
            });
        }

        public IEnumerator Damage(int damage, BattleChar bc, bool main)
        {
            yield return new WaitForSeconds(0.07f);
            //闪电链特效
            //"asset/closersmod/iseubi/electchain.prefab"
            //new GDEGameobjectDatasData("electchain").Gameobject_Path
            if (main)
            {
                clog.tw("塑胶炸弹-准备播放特效");
                AddressableLoadManager.Instantiate(new GDEGameobjectDatasData("C4Effect").Gameobject_Path, AddressableLoadManager.ManageType.Battle).transform.position = this.BChar.GetTopPos();
                clog.tw("塑胶炸弹-特效播放完毕");
            }
            bc.Damage(base.Usestate_F, damage, false, false, false, 0, false, false, false);
            clog.tw("塑胶炸弹-成功给予伤害");
            yield break;
        }
        public override string ClosersDesc(string desc)
        {
            return base.ClosersDesc(desc).Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1f * base.StackNum)).ToString()).Replace("&b", ((int)(this.Usestate_F.GetStat.atk * 0.4f * base.StackNum)).ToString());
        }
    }
}
