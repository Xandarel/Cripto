using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCantSpell.Hunspell;
using Criptoclass;

namespace UserInterface
{
    class Normalizator
    {
        public List<string> Keys;
        public Normalizator()
        {
            Keys = new List<string>();
        }

        public void NormalizeKey(List<string> candidat, int length = -1)
        {
            if (Languege.dictionary.ContainsKey('А'))
            {
                Bodymethod(@"Russian.dic", @"Russian.aff", length, candidat);
            }
            else
            {
                Bodymethod(@"English (British).dic", @"English (British).aff", length, candidat);
            }
        }

        private void Bodymethod(string dicMode, string affMode, int length, List<string> candidat)
        {
            var dictionary = WordList.CreateFromFiles(dicMode, affMode);
            if (length == -1)
                foreach (var c in candidat)
                {
                    var suggestions = dictionary.Suggest(c);
                    Keys.AddRange(suggestions);
                }
            else
            {
                foreach (var c in candidat)
                {
                    if (c.Length < length)
                        continue;
                    else if (c.Length > length)
                        break;
                    else
                    {
                        var suggestions = dictionary.Suggest(c);
                        Keys.AddRange(suggestions);
                    }
                }
            }
        }
    }
}
