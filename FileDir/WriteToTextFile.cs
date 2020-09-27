using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public class WriteToTextFile: IWrite
    {
        public async Task WriteFileAsync(string textToWrite, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
                {
                    await sw.WriteLineAsync(textToWrite);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
