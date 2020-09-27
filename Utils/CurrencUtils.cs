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
        
    }
}
