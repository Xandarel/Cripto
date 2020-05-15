using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographicSecurity
{
    static  public class Ngramm
    {
        public static Dictionary<string, int> NGrams(string word, int l=1)
        {
            var res = new Dictionary<string, int>();
            for (var i=0;i<word.Length-l+1;i++)
            {
                var sbstr = word.Substring(i, l);
                if (!res.ContainsKey(sbstr))
                    res[sbstr] = 1;
                else
                    res[sbstr] += 1;
            }
            return res;
        }
    }
}
