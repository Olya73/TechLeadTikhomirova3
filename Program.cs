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
            

            GetPath getPath = new GetPath(new TextFile());
            await getPath.FindPathAsync("input.txt", "output.txt");
            Console.ReadKey();
        }
    }
}
