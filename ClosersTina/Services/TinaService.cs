using ClosersFramework;
using ClosersFramework.Models.Interface;
using ClosersFramework.Service;
using ClosersTina.KeyWords;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Services
{
    public static class TinaService
    {
        public static bool IsTina(Character character)=>character.KeyData==TinaKeyWords.Tina;

        public static bool IsTina(ICharacterSoundsToken model) => model.ComponentMaster?.Info?.KeyData == TinaKeyWords.Tina || ((BattleSystem.instance != null) ? model.ComponentCoordinate.IsAdjacentVector((FindTinaInBattle() as BattleAlly)?.GetTopPos()) : model.ComponentTransform.localPosition.IsAdjacentVector(FindTinaInInvest()?.GetAllyWindow?.TextPos?.localPosition));
        /// <summary>
        /// 战斗时存活成员中寻找缇娜
        /// </summary>
        /// <returns></returns>
        public static BattleChar FindTinaInBattle() => BattleSystem.instance?.AllyTeam?.AliveChars?.FirstOrDefault(t => t.Info.KeyData == TinaKeyWords.Tina);

        public static Character FindTinaInInvest() => PlayData.TSavedata?.Party?.FirstOrDefault(t => t.KeyData == TinaKeyWords.Tina);
        /// <summary>
        /// 战斗时所有成员中寻找缇娜
        /// </summary>
        /// <returns></returns>
        public static BattleAlly FindTinaPDBattleAlly() => PlayData.Battleallys.FirstOrDefault(t => t.Info.KeyData == TinaKeyWords.Tina);
        public static GDECharacterData FindTinaOriginal()
        {
            var tina = new GDECharacterData(TinaKeyWords.Tina);
            if (!tina.Off) return tina;
            return null;
        }

        public static void AddOverheat(int num) => AddOverheat(FindTinaInBattle(), num);

        public static void AddOverheat(BattleChar tina, int num)
        {
            if (tina == null || tina.Info.KeyData != TinaKeyWords.Tina) return;
            if (GlobalSetting.PositiveDevelop) return;
            for(var i = 0; i < num; i++)
                tina.BuffAdd(TinaKeyWords.B_Overheat, tina);
        }

        public static void AddPassiveCounter(BattleChar tina,int a = 1)
        {
            if(BattleSystem.instance==null) return;
            var passive = tina.Info.Passive as P_Tina;
            if (passive == null) return;
            clog.tw($"计数器：{passive.PassiveCounter}");
            passive.PassiveCounter += a;
        }

        public static void AddPassiveCounter(int a = 1)
        {
            if (BattleSystem.instance == null) return;
            var passive = FindTinaInBattle()?.Info?.Passive as P_Tina;
            if(passive==null) return;
            clog.tw($"计数器：{passive.PassiveCounter}");
            passive.PassiveCounter += a;
        }

        public static bool CheckPresence(bool inBattle)
        {
            bool cont = false;
            if (FindTinaInInvest() != null)
            {
                if (inBattle)
                {
                    if (FindTinaInBattle() != null)
                        cont = true;
                    else cont = false;
                }
                else
                    cont = true;
            }
            return cont;
        }
    }
}
