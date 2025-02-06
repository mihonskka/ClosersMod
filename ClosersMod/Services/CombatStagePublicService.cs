using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
	/// <summary>
	/// 战斗阶段公共服务
	/// </summary>
	public class CombatStagePublicService
	{
		public static CombatStagePublicService Instance { get; set; }
		public static void Reset()
		{
			Instance = new CombatStagePublicService();
		}
		public List<Skill> SkillMemory { get; set; }
	}
}
