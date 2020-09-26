using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public abstract class FileManager
    {
        public abstract Task<List<string>> ReadFileAsync(string fileName);
        public abstract Task WriteFileAsync(string textToWrite, string fileName)
    }
}
