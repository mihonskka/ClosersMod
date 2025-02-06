using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersArtist.Models
{
	public class ArtistMessage
	{
		public byte[] CharacterPic0 { get; set; }
		public byte[] CharacterPic1 { get; set; }
		public byte[] CharacterPic2 { get; set; }
		public string CharacterName0 { get; set; } = "";
		public string CharacterName1 { get; set; } = "";
		public string CharacterName2 { get; set; } = "";
		public bool BrightCharacter0 { get; set; } = false;
		public bool BrightCharacter1 { get; set; } = false;
		public bool BrightCharacter2 { get; set; } = false;
		public byte[] ResultPic { get; set; }
		public string ResultPath { get; set; } = "";
		//public 
		public int TopOrder { get; set; }
		public int CharacterNum { get; set; }
	}
}
