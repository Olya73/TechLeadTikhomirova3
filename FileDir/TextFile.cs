using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication.FileDir
{
    public class TextFile: FileManager
    {
        public override async Task<List<string>> ReadFileAsync(string fileName) // загрузка листа
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


        public override async Task WriteFileAsync(string textToWrite, string fileName)
        {
            using (FileStream fstream = new FileStream(fileName, FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(textToWrite);
                }
            }
        }
    }
}
