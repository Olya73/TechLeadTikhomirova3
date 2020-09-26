using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.Utils
{
    public static class ResultAnswer
    {
        public static Result<T> Ok<T>(T value) => new Result<T>.Ok(value);
        public static Result<T> Error<T>(string message) => new Result<T>.Error(message);
    }
}
