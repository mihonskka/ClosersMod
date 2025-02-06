namespace ClosersGalWPF
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			GenerateBtn = new Button();
			NodeTb = new TextBox();
			label1 = new Label();
			label2 = new Label();
			CharTb = new TextBox();
			label3 = new Label();
			FaceTb = new TextBox();
			label4 = new Label();
			FrontTb = new TextBox();
			label5 = new Label();
			AudioTb = new TextBox();
			ContentTb = new RichTextBox();
			label6 = new Label();
			label7 = new Label();
			ResultTb = new RichTextBox();
			NodeLB = new ListBox();
			ElementLB = new ListBox();
			ToTopBtn = new Button();
			UpBtn = new Button();
			DownBtn = new Button();
			ToBottomBtn = new Button();
			AddNodeBtn = new Button();
			DelNodeBtn = new Button();
			label8 = new Label();
			InitTalkBtn = new Button();
			label9 = new Label();
			NowListLabel = new Label();
			TreeGenerateBtn = new Button();
			SwitchCharButton = new Button();
			SwitchFaceButton = new Button();
			SwitchFrontButton = new Button();
			SwitchAudioButton = new Button();
			PhoenixButton = new Button();
			AzarButton = new Button();
			ArkElseButton = new Button();
			IseubiButton = new Button();
			ArkButton = new Button();
			BGButton = new Button();
			LucyButton = new Button();
			TinaButton = new Button();
			ClosersElseButton = new Button();
			ClosersButton = new Button();
			SearchTB = new TextBox();
			SearchButton = new Button();
			SuspendLayout();
			// 
			// GenerateBtn
			// 
			GenerateBtn.Location = new Point(698, 706);
			GenerateBtn.Name = "GenerateBtn";
			GenerateBtn.Size = new Size(177, 57);
			GenerateBtn.TabIndex = 0;
			GenerateBtn.Text = "NodeGenerate";
			GenerateBtn.UseVisualStyleBackColor = true;
			GenerateBtn.Click += button1_Click;
			// 
			// NodeTb
			// 
			NodeTb.Location = new Point(551, 397);
			NodeTb.Name = "NodeTb";
			NodeTb.Size = new Size(324, 23);
			NodeTb.TabIndex = 1;
			NodeTb.TextChanged += textBox1_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(469, 400);
			label1.Name = "label1";
			label1.Size = new Size(76, 17);
			label1.TabIndex = 2;
			label1.Text = "NodeName";
			label1.Click += label1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(469, 429);
			label2.Name = "label2";
			label2.Size = new Size(70, 17);
			label2.TabIndex = 4;
			label2.Text = "CharName";
			label2.Click += label2_Click;
			// 
			// CharTb
			// 
			CharTb.Location = new Point(551, 426);
			CharTb.Name = "CharTb";
			CharTb.Size = new Size(324, 23);
			CharTb.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(469, 458);
			label3.Name = "label3";
			label3.Size = new Size(69, 17);
			label3.TabIndex = 6;
			label3.Text = "FaceName";
			label3.Click += label3_Click;
			// 
			// FaceTb
			// 
			FaceTb.Location = new Point(551, 455);
			FaceTb.Name = "FaceTb";
			FaceTb.Size = new Size(324, 23);
			FaceTb.TabIndex = 5;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(469, 487);
			label4.Name = "label4";
			label4.Size = new Size(73, 17);
			label4.TabIndex = 8;
			label4.Text = "FrontName";
			label4.Click += label4_Click;
			// 
			// FrontTb
			// 
			FrontTb.Location = new Point(551, 484);
			FrontTb.Name = "FrontTb";
			FrontTb.Size = new Size(324, 23);
			FrontTb.TabIndex = 7;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(469, 516);
			label5.Name = "label5";
			label5.Size = new Size(77, 17);
			label5.TabIndex = 10;
			label5.Text = "AudioName";
			label5.Click += label5_Click;
			// 
			// AudioTb
			// 
			AudioTb.Location = new Point(551, 513);
			AudioTb.Name = "AudioTb";
			AudioTb.Size = new Size(324, 23);
			AudioTb.TabIndex = 9;
			// 
			// ContentTb
			// 
			ContentTb.Location = new Point(472, 573);
			ContentTb.Name = "ContentTb";
			ContentTb.Size = new Size(403, 127);
			ContentTb.TabIndex = 11;
			ContentTb.Text = "";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(469, 553);
			label6.Name = "label6";
			label6.Size = new Size(53, 17);
			label6.TabIndex = 12;
			label6.Text = "Content";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(898, 7);
			label7.Name = "label7";
			label7.Size = new Size(43, 17);
			label7.TabIndex = 13;
			label7.Text = "Result";
			label7.Click += label7_Click;
			// 
			// ResultTb
			// 
			ResultTb.Location = new Point(898, 27);
			ResultTb.Name = "ResultTb";
			ResultTb.Size = new Size(498, 736);
			ResultTb.TabIndex = 14;
			ResultTb.Text = "";
			// 
			// NodeLB
			// 
			NodeLB.FormattingEnabled = true;
			NodeLB.ItemHeight = 17;
			NodeLB.Location = new Point(7, 14);
			NodeLB.Name = "NodeLB";
			NodeLB.Size = new Size(410, 752);
			NodeLB.TabIndex = 15;
			NodeLB.SelectedIndexChanged += NodeLB_SelectedIndexChanged;
			// 
			// ElementLB
			// 
			ElementLB.FormattingEnabled = true;
			ElementLB.ItemHeight = 17;
			ElementLB.Location = new Point(473, 149);
			ElementLB.Name = "ElementLB";
			ElementLB.Size = new Size(402, 242);
			ElementLB.TabIndex = 16;
			ElementLB.SelectedIndexChanged += ElementLB_SelectedIndexChanged;
			ElementLB.DoubleClick += ElementLB_DoubleClick;
			// 
			// ToTopBtn
			// 
			ToTopBtn.Location = new Point(437, 60);
			ToTopBtn.Name = "ToTopBtn";
			ToTopBtn.Size = new Size(30, 29);
			ToTopBtn.TabIndex = 19;
			ToTopBtn.Text = "↑↑";
			ToTopBtn.UseVisualStyleBackColor = true;
			ToTopBtn.Click += ToTopBtn_Click;
			// 
			// UpBtn
			// 
			UpBtn.Location = new Point(437, 106);
			UpBtn.Name = "UpBtn";
			UpBtn.Size = new Size(30, 27);
			UpBtn.TabIndex = 20;
			UpBtn.Text = "↑";
			UpBtn.UseVisualStyleBackColor = true;
			UpBtn.Click += UpBtn_Click;
			// 
			// DownBtn
			// 
			DownBtn.Location = new Point(437, 153);
			DownBtn.Name = "DownBtn";
			DownBtn.Size = new Size(30, 29);
			DownBtn.TabIndex = 21;
			DownBtn.Text = "↓";
			DownBtn.UseVisualStyleBackColor = true;
			DownBtn.Click += DownBtn_Click;
			// 
			// ToBottomBtn
			// 
			ToBottomBtn.Location = new Point(437, 201);
			ToBottomBtn.Name = "ToBottomBtn";
			ToBottomBtn.Size = new Size(30, 32);
			ToBottomBtn.TabIndex = 22;
			ToBottomBtn.Text = "↓↓";
			ToBottomBtn.UseVisualStyleBackColor = true;
			ToBottomBtn.Click += ToBottomBtn_Click;
			// 
			// AddNodeBtn
			// 
			AddNodeBtn.Location = new Point(437, 258);
			AddNodeBtn.Name = "AddNodeBtn";
			AddNodeBtn.Size = new Size(30, 32);
			AddNodeBtn.TabIndex = 23;
			AddNodeBtn.Text = "←";
			AddNodeBtn.UseVisualStyleBackColor = true;
			AddNodeBtn.Click += AddNodeBtn_Click;
			// 
			// DelNodeBtn
			// 
			DelNodeBtn.Location = new Point(437, 313);
			DelNodeBtn.Name = "DelNodeBtn";
			DelNodeBtn.Size = new Size(30, 29);
			DelNodeBtn.TabIndex = 24;
			DelNodeBtn.Text = "×";
			DelNodeBtn.UseVisualStyleBackColor = true;
			DelNodeBtn.Click += DelNodeBtn_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(479, 12);
			label8.Name = "label8";
			label8.Size = new Size(103, 17);
			label8.TabIndex = 25;
			label8.Text = "SelectedElement";
			// 
			// InitTalkBtn
			// 
			InitTalkBtn.Location = new Point(437, 363);
			InitTalkBtn.Name = "InitTalkBtn";
			InitTalkBtn.Size = new Size(37, 29);
			InitTalkBtn.TabIndex = 26;
			InitTalkBtn.Text = "Init";
			InitTalkBtn.UseVisualStyleBackColor = true;
			InitTalkBtn.Click += InitTalkBtn_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(479, 30);
			label9.Name = "label9";
			label9.Size = new Size(57, 17);
			label9.TabIndex = 27;
			label9.Text = "NowList:";
			// 
			// NowListLabel
			// 
			NowListLabel.AutoSize = true;
			NowListLabel.Location = new Point(542, 30);
			NowListLabel.Name = "NowListLabel";
			NowListLabel.Size = new Size(31, 17);
			NowListLabel.TabIndex = 28;
			NowListLabel.Text = "Null";
			// 
			// TreeGenerateBtn
			// 
			TreeGenerateBtn.Location = new Point(473, 706);
			TreeGenerateBtn.Name = "TreeGenerateBtn";
			TreeGenerateBtn.Size = new Size(181, 57);
			TreeGenerateBtn.TabIndex = 29;
			TreeGenerateBtn.Text = "TalkGenerate";
			TreeGenerateBtn.UseVisualStyleBackColor = true;
			TreeGenerateBtn.Click += TreeGenerateBtn_Click;
			// 
			// SwitchCharButton
			// 
			SwitchCharButton.Location = new Point(473, 60);
			SwitchCharButton.Name = "SwitchCharButton";
			SwitchCharButton.Size = new Size(75, 23);
			SwitchCharButton.TabIndex = 30;
			SwitchCharButton.Text = "角色名";
			SwitchCharButton.UseVisualStyleBackColor = true;
			SwitchCharButton.Click += SwitchCharButton_Click;
			// 
			// SwitchFaceButton
			// 
			SwitchFaceButton.Location = new Point(557, 60);
			SwitchFaceButton.Name = "SwitchFaceButton";
			SwitchFaceButton.Size = new Size(75, 23);
			SwitchFaceButton.TabIndex = 31;
			SwitchFaceButton.Text = "小立绘";
			SwitchFaceButton.UseVisualStyleBackColor = true;
			SwitchFaceButton.Click += SwitchFaceButton_Click;
			// 
			// SwitchFrontButton
			// 
			SwitchFrontButton.Location = new Point(638, 60);
			SwitchFrontButton.Name = "SwitchFrontButton";
			SwitchFrontButton.Size = new Size(75, 23);
			SwitchFrontButton.TabIndex = 32;
			SwitchFrontButton.Text = "大立绘";
			SwitchFrontButton.UseVisualStyleBackColor = true;
			SwitchFrontButton.Click += SwitchFrontButton_Click;
			// 
			// SwitchAudioButton
			// 
			SwitchAudioButton.Location = new Point(719, 60);
			SwitchAudioButton.Name = "SwitchAudioButton";
			SwitchAudioButton.Size = new Size(75, 23);
			SwitchAudioButton.TabIndex = 33;
			SwitchAudioButton.Text = "音效";
			SwitchAudioButton.UseVisualStyleBackColor = true;
			SwitchAudioButton.Click += SwitchAudioButton_Click;
			// 
			// PhoenixButton
			// 
			PhoenixButton.Location = new Point(473, 89);
			PhoenixButton.Name = "PhoenixButton";
			PhoenixButton.Size = new Size(75, 23);
			PhoenixButton.TabIndex = 34;
			PhoenixButton.Text = "凤凰";
			PhoenixButton.UseVisualStyleBackColor = true;
			PhoenixButton.Click += PhoenixBtn_Click_1;
			// 
			// AzarButton
			// 
			AzarButton.Location = new Point(557, 89);
			AzarButton.Name = "AzarButton";
			AzarButton.Size = new Size(75, 23);
			AzarButton.TabIndex = 35;
			AzarButton.Text = "阿扎尔";
			AzarButton.UseVisualStyleBackColor = true;
			AzarButton.Click += AzarButton_Click;
			// 
			// ArkElseButton
			// 
			ArkElseButton.Location = new Point(719, 89);
			ArkElseButton.Name = "ArkElseButton";
			ArkElseButton.Size = new Size(75, 23);
			ArkElseButton.TabIndex = 36;
			ArkElseButton.Text = "方舟配角";
			ArkElseButton.UseVisualStyleBackColor = true;
			ArkElseButton.Click += ArkElseButton_Click;
			// 
			// IseubiButton
			// 
			IseubiButton.Location = new Point(473, 118);
			IseubiButton.Name = "IseubiButton";
			IseubiButton.Size = new Size(75, 23);
			IseubiButton.TabIndex = 37;
			IseubiButton.Text = "李瑟钰";
			IseubiButton.UseVisualStyleBackColor = true;
			IseubiButton.Click += IseubiButton_Click;
			// 
			// ArkButton
			// 
			ArkButton.Location = new Point(800, 89);
			ArkButton.Name = "ArkButton";
			ArkButton.Size = new Size(75, 23);
			ArkButton.TabIndex = 38;
			ArkButton.Text = "方舟";
			ArkButton.UseVisualStyleBackColor = true;
			ArkButton.Click += ArkButton_Click;
			// 
			// BGButton
			// 
			BGButton.Location = new Point(800, 60);
			BGButton.Name = "BGButton";
			BGButton.Size = new Size(75, 23);
			BGButton.TabIndex = 39;
			BGButton.Text = "背景图";
			BGButton.UseVisualStyleBackColor = true;
			BGButton.Click += BGButton_Click;
			// 
			// LucyButton
			// 
			LucyButton.Location = new Point(638, 89);
			LucyButton.Name = "LucyButton";
			LucyButton.Size = new Size(75, 23);
			LucyButton.TabIndex = 40;
			LucyButton.Text = "露西";
			LucyButton.UseVisualStyleBackColor = true;
			LucyButton.Click += LucyButton_Click;
			// 
			// TinaButton
			// 
			TinaButton.Location = new Point(557, 118);
			TinaButton.Name = "TinaButton";
			TinaButton.Size = new Size(75, 23);
			TinaButton.TabIndex = 41;
			TinaButton.Text = "缇娜";
			TinaButton.UseVisualStyleBackColor = true;
			TinaButton.Click += TinaButton_Click;
			// 
			// ClosersElseButton
			// 
			ClosersElseButton.Location = new Point(638, 118);
			ClosersElseButton.Name = "ClosersElseButton";
			ClosersElseButton.Size = new Size(75, 23);
			ClosersElseButton.TabIndex = 42;
			ClosersElseButton.Text = "Clo配角";
			ClosersElseButton.UseVisualStyleBackColor = true;
			ClosersElseButton.Click += ClosersElseButton_Click;
			// 
			// ClosersButton
			// 
			ClosersButton.Location = new Point(719, 118);
			ClosersButton.Name = "ClosersButton";
			ClosersButton.Size = new Size(75, 23);
			ClosersButton.TabIndex = 43;
			ClosersButton.Text = "Closers";
			ClosersButton.UseVisualStyleBackColor = true;
			ClosersButton.Click += ClosersButton_Click;
			// 
			// SearchTB
			// 
			SearchTB.Location = new Point(684, 30);
			SearchTB.Name = "SearchTB";
			SearchTB.Size = new Size(110, 23);
			SearchTB.TabIndex = 44;
			// 
			// SearchButton
			// 
			SearchButton.Location = new Point(800, 31);
			SearchButton.Name = "SearchButton";
			SearchButton.Size = new Size(75, 23);
			SearchButton.TabIndex = 45;
			SearchButton.Text = "搜索";
			SearchButton.UseVisualStyleBackColor = true;
			SearchButton.Click += SearchButton_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1408, 775);
			Controls.Add(SearchButton);
			Controls.Add(SearchTB);
			Controls.Add(ClosersButton);
			Controls.Add(ClosersElseButton);
			Controls.Add(TinaButton);
			Controls.Add(LucyButton);
			Controls.Add(BGButton);
			Controls.Add(ArkButton);
			Controls.Add(IseubiButton);
			Controls.Add(ArkElseButton);
			Controls.Add(AzarButton);
			Controls.Add(PhoenixButton);
			Controls.Add(SwitchAudioButton);
			Controls.Add(SwitchFrontButton);
			Controls.Add(SwitchFaceButton);
			Controls.Add(SwitchCharButton);
			Controls.Add(TreeGenerateBtn);
			Controls.Add(NowListLabel);
			Controls.Add(label9);
			Controls.Add(InitTalkBtn);
			Controls.Add(label8);
			Controls.Add(DelNodeBtn);
			Controls.Add(AddNodeBtn);
			Controls.Add(ToBottomBtn);
			Controls.Add(DownBtn);
			Controls.Add(UpBtn);
			Controls.Add(ToTopBtn);
			Controls.Add(ElementLB);
			Controls.Add(NodeLB);
			Controls.Add(ResultTb);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(ContentTb);
			Controls.Add(label5);
			Controls.Add(AudioTb);
			Controls.Add(label4);
			Controls.Add(FrontTb);
			Controls.Add(label3);
			Controls.Add(FaceTb);
			Controls.Add(label2);
			Controls.Add(CharTb);
			Controls.Add(label1);
			Controls.Add(NodeTb);
			Controls.Add(GenerateBtn);
			Name = "MainForm";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button GenerateBtn;
        private TextBox NodeTb;
        private Label label1;
        private Label label2;
        private TextBox CharTb;
        private Label label3;
        private TextBox FaceTb;
        private Label label4;
        private TextBox FrontTb;
        private Label label5;
        private TextBox AudioTb;
        private RichTextBox ContentTb;
        private Label label6;
        private Label label7;
        private RichTextBox ResultTb;
        private ListBox NodeLB;
        private ListBox ElementLB;
        private Button ToTopBtn;
        private Button UpBtn;
        private Button DownBtn;
        private Button ToBottomBtn;
        private Button AddNodeBtn;
        private Button DelNodeBtn;
        private Label label8;
        private Button InitTalkBtn;
        private Label label9;
        private Label NowListLabel;
        private Button TreeGenerateBtn;
        private Button SwitchCharButton;
        private Button SwitchFaceButton;
        private Button SwitchFrontButton;
        private Button SwitchAudioButton;
		private Button PhoenixButton;
		private Button AzarButton;
		private Button ArkElseButton;
		private Button IseubiButton;
		private Button ArkButton;
		private Button BGButton;
		private Button LucyButton;
		private Button TinaButton;
		private Button ClosersElseButton;
		private Button ClosersButton;
		private TextBox SearchTB;
		private Button SearchButton;
	}
}
