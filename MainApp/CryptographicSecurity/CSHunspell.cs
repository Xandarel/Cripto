using Criptoclass;
using NHunspell;
using System;
using System.Collections.Generic;
using System.Text;
using WeCantSpell.Hunspell;

namespace CryptographicSecurity
{
    class CSHunspell
    {
        public List<string> Keys;
        public CSHunspell()
        {
            Keys = new List<string>();
        }

        public void NormalizeKey(List<string> candidat, int length = -1)
        {
            if (Languege.dictionary.ContainsKey('А'))
            {
                var dictionary = WordList.CreateFromFiles(@"Russian.dic", @"Russian.aff");
                if (length == -1)
                    foreach (var c in candidat)
                    {
                        var suggestions = dictionary.Suggest(c);
                        foreach (var s in suggestions)
                        Keys.Add(s);
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
                            foreach (var s in suggestions)
                                Keys.Add(s);
                        }
                    }
                }
            }
            else
            {

            }
        }

        private void Body(string dicMode, string affMode, int length, List<string> candidat)
        {
            var dictionary = WordList.CreateFromFiles(dicMode, affMode);
            if (length == -1)
                foreach (var c in candidat)
                {
                    var suggestions = dictionary.Suggest(c);
                    foreach (var s in suggestions)
                        Keys.Add(s);
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
                        foreach (var s in suggestions)
                            Keys.Add(s);
                    }
                }
            }
        }
    }
}
