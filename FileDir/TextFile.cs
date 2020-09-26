using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public class TextFile : InputOutFactory
    {
        public IRead Read()
        {
            return new ReadFromTextFile();
        }

        public IWrite Write()
        {
            return new WriteToTextFile();
        }
    }
}
