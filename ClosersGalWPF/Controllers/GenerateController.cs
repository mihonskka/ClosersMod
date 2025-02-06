using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace ClosersGalWPF.Controllers
{
    public class GenerateController
    {
        public string Generate(string NodeName, string CharName, string Content, string FrontName, string FaceName, string AudioName, string NextNodeName)
        {
            if (string.IsNullOrWhiteSpace(CharName))
                CharName = "string.Empty";
            if (string.IsNullOrWhiteSpace(Content))
                Content = "string.Empty";
            if (string.IsNullOrWhiteSpace(FrontName))
                FrontName = "string.Empty";
            if (string.IsNullOrWhiteSpace(FaceName))
                FaceName = "string.Empty";
            if (string.IsNullOrWhiteSpace(AudioName))
                AudioName = "string.Empty";
            if (string.IsNullOrWhiteSpace(NextNodeName))
                NextNodeName = "null";
            else NextNodeName = "typeof(" + NextNodeName + ")";
            Content = Content.Replace("\n", "\\n");
            return new LoadTemplateController().LoadNodeTemp().Replace("%NodeName%",NodeName).Replace("%CharName%",CharName).Replace("%Content%",Content).Replace("%FrontName%", FrontName).Replace("%FaceName%", FaceName).Replace("%AudioName%", AudioName).Replace("%NextNodeName%", NextNodeName).Replace("%TCContent%", ChineseConverter.Convert(Content, ChineseConversionDirection.SimplifiedToTraditional));
        }

    }
}
