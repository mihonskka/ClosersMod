using ClosersIseubi.Isouryoku.IBLL;
using ClosersIseubi.KeyWords;
using ClosersIseubi.Service;
using ClosersFramework.Service;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Isouryoku.BLL
{
    public abstract class PluralismBLL : IsouryokuBLL, IPluralismBLL
    {
        public virtual void LV1(List<Skill> skills)
        {
            if (skills.All(t => t.Master != BattleSystem.instance.AllyTeam.LucyChar))
            {
                clog.iw("兼修1级-优先抽取露西牌");
                Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.FirstOrDefault(t => t.Master == BattleSystem.instance.AllyTeam.LucyChar);
                if (skill2 == null) BattleSystem.instance.AllyTeam.Draw(1);
                else BattleSystem.instance.AllyTeam.ForceDraw(skill2);
            }
        }

        public virtual void LV0_Immediate()
        {
            InventoryManager.Reward(new List<ItemBase>()
            {
                ItemBase.GetItem(new GDESkillData(IseubiKeyWords.CL_iseubi1))
            });
            EventDispatcher.Dispatch(IseubiEventKeys.PluLV1ISkill);
        }
        public virtual void LV0_Immediate_Activate()
        {
            EventDispatcher.Dispatch(IseubiEventKeys.PluLV1ISkill+"Activate");
        }

        public virtual void LV2()
        {
            clog.iw("兼修2级-清空露西过载");
            BattleSystem.instance.AllyTeam.LucyChar.Overload = 0;
            var turn = BattleSystem.instance.TurnNum;
            try
            {
                clog.iw($"即将清空过载的调查员名为：{BattleSystem.instance.AllyTeam.Chars[(turn - 1) % 4]?.Info?.Name}");
                BattleSystem.instance.AllyTeam.Chars[(turn - 1) % 4].Overload = 0;
            }
            catch { }
        }

        public virtual void LV3_Immediate()
        {
            InventoryManager.Reward(new List<ItemBase>()
            {
                ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Item),
                ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Item),
                ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Item)
            });
            EventDispatcher.Dispatch(IseubiEventKeys.PluLV3IScroll);
        }

        public virtual void LV3_AfterBattle()
        {
            InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Item));
        }

        public virtual void LV4Effect()
        {
            if (BattleSystem.instance != null)
                BattleSystem.instance.AllyTeam.AP++;
        }
        /// <summary>
        /// 【协同作战】取消一次性；每当牌堆洗牌时，清空所有角色的过载，恢复法力值至上限，并抽取等同于角色数量的牌。
        /// </summary>
        /// <returns></returns>
        public virtual bool LV5()
        {
            return true;
        }
    }
}
