using ClosersGalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersGalWPF.Controllers
{
    public class LoadTemplateController
    {
        public string LoadNodeTemp() => File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Data\NodeTemplate.txt");
        public string LoadTalkTemp() => File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Data\TalkTemplate.txt");
        public List<KeyWordUnit> LoadKeyWords()
        {
            try
            {
                return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Data\KeyWordPreparation.txt").Split("\r\n").ToList().Select(t => new KeyWordUnit() { Key = t.Split("===")[1], Value = t.Split("===")[0], MyCharacter = t.Split("===")[2], MyListName = t.Split("===")[3] }).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in loading keywords.\n"+ex.Message);
				return new List<KeyWordUnit>();
            }
        }
    }
}
