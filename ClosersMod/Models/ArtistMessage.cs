using ClosersFramework.Service;
using ClosersFramework.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Models
{
	public class ArtistMessage: SubProgramMessage
	{
		public byte[] CharacterPic0 { get; set; }
		public byte[] CharacterPic1 { get; set; }
		public byte[] CharacterPic2 { get; set; }
		public string CharacterSystemPath0 { get; set; }
		public string CharacterSystemPath1 { get; set; }
		public string CharacterSystemPath2 { get; set; }
		public string CharacterAssetPath0 { get; set; }
		public string CharacterAssetPath1 { get; set; }
		public string CharacterAssetPath2 { get; set; }
		public bool BrightCharacter0 { get; set; } = true;
		public bool BrightCharacter1 { get; set; } = true;
		public bool BrightCharacter2 { get; set; } = true;
		public byte[] ResultPic { get; set; }
		public string ResultPath { get; set; }
		public int TopOrder { get; set; }
		public int CharacterNum { get; set; }

		public void InfoArrange()
		{
			//var lst = new List<string>() { CharacterPath0, CharacterPath1, CharacterPath2 };
			//lst.Sort((x, y) => string.IsNullOrWhiteSpace(x + y) ? 0 : string.IsNullOrEmpty(x) ? 1 : string.IsNullOrEmpty(y) ? -1 : x.CompareTo(y));
			//CharacterNum = lst.Count;
			//CharacterPath0 = Path.Combine(DomainPathService.TempFolderPath, lst[0]);
			//CharacterPath1 = Path.Combine(DomainPathService.TempFolderPath, lst[1]);
			//CharacterPath2 = Path.Combine(DomainPathService.TempFolderPath, lst[2
			TopOrder = TopOrder.Limit(1, 3);
		}

		public bool IsValid => TopOrder > 0;
	}
}
