using ClosersGalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersGalWPF.Controllers
{
    public class MainFormController
    {
        public MainFormController()
        {
            /*
            CharNameList.Add("IseubiTalkingKeyWords.iseubiName");
            CharNameList.Add("TalkingKeyWords.LucyName");
            CharNameList.Add("TinaTalkingKeyWords.TinaName");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_smile");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_unhappy");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_normal");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_nervous");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_shy");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_strict");
            FrontNameList.Add("IseubiTalkingKeyWords.iseubiStanding_upset");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_beloweye");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_bigsmile");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_nervous");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_normal");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_pain");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_smile");
            FrontNameList.Add("TinaTalkingKeyWords.TinaStanding_unhappy");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_normal");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_say");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_doubt");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_realize");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_panic");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_nervous");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_strict");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_pain");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_smile");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_scare");
            FaceNameList.Add("TalkingKeyWords.LucyFaceChip_gray");*/
            var keywordslist = new LoadTemplateController().LoadKeyWords();
            foreach (var i in keywordslist)
            {
                switch (i.MyListName)
                {
                    case "名称":
                        CharNameList.Add(i);
                        break;
                    case "大立绘":
                        FrontNameList.Add(i);
                        break;
                    case "小立绘":
                        FaceNameList.Add(i);
                        break;
                    case "音效":
                        AudioNameList.Add(i);
                        break;
                }
            }
        }
        public List<KeyWordUnit> CharNameList = new();//1
        public List<KeyWordUnit> FrontNameList = new();//2
        public List<KeyWordUnit> FaceNameList = new();//3
        public List<KeyWordUnit> AudioNameList = new();//4
        public int NowList = 1;
        public List<TalkNode> NodeList = new();
        public string GenerateTree()
        {
            var rv = new LoadTemplateController().LoadTalkTemp();
            for (int i = 0; i < NodeList.Count - 1; i++)
                NodeList[i].NextNodeName = NodeList[i + 1].NodeName;
            var codes = NodeList.Select(t => t.Code);
            return rv.Replace("%nodes%", string.Join(Environment.NewLine, codes));
        }
        public void RefreshNodeList()
        {
            for(var i = 0; i < NodeList.Count; i++)
                NodeList[i].seq = i;
        }
        public TalkNode NewNode(string NodeName, string CharName, string Content, string FrontName, string FaceName, string AudioName) => new TalkNode() { AudioName = AudioName, NodeName = NodeName, CharName = CharName, Content = Content, FrontName = FrontName, FaceName = FaceName };
        
    }
}
