using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    public static class Parser
    {
        public static List<string> Parse(Regex regex, string sb)
        {
            List<string> res = new List<string>();
            MatchCollection matches = regex.Matches(sb);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    res.Add(match.Value);
            }
            else
                return null;
            return res;
        }
    }
}
