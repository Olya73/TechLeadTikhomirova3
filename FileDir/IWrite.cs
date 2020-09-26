using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public interface IWrite
    {
        Task WriteFileAsync(string textToWrite, string fileName);
    }
}
