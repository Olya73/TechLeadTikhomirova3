using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.Utils
{
    public abstract class Result<T>
    {
        private Result() {}
        public class Error : Result<T>
        {
            public Error(string message)
            {
                Message = message;
            }
            public string Message { get; }
        }
        public class Ok: Result<T>
        {
            public Ok(T value)
            {
                Value = value;
            }
            public T Value { get; }
        }

    }
}
