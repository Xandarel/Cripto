using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CryptographicSecurity
{
    public class VigenereKey
    {
        private string key;
        public string GetKey => key;
        public void FindKey(string chiperText)
        {
            var repetitionPeriods = KasiskiMethod(chiperText);
        }
        private List<int> KasiskiMethod(string chiperText)
        {
            var result = new List<int>();
            var segmentInText = new Dictionary<string, int>();
            for (var i=0;i<chiperText.Length-3;i++)
            {
                var substring = chiperText.Substring(i, 3);
                if (!segmentInText.ContainsKey(substring))
                    segmentInText.Add(substring, i);
                else
                {
                    result.Add(i - segmentInText[substring]);
                    segmentInText[substring] = i;
                }
            }
            return result;
        }
    }
}
