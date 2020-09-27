using CurrencyConverterConsoleApplication.FileDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Converter getPath = new Converter(new TextFile());
            await getPath.FindPathAsync("input.txt", "output.txt");
            Console.ReadKey();
        }
    }
}
