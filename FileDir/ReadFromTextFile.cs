using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public class ReadFromTextFile: IRead
    {
        public async Task<List<string>> ReadFileAsync(string fileName)
        {
            List<string> strings = new List<string>();
            try
            {
                string line;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        strings.Add(line);
                    }
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
            return strings;
        }
    }
}
