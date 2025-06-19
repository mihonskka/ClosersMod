using ChronoArkMod;
using ClosersFramework;
using ClosersFramework.Models.Interface;
using ClosersFramework.Services;
using ClosersTina.Cards;
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
        public static bool IsTina(Character character) => character.KeyData == TinaKeyWords.Tina;

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
            for (var i = 0; i < num; i++)
                tina.BuffAdd(TinaKeyWords.B_Overheat, tina);
        }

        public static void AddPassiveCounter(BattleChar tina, int a = 1)
        {
            if (BattleSystem.instance == null) return;
            var passive = tina.Info.Passive as P_Tina;
            if (passive == null) return;
            clog.tw($"计数器：{passive.PassiveCounter}");
            passive.PassiveCounter += a;
        }

        public static void AddPassiveCounter(int a = 1)
        {
            if (BattleSystem.instance == null) return;
            var passive = FindTinaInBattle()?.Info?.Passive as P_Tina;
            if (passive == null) return;
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
        [Obsolete]
        public static string DelayParticle(string PreParticlePath)
        {
            var result = PreParticlePath;
            if (!string.IsNullOrWhiteSpace(PreParticlePath))
            {
                result = PreParticlePath.Replace(".prefab", "_Delayed.prefab");
                clog.tw($"延迟粒子路径：{result}，原路径：{PreParticlePath}");
			}
            return result;
        }
        /// <summary>
        /// 切换武器
        /// 只允许在战斗中使用
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static string SwitchWeapon(TinaWeapons weapon)
        {
            if ((FindTinaInBattle() as BattleAlly).Info.Passive is P_Tina pTina)
            {
                clog.tw($"切换武器：{weapon}，当前武器：{pTina.NowWeapon}");
                pTina.NowWeapon = weapon;

            }
            return string.Empty;
        }
        public static void SwitchWeapon(TinaWeapons weapon, TinaBaseCard NeedAudioDelayedCard, float AudioDelayTime = 2f)
        {
            if ((FindTinaInBattle() as BattleAlly).Info.Passive is P_Tina pTina)
            {
                clog.tw($"切换武器：{weapon}，当前武器：{pTina.NowWeapon}");
                if (weapon != pTina.NowWeapon && weapon != TinaWeapons.NoneOrOther)
                {
                    clog.tw("Switch Weapon: change NADC");
					NeedAudioDelayedCard.AudioForeSecond = NeedAudioDelayedCard.AudioForeSecond.Limit(AudioDelayTime, DotNetExtend.LimitType.min);
				}
                pTina.NowWeapon = weapon;
            }
        }
        public static TinaWeapons GetNowWeapon()
		{
			if (FindTinaInBattle() is BattleAlly tina && tina.Info.Passive is P_Tina pTina)
			{
				//clog.tw($"获取当前武器：{pTina.NowWeapon}");
				return pTina.NowWeapon;
			}
			//clog.tw("获取当前武器：NoneOrOther");
			return TinaWeapons.NoneOrOther;
		}
	}
}
