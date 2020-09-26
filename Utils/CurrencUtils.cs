using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.Utils
{
    public static class CurrencUtils
    {
        public static T GetCurrenc<T>(string str, Func<string, Result<T>> reader)
        {

            switch(reader(str))
            {
                case Result<T>.Ok ok: return ok.Value;
                case Result<T>.Error error:
                    Console.WriteLine($"Ошибка: {error.Message}");
                    Console.WriteLine();
                    return default;
                default: return default;
            }
        }
        public static List<string> Parse(Regex regex, string sb)
        {
            List<string> res = null;
            MatchCollection matches = regex.Matches(sb);
            if (matches.Count != 0)
            {
                res = new List<string>();
                foreach (Match match in matches)
                    res.Add(match.Value);
            }
            return res;
        }
    }
}
