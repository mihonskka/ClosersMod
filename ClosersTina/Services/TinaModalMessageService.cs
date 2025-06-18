using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Services;
using ClosersTina.KeyWords;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Services
{
    public static class TinaModalMessageService
    {
        public static List<ModalMessages> MessagesPool { get; set; } = new List<ModalMessages>();
        public static string MyLanguage => LocalizationManager.CurrentLanguage;
        //Chinese
        //Chinese-TW
        //Korean
        //English
        //Japanese

        public static bool Init()
        {
            clog.tw("正在初始化模态消息池");
            try
            {
                MessagesPool = new List<ModalMessages>();

                #region 战斗开始部分
                var Text_Battle_Start_ModalMessages = new ModalMessages()
                {
                    ActionName = ModalKeyWords.Text_Battle_Start,
                    Sentences = new List<TranslationItem>()
                };
                var BattleStartSList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="缇娜，准备完毕。",
                        TraditionalChinese="緹娜，準備完畢。",
                        English="",
                        Japanese="Tina、準備完了。",
                        Korean=""
                    },new TranslationItem(){
                        Id=1,
                        SimplifiedChinese="环境温度较高，需尽快结束战斗。",
                        TraditionalChinese="環境溫度較高，需盡快結束戰鬥。",
                        English="",
                        Japanese="ここは熱きる、速やかに作戦を終わらせる。",
                        Korean=""
                    },new TranslationItem(){
                        Id=2,
                        SimplifiedChinese="这里是缇娜，我已抵达现场。",
                        TraditionalChinese="這裡是緹娜，我已抵達現場。",
                        English="",
                        Japanese="こじらTina、現場に着いた。",
                        Korean=""
                    },new TranslationItem(){
                        Id=3,
                        SimplifiedChinese="身体状况良好，战斗开始。",
                        TraditionalChinese="身體狀況良好，戰鬥開始。",
                        English="",
                        Japanese="胴体状態良好、作戦を開始する。",
                        Korean=""
                    },new TranslationItem(){
                        Id=4,
                        SimplifiedChinese="了解，战斗开始。",
                        TraditionalChinese="了解，戰鬥開始。",
                        English="",
                        Japanese="了解、作戦を開始する。",
                        Korean=""
                    },new TranslationItem(){
                        Id=5,
                        SimplifiedChinese="到我了么？",
                        TraditionalChinese="到我了麼？",
                        English="",
                        Japanese="私の出番か？",
                        Korean=""
                    },new TranslationItem(){
                        Id=6,
                        SimplifiedChinese="准备完毕，敌方目标在哪里？",
                        TraditionalChinese="準備完畢，敵方目標在哪裡？",
                        English="",
                        Japanese="準備完了、敵は何処だ？",
                        Korean=""
                    },new TranslationItem(){
                        Id=7,
                        SimplifiedChinese="不必担心，我不会疏忽大意。",
                        TraditionalChinese="不必擔心，我不會疏忽大意。",
                        English="",
                        Japanese="心配は無用です、油断はProgramされでいませんから。",
                        Korean=""
                    },new TranslationItem(){
                        Id=8,
                        SimplifiedChinese="敌方目标位置已确认，正在移动。",
                        TraditionalChinese="敵方目標位置已確認，正在移動。",
                        English="",
                        Japanese="敵の位置確認完了、移動する。",
                        Korean=""
                    },new TranslationItem(){
                        Id=9,
                        SimplifiedChinese="这里是缇娜，目标已确认。",
                        TraditionalChinese="這裡是緹娜，目標已確認。",
                        English="",
                        Japanese="こじらTina、目標を確認。",
                        Korean=""
                    },
                };
                Text_Battle_Start_ModalMessages.Sentences = BattleStartSList;
                MessagesPool.Add(Text_Battle_Start_ModalMessages);
                #endregion

                #region TODO战斗胜利部分
                var Text_Battle_End_ModalMessages = new ModalMessages()
                {
                    ActionName = "Text_Battle_End",
                    Sentences = new List<TranslationItem>()
                };
                var BattleEndSList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    }
                };
                Text_Battle_End_ModalMessages.Sentences = BattleEndSList;
                #endregion

                #region TODO自身濒死部分
                var Text_Battle_ND_ModalMessages = new ModalMessages()
                {
                    ActionName = "Text_Battle_ND",
                    Sentences = new List<TranslationItem>()
                };
                var BattleNDSList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    }
                };
                Text_Battle_ND_ModalMessages.Sentences = BattleNDSList;
                MessagesPool.Add(Text_Battle_ND_ModalMessages);
                #endregion

                #region TODO友军濒死部分
                var Text_Battle_AllyND_ModalMessages = new ModalMessages()
                {
                    ActionName = "Text_Battle_AllyND",
                    Sentences = new List<TranslationItem>()
                };
                var BattleAllyNDSList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    }
                };
                Text_Battle_AllyND_ModalMessages.Sentences = BattleAllyNDSList;
                MessagesPool.Add(Text_Battle_AllyND_ModalMessages);
                #endregion

                #region 魔女健康部分
                var Text_Battle_WitchCurseA_ModalMessages = new ModalMessages()
                {
                    ActionName = "Text_Battle_WitchCurseA",
                    Sentences = new List<TranslationItem>()
                };
                var WitchCurseASList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    }
                };
                Text_Battle_WitchCurseA_ModalMessages.Sentences = WitchCurseASList;
                MessagesPool.Add(Text_Battle_WitchCurseA_ModalMessages);
                #endregion

                #region 魔女濒死部分
                var Text_Battle_WitchCurseB_ModalMessages = new ModalMessages()
                {
                    ActionName = "Text_Battle_WitchCurseB",
                    Sentences = new List<TranslationItem>()
                };
                var WitchCurseBSList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    },
                    new TranslationItem(){
                        Id=1,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    },
                    new TranslationItem(){
                        Id=2,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    },
                };
                Text_Battle_WitchCurseB_ModalMessages.Sentences = WitchCurseBSList;
                MessagesPool.Add(Text_Battle_WitchCurseB_ModalMessages);
                #endregion

                #region 战斗中复活部分
                var Text_Battle_Rebirth_ModalMessages = new ModalMessages()
                {
                    ActionName = "Text_Battle_Rebirth",
                    Sentences = new List<TranslationItem>()
                };
                var BattleRebirthSList = new List<TranslationItem>()
                {
                    new TranslationItem(){
                        Id=0,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    },
                    new TranslationItem(){
                        Id=1,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    },
                    new TranslationItem(){
                        Id=2,
                        SimplifiedChinese="",
                        TraditionalChinese="",
                        English="",
                        Japanese="",
                        Korean=""
                    },
                };
                Text_Battle_Rebirth_ModalMessages.Sentences = BattleRebirthSList;
                MessagesPool.Add(Text_Battle_Rebirth_ModalMessages);
                #endregion

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static (long, string) GetActionInfo(string text)
        {
            long SentenceID = -1;
            string ActionName = MessagesPool.FirstOrDefault(t =>
            {
                var sentence = t.Sentences.FirstOrDefault(u => u.SimplifiedChinese == text || u.TraditionalChinese == text || u.English == text || u.Japanese == text || u.Korean == text);
                if (sentence != null)
                {
                    SentenceID = sentence.Id;
                    return true;
                }
                else return false;
            })?.ActionName ?? string.Empty;
            clog.tw($"捕获到消息弹窗！返回句子id为{SentenceID}，行动名为{ActionName}");
            return (SentenceID, ActionName);
        }

        public static string WordMap(string text)
        {
            switch (text)
            {
                case ModalKeyWords.Text_Battle_Start:
                    return TinaKeyWords.V_TinaIntro;
                case ModalKeyWords.Text_RebirthInBattle:
                    return TinaKeyWords.V_TinaRebirth;
                default:
                    return text;
            }
        }
    }
}
