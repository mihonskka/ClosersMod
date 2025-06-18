using ChronoArkMod.ModData;
using ChronoArkMod.Template;
using ClosersFramework;
using ClosersFramework.Data;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Patchers;
using ClosersFramework.Services;
using ClosersFramework.Templates;
using ClosersHumanity.KeyWords;
using ClosersTina.Cards;
using ClosersTina.KeyWords;
using ClosersTina.Patcher.Registration;
using ClosersTina.Services;
using ClosersTina.Talking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersTina
{
    public class TinaCharacter : ClosersBaseCharacter
    {
        public override string ClosersCodeName { get; set; } = "Tina";

        public override string SkeletonDataPath => "Assets/ClosersMod/Tina/QStanding/q_tina_stand_SkeletonData.asset";

        public override string SkeletonDataFaceRightPath => throw new NotImplementedException();


        public override void ClosersInit()
        {
            TinaModalMessageService.Init();
            /*base.Text_Battle_Start = TinaModalMessageService.MessagesPool.FirstOrDefault(t => t.ActionName == ModalKeyWords.Text_Battle_Start).Sentences.Select(t => t.SimplifiedChinese).ToList();

            foreach (var i in base.Text_Battle_Start)
            {
                clog.tw(i);
            }*/


            //为闪避特权表增加一个判断条件：战斗中，此角色是被施加了紧急闪避buff的角色。原理为：查找目前所有拥有紧急闪避buff的角色，并查看其中是否有需要检测的角色。
            StatInterceptorData.DodgePrivilegesList.Add(c => BattleSystem.instance != null && (BattleSystem.instance?.AllyTeam?.Chars?.Where(t => t?.Buffs.Any(u => u.BuffData.Key == TinaKeyWords.B_SpaceDodge) ?? false)?.Select(t => t?.Info)?.ToList().Contains(c) ?? false));
            CharacterInterceptorData.PassivePrivilegesList.Add(c => c?.KeyData == TinaKeyWords.Tina);
            BattleTextInterceptorData.Broadcasts.Add(new TinaBroadcast());
            SkillAddingInterceptorData.SkillPrivilegesList.Add(TinaKeyWords.Tina, (t, c) => c || t.KeyData == TinaKeyWords.Tina);
            ExpPassvieDescInterceptorData.lst.Add(new TinaPassiveDescCheck());
            ClosersExtendText.RebirthInBattleText.Add(TinaKeyWords.Tina, new List<TranslationItem>()
            {
                new TranslationItem(){
                    Id=0,
                    SimplifiedChinese="这里是缇娜，作战重新开始。",
                    TraditionalChinese="這裡是緹娜，作戰重新開始。",
                    English="This is Tina, battle restarting.",
                    Japanese="こちらTina、作戦を再開する",
                    Korean=""
                },
                new TranslationItem(){
                    Id=1,
                    SimplifiedChinese="自爆序列取消，战斗重新开始。",
                    TraditionalChinese="自爆序列取消，作戰重新開始。",
                    English="Self explosion sequence has been cancelled, battle restarting.",
                    Japanese="自爆sequence cancelled、作戦を再開する",
                    Korean=""
                }
            });
            TalkingData.QStandingData.Add(TinaKeyWords.Tina, new QStandingInfo() { ArkPosition = new Vector3(7.2759f,3.1412f, 0), QStandingKey = TinaTalkingKeyWords.QStandingKey });
            CharacterLoadedData.Data.Add(TinaKeyWords.Tina);
            TalkingData.Data.Add(new ArkTalkingA());
            TalkingData.Data.Add(new ForeKingA());
            TalkingData.Data.Add(new ArchiveTalkingA());
            TalkingData.Data.Add(new ClockTowerTalkingA());
            TalkingData.Characters.Add(this);
        }
    }
}
