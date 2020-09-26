using CurrencyConverterConsoleApplication.FileDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    public class GetPath
    {
        InputOutFactory _factory;
        public GetPath(InputOutFactory factory)
        {
            _factory = factory;
        }
        public async Task FindPathAsync(string source, string dest)
        {
            var filesCav = await _factory.Read().ReadFileAsync(source);
            var pathToFind = Parse(new Regex(@"[A-Z]{3}"), filesCav[0]);
            if (pathToFind.Count > 2 || pathToFind == null) return;
            int count;
            Graph graph = new Graph();

            if (!Int32.TryParse(filesCav[1], out count)) return;
            for (var i =0; i< count; i++)
            {
                graph.AddEdge(Parse(new Regex(@"[A-Z]{3}"), filesCav[i+2])[0], Parse(new Regex(@"[A-Z]{3}"), filesCav[i + 2])[1]);
            }
            var del = graph.BFS(pathToFind[0], pathToFind[1]);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var k in del())
            {
                stringBuilder.Insert(0, k);
            }
            await _factory.Write().WriteFileAsync(stringBuilder.ToString(), dest);
            
        }
        public static List<string> Parse(Regex regex, string sb)
        {
            List<string> res = new List<string>();
            MatchCollection matches = regex.Matches(sb);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    res.Add(match.Value);
            }
            else
                return null;
            return res;
        }
    }
}
