using ClosersGalWPF.Controllers;
using ClosersGalWPF.Helpers;
using ClosersGalWPF.Models;
using static System.Windows.Forms.ListBox;
using System.Windows;

namespace ClosersGalWPF
{
	public partial class MainForm : Form
	{
		public MainFormController Controller { get; set; }
		public MainForm()
		{
			InitializeComponent();
			Controller = new();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ResultTb.Text = new GenerateController().Generate(NodeTb.Text, CharTb.Text, ContentTb.Text, FrontTb.Text, FaceTb.Text, AudioTb.Text, string.Empty);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		//label facename
		private void label3_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.FaceNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 3;
			NowListLabel.Text = "FaceNameList";
		}

		//label charname
		private void label2_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.CharNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 1;
			NowListLabel.Text = "CharNameList";
		}

		//label front name
		private void label4_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.FrontNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 2;
			NowListLabel.Text = "FrontNameList";
		}

		//label audio name
		private void label5_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.AudioNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 4;
			NowListLabel.Text = "AudioNameList";
		}

		public void ElementLBRefresh()
		{
			ElementLB.Items.Clear();
			switch (Controller.NowList)
			{
				case 1:
					Controller.CharNameList.ForEach(t => ElementLB.Items.Add(t.Key));
					break;
				case 2:
					Controller.FrontNameList.ForEach(t => ElementLB.Items.Add(t.Key));
					break;
				case 3:
					Controller.FaceNameList.ForEach(t => ElementLB.Items.Add(t.Key));
					break;
				case 4:
					Controller.AudioNameList.ForEach(t => ElementLB.Items.Add(t.Key));
					break;
				default:
					break;
			}
		}

		private void ElementLB_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void AddEleBtn_Click(object sender, EventArgs e)
		{
			/*
            switch (Controller.NowList)
            {
                case 1:
                    Controller.CharNameList.AddNoRepeat(CharTb.Text);
                    break;
                case 2:
                    Controller.FrontNameList.AddNoRepeat(FrontTb.Text);
                    break;
                case 3:
                    Controller.FaceNameList.AddNoRepeat(FaceTb.Text);
                    break;
                case 4:
                    Controller.AudioNameList.AddNoRepeat(AudioTb.Text);
                    break;
                default:
                    break;
            }*/
			ElementLBRefresh();
		}

		private void DelEleBtn_Click(object sender, EventArgs e)
		{
			/*
            switch (Controller.NowList)
            {
                case 1:
                    Controller.CharNameList.Remove(ElementLB.SelectedItem?.ToString() ?? string.Empty);
                    break;
                case 2:
                    Controller.FrontNameList.Remove(ElementLB.SelectedItem?.ToString() ?? string.Empty);
                    break;
                case 3:
                    Controller.FaceNameList.Remove(ElementLB.SelectedItem?.ToString() ?? string.Empty);
                    break;
                case 4:
                    Controller.AudioNameList.Remove(ElementLB.SelectedItem?.ToString() ?? string.Empty);
                    break;
                default:
                    break;
            }*/
			ElementLBRefresh();
		}

		private void ElementLB_DoubleClick(object sender, EventArgs e)
		{
			var item = Controller.CharNameList.Union(Controller.AudioNameList).Union(Controller.FaceNameList).Union(Controller.FrontNameList).FirstOrDefault(t => t.Key == ElementLB.SelectedItem?.ToString());
			switch (item.MyListName)
			{
				case "√˚≥∆":
					CharTb.Text = item.Value ?? string.Empty;
					break;
				case "¥Û¡¢ªÊ":
					FrontTb.Text = item.Value ?? string.Empty;
					break;
				case "–°¡¢ªÊ":
					FaceTb.Text = item.Value ?? string.Empty;
					break;
				case "“Ù–ß":
					AudioTb.Text = item.Value ?? string.Empty;
					break;
				default:
					break;
			}
		}

		private void InitTalkBtn_Click(object sender, EventArgs e)
		{

		}

		private void AddNodeBtn_Click(object sender, EventArgs e)
		{
			TalkNode node = new() { seq = Controller.NodeList.Count, CharName = CharTb.Text, AudioName = AudioTb.Text, Content = ContentTb.Text, FaceName = FaceTb.Text, FrontName = FrontTb.Text, NodeName = NodeTb.Text };
			if (Controller.NodeList.Any(t => t.NodeName == node.NodeName))
			{
				MessageBox.Show("NodeName÷ÿ∏¥°£");
				return;
			}
			else if (string.IsNullOrWhiteSpace(node.NodeName))
			{
				MessageBox.Show("NodeName≤ªø…Œ™ø’°£");
				return;
			}
			Controller.NodeList.Add(node);
			if (NodeTb.Text?.TailNumber() == null ? false : true)
			{
				var stack = new Stack<char>();
				var flag = false;
				for (var i = NodeTb.Text.Length - 1; i >= 0; i--)
				{
					if (flag || !char.IsNumber(NodeTb.Text[i]))
					{
						flag = true;
						stack.Push(NodeTb.Text[i]);
					}
				}
				if (stack.Count < 0)
				{
					MessageBox.Show("NodeName≤ªø…Œ™¥ø ˝◊÷°£");
					return;
				}
				var result = new string(stack.ToArray());
				NodeTb.Text = result + ((NodeTb.Text.TailNumber() ?? 0) + 1).ToString();
			}
			else
			{
				NodeTb.Text = NodeTb.Text + "0";
			}
			NodeLBRefresh();
		}

		private void NodeLB_SelectedIndexChanged(object sender, EventArgs e)
		{
			var node = Controller.NodeList.FirstOrDefault(t => t.NodeName == SelectedNodeName());
			if (node == null) return;
			CharTb.Text = node.CharName;
			FaceTb.Text = node.FaceName;
			NodeTb.Text = node.NodeName;
			FrontTb.Text = node.FrontName;
			AudioTb.Text = node.AudioName;
			ContentTb.Text = node.Content;
		}
		public void NodeLBRefresh()
		{
			NodeLB.Items.Clear();
			Controller.NodeList.ForEach(t => NodeLB.Items.Add(t.Show));
		}

		private void DelNodeBtn_Click(object sender, EventArgs e)
		{
			if (SelectedNodeName() != null)
				Controller.NodeList.RemoveAll(t => t.NodeName == SelectedNodeName());
			NodeLBRefresh();
		}

		public string SelectedNodeName()
		{
			var nodeName = NodeLB.SelectedItem?.ToString()?.Split(' ').ToList();
			nodeName?.RemoveAll(t => string.IsNullOrWhiteSpace(t));
			return nodeName?[1] ?? string.Empty;
		}

		private void TreeGenerateBtn_Click(object sender, EventArgs e)
		{
			ResultTb.Text = Controller.GenerateTree();
		}

		private void ToTopBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Controller.NodeList.Count; i++)
			{
				if (Controller.NodeList[i].NodeName == SelectedNodeName())
				{
					var temp = (TalkNode)Controller.NodeList[0].DeepClone();
					Controller.NodeList[0] = (TalkNode)Controller.NodeList[i].DeepClone();
					Controller.NodeList[i] = temp;
				}
			}
			NodeLBRefresh();
			NodeLB.SelectedIndex = 0;
		}

		private void ToBottomBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Controller.NodeList.Count; i++)
			{
				if (Controller.NodeList[i].NodeName == SelectedNodeName())
				{
					var temp = (TalkNode)Controller.NodeList[Controller.NodeList.Count - 1].DeepClone();
					Controller.NodeList[Controller.NodeList.Count - 1] = (TalkNode)Controller.NodeList[i].DeepClone();
					Controller.NodeList[i] = temp;
				}
			}
			NodeLBRefresh();
			NodeLB.SelectedIndex = Controller.NodeList.Count - 1;
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			int a = 0;
			for (int i = 0; i < Controller.NodeList.Count; i++)
			{
				if (i - 1 < 0) continue;
				if (Controller.NodeList[i].NodeName == SelectedNodeName())
				{
					var temp = (TalkNode)Controller.NodeList[i - 1].DeepClone();
					Controller.NodeList[i - 1] = (TalkNode)Controller.NodeList[i].DeepClone();
					Controller.NodeList[i] = temp;
					a = i - 1;
					break;
				}
			}
			NodeLBRefresh();
			NodeLB.SelectedIndex = a;
		}

		private void DownBtn_Click(object sender, EventArgs e)
		{
			int a = 0;
			for (int i = 0; i < Controller.NodeList.Count; i++)
			{
				if (i + 1 >= Controller.NodeList.Count) continue;
				if (Controller.NodeList[i].NodeName == SelectedNodeName())
				{
					var temp = (TalkNode)Controller.NodeList[i + 1].DeepClone();
					Controller.NodeList[i + 1] = (TalkNode)Controller.NodeList[i].DeepClone();
					Controller.NodeList[i] = temp;
					a = i + 1;
					break;
				}
			}
			NodeLBRefresh();
			NodeLB.SelectedIndex = a;
		}

		private void SwitchCharButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.CharNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 1;
			NowListLabel.Text = "CharNameList";
		}

		private void SwitchFaceButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.FaceNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 3;
			NowListLabel.Text = "FaceNameList";
		}

		private void SwitchFrontButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.FrontNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 2;
			NowListLabel.Text = "FrontNameList";
		}

		private void SwitchAudioButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.AudioNameList.ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.NowList = 4;
			NowListLabel.Text = "AudioNameList";
		}

		private void PhoenixBtn_Click_1(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.CharNameList.Where(t => t.MyCharacter == "∑ÔªÀ").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == "∑ÔªÀ").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == "∑ÔªÀ").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == "∑ÔªÀ").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = "∑ÔªÀ";
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{

		}

		private void BGButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.CharNameList.Where(t => t.MyListName == "todo").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyListName == "todo").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyListName == "todo").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyListName == "todo").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = "BG";
		}

		private void AzarButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.CharNameList.Where(t => t.MyCharacter == "∞¢‘˙∂˚").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == "∞¢‘˙∂˚").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == "∞¢‘˙∂˚").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == "∞¢‘˙∂˚").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = "∞¢‘˙∂˚";
		}

		private void LucyButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			Controller.CharNameList.Where(t => t.MyCharacter == "¬∂Œ˜").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == "¬∂Œ˜").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == "¬∂Œ˜").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == "¬∂Œ˜").ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = "¬∂Œ˜";
		}

		private void ArkElseButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			var key = "∑Ω÷€≈‰Ω«";
			Controller.CharNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = key;
		}

		private void ArkButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			var ArkNameList = new List<string>() { "¬∂Œ˜", "∑ÔªÀ", "∞¢‘˙∂˚", "∑Ω÷€≈‰Ω«"};
			Controller.CharNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = "∑Ω÷€";
		}

		private void IseubiButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			var key = "¿Ó…™Ó⁄";
			Controller.CharNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = key;
		}

		private void TinaButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			var key = "Áæƒ»";
			Controller.CharNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = key;
		}

		private void ClosersElseButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			var key = "Clo≈‰Ω«";
			Controller.CharNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => t.MyCharacter == key).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = key;
		}

		private void ClosersButton_Click(object sender, EventArgs e)
		{
			ElementLB.Items.Clear();
			var ArkNameList = new List<string>() { "¿Ó…™Ó⁄", "Áæƒ»", "Clo≈‰Ω«" };
			Controller.CharNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FrontNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.FaceNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			Controller.AudioNameList.Where(t => ArkNameList.Contains(t.MyCharacter)).ToList().ForEach(t => ElementLB.Items.Add(t.Key));
			NowListLabel.Text = "Closers";
		}
	}
}
