using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersIseubi.KeyWords
{
    public static class IseubiKeyWords
    {
        /// <summary>
        /// B_MagicChip，Buff-魔法碎片
        /// </summary>
        public const string chip = "B_MagicChip";
        /// <summary>
        /// 魔法碎片，Buff-魔法碎片
        /// </summary>
        public const string cchip = "魔法碎片";
        /// <summary>
        /// B_MagicChip，Buff-魔法碎片
        /// </summary>
        public const string bc = chip;
        /// <summary>
        /// 魔法碎片，Buff-魔法碎片
        /// </summary>
        public const string cbc = cchip;
        /// <summary>
        /// B_MagicChip，Buff-魔法碎片
        /// </summary>
        public const string bmc = chip;
        /// <summary>
        /// B_LucyMagicChip，Buff-露西的魔法碎片
        /// </summary>
        public const string blmc = "B_LucyMagicChip";
        /// <summary>
        /// B_LucyMagicChipForAlly，Buff-魔法碎片加成(对友军)
        /// </summary>
        public const string blmcfa = "B_LucyMagicChipForAlly";
        /// <summary>
        /// 魔法碎片，Buff-魔法碎片
        /// </summary>
        public const string cbmc = cchip;
        /// <summary>
        /// B_LethalStrike，Buff-致命打击
        /// </summary>
        public const string bls = "B_LethalStrike";
        /// <summary>
        /// B_LethalStrikeEX，Buff-致命打击EX
        /// </summary>
        public const string blsex = "B_LethalStrikeEX";
        /// <summary>
        /// B_IraishinMode，Buff-飞雷神模式
        /// </summary>
        public const string birsm = "B_IraishinMode";
        /// <summary>
        /// B_IraishinBeacon，Buff-飞雷神标记
        /// </summary>
        public const string birsb = "B_IraishinBeacon";
        /// <summary>
        /// B_StormEyes，Buff-风暴之眼
        /// </summary>
        public const string bse = "B_StormEyes";
        /// <summary>
        /// B_ElectChain，Buff-闪电链
        /// </summary>
        public const string bec = "B_ElectChain";
        /// <summary>
        /// B_iseubiProxyBuff，Buff-李瑟钰代理buff
        /// </summary>
        public const string bipb = "B_iseubiProxyBuff";
        /// <summary>
        /// buff-抓取
        /// </summary>
        public const string big = nameof(B_Iseubi_grab);
        /// <summary>
        /// B_iseubiProxyBuff，Buff-李瑟钰代理buff
        /// </summary>
        public const string B_iseubiProxyBuff = bipb;
        /// <summary>
        /// B_LucyiseubiProxyBuff，Buff-露西李瑟钰代理buff
        /// </summary>
        public const string B_LucyiseubiProxyBuff = nameof(B_LucyiseubiProxyBuff);
        /// <summary>
        /// B_C5atk，Buff-召雷弹虚弱
        /// </summary>
        public const string B_C5atk = nameof(B_C5atk);
        /// <summary>
        /// B_ShinratenseExhausted，Buff-神罗天征疲惫
        /// </summary>
        public const string B_ShinratenseExhausted = nameof(B_ShinratenseExhausted);
        /// <summary>
        /// B_MyiseubiProxyBuff，Buff-李瑟钰自身代理buff
        /// </summary>
        public const string B_MyiseubiProxyBuff = nameof(B_MyiseubiProxyBuff);
        /// <summary>
        /// B_IraishinCover，Buff-时空间掩护
        /// </summary>
        public const string B_IraishinCover = nameof(B_IraishinCover);
        /// <summary>
        /// B_MultiGravity，Buff-重压
        /// </summary>
        public const string B_MultiGravity = nameof(B_MultiGravity);
        /// <summary>
        /// B_Iseubi_taunt，Buff-拦截
        /// </summary>
        public const string B_Iseubi_taunt = nameof(B_Iseubi_taunt);
        /// <summary>
        /// B_PursueAndAttack，Buff-乘胜追击
        /// </summary>
        public const string B_PursueAndAttack = nameof(B_PursueAndAttack);
        /// <summary>
        /// 李瑟钰
        /// </summary>
        public const string Iseubi = "Iseubi";
        /// <summary>
        /// 李瑟钰全称
        /// </summary>
        public const string fnIseubi = "李瑟钰(이슬비)";
        /// <summary>
        /// 技能-戒律之刃
        /// </summary>
        public const string C_iseubi0 = "C_iseubi0";
        /// <summary>
        /// 技能-雷遁·闪电风暴
        /// </summary>
        public const string C_iseubi1 = "C_iseubi1";
        /// <summary>
        /// 技能-雷遁·麒麟
        /// </summary>
        public const string C_iseubi1_0 = "C_iseubi1_0";
        /// <summary>
        /// 技能-重力场
        /// </summary>
        public const string C_iseubi2 = "C_iseubi2";
        /// <summary>
        /// 技能-雷遁·电磁枪
        /// </summary>
        public const string C_iseubi3 = "C_iseubi3";
        /// <summary>
        /// 电磁枪计数器
        /// </summary>
        public const string Ext_RailgunLiteCounter = nameof(Ext_RailgunLiteCounter);
        /// <summary>
        /// 技能-飞雷神·虫洞穿梭
        /// </summary>
        public const string C_iseubi4 = "C_iseubi4";
        /// <summary>
        /// Buff-虫洞穿梭计数器
        /// </summary>
        public const string B_iseubi4 = "B_iseubi4";
        /// <summary>
        /// 技能-雷遁·召雷弹
        /// </summary>
        public const string C_iseubi5 = "C_iseubi5";
        /// <summary>
        /// 技能-雷遁·召雷弹-电荷集束弹
        /// </summary>
        public const string C_iseubi5_0 = nameof(C_iseubi5_0);
        /// <summary>
        /// 技能-雷遁·召雷弹-电子破坏者
        /// </summary>
        public const string C_iseubi5_1 = nameof(C_iseubi5_1);
        /// <summary>
        /// 技能-万象天引
        /// </summary>
        public const string C_iseubi6 = "C_iseubi6";
        // <summary>
        /// 技能-万象天引·三连击
        /// </summary>
        public const string C_iseubi6_0 = "C_iseubi6_0";
        // <summary>
        /// 技能-万象天引·致命一击
        /// </summary>
        public const string C_iseubi6_1 = "C_iseubi6_1";
        /// <summary>
        /// 技能-神罗天征
        /// </summary>
        public const string C_iseubi7 = "C_iseubi7";
        /// <summary>
        /// 技能-飞雷神·神速
        /// </summary>
        public const string C_iseubi8 = "C_iseubi8";
		/// <summary>
		/// 技能-飞雷神·神速二段
		/// </summary>
		public const string C_iseubi8_0 = "C_iseubi8_0";
        /// <summary>
        /// 技能-飞雷神斩
        /// </summary>
        public const string C_iseubi9 = "C_iseubi9";
        /// <summary>
        /// 技能-飞雷神·互瞬回还
        /// </summary>
        public const string CO_iseubi10 = "CO_iseubi10";
        /// <summary>
        /// 技能-飞雷神·入场曲
        /// </summary>
        public const string C_iseubi10 = "C_iseubi10";
        /// <summary>
        /// 技能-雷遁·千鸟刀
        /// </summary>
        public const string C_iseubi11 = "C_iseubi11";
        /// <summary>
        /// 技能-雷遁·千鸟刀-移动到最上方
        /// </summary>
        public const string C_iseubi11_0 = nameof(C_iseubi11_0);
        /// <summary>
        /// 技能-雷遁·千鸟刀-移动到最下方
        /// </summary>
        public const string C_iseubi11_1 = nameof(C_iseubi11_1);
		/// <summary>
		/// 技能强化-雷遁·千鸟刀
		/// </summary>
		public const string C_isubi11_Extend = "C_isubi11_Extend";
		/// <summary>
		/// 技能强化-雷遁·千鸟刀
		/// </summary>
		public const string Ex_iseubi11 = "Ex_iseubi11";
        /// <summary>
        /// 技能-雷遁·超电磁炮
        /// </summary>
        public const string C_iseubi12 = "C_iseubi12";
        // <summary>
        /// 技能-雷遁·超电磁炮·连续闪光
        /// </summary>
        public const string C_iseubi12_0 = "C_iseubi12_0";
        // <summary>
        /// 技能-雷遁·超电磁炮·最终火花
        /// </summary>
        public const string C_iseubi12_1 = "C_iseubi12_1";
        /// <summary>
        /// 技能-飞雷神·地铁直击
        /// </summary>
        public const string C_iseubi13 = "C_iseubi13";
        /// <summary>
        /// 技能-飞雷神·地铁直击 派生技能
        /// </summary>
        public const string C_iseubi13_0 = nameof(C_iseubi13_0);
        /// <summary>
        /// 技能-三倍重力加速度
        /// </summary>
        public const string C_iseubi14 = nameof(C_iseubi14);
        /// <summary>
        /// 露西支援技能-红桃Q战术
        /// </summary>
        public const string CL_iseubi0 = "CL_iseubi0";
        /// <summary>
        /// 露西支援技能-红桃Q战术·雷击
        /// </summary>
        public const string CL_iseubi0_0 = "CL_iseubi0_0";
        /// <summary>
        /// 露西支援技能-红桃Q战术·闪光
        /// </summary>
        public const string CL_iseubi0_1 = "CL_iseubi0_1";
        /// <summary>
        /// 露西支援技能-红桃Q战术·重压
        /// </summary>
        public const string CL_iseubi0_2 = "CL_iseubi0_2";
        /// <summary>
        /// 露西支援技能-协同作战
        /// </summary>
        public const string CL_iseubi1 = "CL_iseubi1";
        /// <summary>
        /// 露西支援技能-协同作战·聚精会神
        /// </summary>
        public const string CL_iseubi1_0 = "CL_iseubi1_0";
        /// <summary>
        /// 露西支援技能-协同作战·乘胜追击
        /// </summary>
        public const string CL_iseubi1_1 = "CL_iseubi1_1";
        /// <summary>
        /// 技能强化-雷击充能
        /// </summary>
        public const string Ex_L_iseubi0_0 = "Ex_L_iseubi0_0";
        /// <summary>
        /// 标记-不视为生成。
        /// </summary>
        public const string CS_iseubi0 = nameof(CS_iseubi0);

        /// <summary>
        /// buff-重压
        /// </summary>
        public const string B_L_iseubi0_2 = "B_L_iseubi0_2";
        /// <summary>
        /// buff-抓取
        /// </summary>
        public const string B_Iseubi_grab = "B_Iseubi_grab";
        /// <summary>
        /// 取消选择
        /// </summary>
        public const string C_iseubi_Cancel = nameof(C_iseubi_Cancel);
        /// <summary>
        /// 电磁枪计数器
        /// </summary>
        public const string rlc = "Ext_RailgunLiteCounter";
		/// <summary>
		/// 协同强化-0-使用后为李瑟钰增加一枚魔法碎片。
		/// </summary>
		public const string CEn_iseubi0 = nameof(CEn_iseubi0);
		/// <summary>
		/// 协同强化-1-费用-1，但需要消耗李瑟钰的一枚魔法碎片，若不足，则无法使用。
		/// </summary>
		public const string CEn_iseubi1 = nameof(CEn_iseubi1);

		#region 音效

		#endregion

		#region 语音
		/// <summary>
		/// 语音-戒律之刃
		/// </summary>
		public const string V_LawDagger0 = "V_LawDagger0";
		/// <summary>
		/// 语音-戒律之刃
		/// </summary>
		public const string V_LawDagger1 = "V_LawDagger1";
		/// <summary>
		/// 语音-戒律之刃
		/// </summary>
		public const string V_LawDagger2 = "V_LawDagger2";
        /// <summary>
		/// 语音-戒律之刃
		/// </summary>
		public const string V_LawDagger = "V_LawDagger";
        /// <summary>
		/// 语音-神罗天征
		/// </summary>
		public const string V_Shinratense = "V_Shinratense";
        /// <summary>
		/// 语音-超电磁炮
		/// </summary>
		public const string V_Railgun = "V_Railgun";
        /// <summary>
		/// 语音-电磁枪
		/// </summary>
		public const string V_RailgunLite = "V_RailgunLite";
        /// <summary>
		/// 语音-麒麟
		/// </summary>
		public const string V_Lightning = "V_Lightning";
        /// <summary>
		/// 语音-地铁轰击
		/// </summary>
		public const string V_Metro = "V_Metro";
        /// <summary>
		/// 语音-神速
		/// </summary>
		public const string V_Shinsoku = "V_Shinsoku";
        /// <summary>
		/// 语音-飞雷神斩
		/// </summary>
		public const string V_Iraishingiri = nameof(V_Iraishingiri);
        /// <summary>
		/// 语音-闪避\格挡
		/// </summary>
		public const string V_HitBack = nameof(V_HitBack);
        /// <summary>
		/// 语音-战斗开始
		/// </summary>
		public const string V_Intro = nameof(V_Intro);
        /// <summary>
        /// 语音-战斗中复活
        /// </summary>
        public const string V_Rebirth = nameof(V_Rebirth);
        /// <summary>
		/// 语音-重力场
		/// </summary>
		public const string V_GravityField = nameof(V_GravityField);
        /// <summary>
		/// 语音-三倍地心引力
		/// </summary>
		public const string V_MultiGravity = nameof(V_MultiGravity); 
        /// <summary>
		/// 语音-万象天引
		/// </summary>
		public const string V_Gravitation = nameof(V_Gravitation);
        /// <summary>
		/// 语音-入场曲
		/// </summary>
		public const string V_Overture = nameof(V_Overture);
        /// <summary>
		/// 语音-召雷弹
		/// </summary>
		public const string V_ThunderForce = nameof(V_ThunderForce);
        /// <summary>
		/// 语音-协同作战
		/// </summary>
		public const string V_L = nameof(V_L);
        #endregion

        /// <summary>
        /// 李瑟钰当前经验值
        /// </summary>
        public const string iseubiEXP = nameof(iseubiEXP);
        // <summary>
        /// 李瑟钰当前流派
        /// </summary>
        public const string iseubiSect = nameof(iseubiSect);
		/// <summary>
		/// UI-李瑟钰进度条
		/// </summary>
		public const string Closers_Sylvi_ProgressBar = nameof(Closers_Sylvi_ProgressBar);
        /// <summary>
        /// UI-进度条呈现动画-砂砾单元
        /// </summary>
		public const string Closers_Sylvi_SandUnit = nameof(Closers_Sylvi_SandUnit);

	}
}
