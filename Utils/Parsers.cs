using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.Utils
{
    public static class Parsers
    {
        public static Result<List<string>> ParseCurrency(string input)
        {
            var strings = Parse(new Regex(@"[A-Z]{3}\b"), input);
            if (strings != null && strings.Count == 2)
                return new Result<List<string>>.Ok(strings);
            else
                return new Result<List<string>>.Error("Не правильно введены валюты для поиска");
        }
        public static Result<int> ParseInt(string input)
        {
            int value;
            if (Int32.TryParse(input, out value))
                if (value > 0)
                    return new Result<int>.Ok(value);
                else return new Result<int>.Error($"{input} Не является положительным числом");
            else
                return new Result<int>.Error($"{input} Не число");
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
