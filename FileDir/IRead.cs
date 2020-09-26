using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public interface IRead
    {
        Task<List<string>> ReadFileAsync(string fileName);
    }
}
