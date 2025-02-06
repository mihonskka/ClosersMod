using ClosersIseubi.KeyWords;
using ClosersFramework.KeyWords;
using ClosersFramework.Models;
using ClosersFramework.Service;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.Service
{
    public static class IseubiModalMessageService
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
            clog.iw("正在初始化模态消息池");
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
                        SimplifiedChinese="目标确认，歼灭敌方目标。",
                        TraditionalChinese="目標確認，殲滅敵方目標。",
                        English="Enemy units detected!",
                        Japanese="目標確認、敵を殲滅つします。",
                        Korean="목표를 확인하고 적 목표물을 섬멸합니다."
                    },new TranslationItem(){
                        Id=1,
                        SimplifiedChinese="得快点了，直播就要开始了。没…没什么！",
                        TraditionalChinese="得快點了，直播就要開始了。沒…沒什麼！",
                        English="Hurry up，drama is about to start. I…I didn`t say that!",
                        Japanese="速くしないと、ドラマわ始まる。な…何でもありません！",
                        Korean="서둘러야겠어요, 생방송이 곧 시작됩니다. 아니…아닙니다!"
                    },new TranslationItem(){
                        Id=2,
                        SimplifiedChinese="没事的，我可以的。开始吧！",
                        TraditionalChinese="沒事的，我可以的。開始吧！",
                        English="No matter，I can do it. Go right ahead!",
                        Japanese="大丈夫、私わできる。行きます！",
                        Korean="괜찮습니다. 할 수 있어요. 시작합시다!"
                    },new TranslationItem(){
                        Id=3,
                        SimplifiedChinese="明白了，我将立即前往目标地点！",
                        TraditionalChinese="明白了，我將立即前往目標地點！",
                        English="Understood，I`m on the way.",
                        Japanese="了解しました、直ちに目標地点に向かいます。",
                        Korean="알겠습니다. 곧 목표 장소로 이동하겠습니다!"
                    },new TranslationItem(){
                        Id=4,
                        SimplifiedChinese="明白了，战斗开始。",
                        TraditionalChinese="明白了，戰鬥開始！",
                        English="Understood，now operation begin.",
                        Japanese="了解しました、これより作戦を開始します。",
                        Korean="알겠습니다. 전투를 시작합니다."
                    },new TranslationItem(){
                        Id=5,
                        SimplifiedChinese="李瑟钰，开始行动！",
                        TraditionalChinese="李瑟鈺，開始行動！",
                        English="Sylvi Lee，moving out!",
                        Japanese="ミコト　アマミヤ、しつどします！",
                        Korean="이슬비, 움직임을 시작하세요!"
                    },new TranslationItem(){
                        Id=6,
                        SimplifiedChinese="我相信你们。",
                        TraditionalChinese="我相信你們。",
                        English="Lucy，I trust you.",
                        Japanese="あなたたちの事、信じ出るわよ！",
                        Korean="당신을 믿습니다."
                    },new TranslationItem(){
                        Id=7,
                        SimplifiedChinese="不会辜负你的期望，我会加油的。",
                        TraditionalChinese="不會辜負你的期望，我會加油的。",
                        English="Won`t disappoint your expectations，I`ll go for it.",
                        Japanese="期待いにお答える出来るよ、頑張ります。",
                        Korean="기대를 저버리지 않고 힘내겠습니다."
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
                        SimplifiedChinese="交给我吧！",
                        TraditionalChinese="交給我吧！",
                        English="Leave it to me!",
                        Japanese="任せて！",
                        Korean="나한테 맡기세요!"
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
                        SimplifiedChinese="在我们都倒下之前，打败她！",
                        TraditionalChinese="在我們都倒下之前，打敗她！",
                        English="Defeat her, before we are defeated!",
                        Japanese="私たちに倒すの前に、彼女を倒す！",
                        Korean="우리 모두가 쓰러지기 전에 그녀를 물리칩시다!"
                    },
                    new TranslationItem(){
                        Id=1,
                        SimplifiedChinese="好痛……",
                        TraditionalChinese="好痛……",
                        English="Oh...Bad hurt.",
                        Japanese="痛い……",
                        Korean="고통스러워……"
                    },
                    new TranslationItem(){
                        Id=2,
                        SimplifiedChinese="我是不是…快要死了？",
                        TraditionalChinese="我是不是…快要死了？",
                        English="Am I nearing death now?",
                        Japanese="…もうすぐ死ぬでしょうか。",
                        Korean="저 혹시…곧 죽는 거 아닌가요?"
                    },
                };
                Text_Battle_WitchCurseB_ModalMessages.Sentences = WitchCurseBSList;
                MessagesPool.Add(Text_Battle_WitchCurseB_ModalMessages);
                #endregion

                #region 复活部分

                var Text_Rebirth_InBattle_ModalMessages = new ModalMessages()
                {
                    ActionName = ModalKeyWords.Text_RebirthInBattle,
                    Sentences = new List<TranslationItem>()
                };
                var RebirthInBattleSList = new List<TranslationItem>()
                {
                    new TranslationItem()
                    {
                        
                        SimplifiedChinese = "重新开始。",
                        TraditionalChinese = "重新開始。",
                        English = "Restarting.",
                        Japanese = "作戦再開します。",
                        Korean = "다시 시작."
                    },
                    new TranslationItem()
                    {
                        Id = 1,
                        SimplifiedChinese = "战斗继续，消灭敌方目标。",
                        TraditionalChinese = "戰鬥繼續，消滅敵方目標。",
                        English = "Continue working.",
                        Japanese = "戦闘続行、敵を殲滅します。",
                        Korean = "전투가 계속되어 적의 목표물을 소멸하다."
                    }
                };
                Text_Rebirth_InBattle_ModalMessages.Sentences = RebirthInBattleSList;
                MessagesPool.Add(Text_Rebirth_InBattle_ModalMessages);
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
            clog.iw($"捕获到消息弹窗！返回句子id为{SentenceID}，行动名为{ActionName}");
            return (SentenceID, ActionName);
        }

        public static string WordMap(string text)
        {
            switch (text)
            {
                case ModalKeyWords.Text_Battle_Start:
                    return IseubiKeyWords.V_Intro;
                case ModalKeyWords.Text_RebirthInBattle:
                    return IseubiKeyWords.V_Rebirth;
                default:
                    return text;
            }
        }
    }
}
/*
 主动弹出消息框
 BattleText.InstFieldText(this.MyChar.GetAllyWindow, this.MyChar.GetData.Text_Character[0]);
 */