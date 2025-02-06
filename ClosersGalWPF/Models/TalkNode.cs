using ClosersGalWPF.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersGalWPF.Models
{
    public class TalkNode
    {
        public int seq { get; set; }
        public string NodeName { get; set; }
        public string CharName { get; set; }
        public string FrontName { get; set; }
        public string FaceName { get; set; }
        public string Content { get; set; }
        public string AudioName { get; set; }
        public string NextNodeName { get; set; } = string.Empty;
        public string Code => new GenerateController().Generate(NodeName, CharName, Content, FrontName, FaceName, AudioName, NextNodeName);
        public string Show => $"{seq}   {NodeName}  {CharName}  {Content}";
    }
}
