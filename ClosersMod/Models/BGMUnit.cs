using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models
{
	public class BGMUnit : SoundUnit
	{
		public bool Loop { get; set; }
		public int Duration { get; set; }

		public BGMUnit Intro { get; set; }
	}
}
