using CurrencyConverterConsoleApplication.FileDir;
using CurrencyConverterConsoleApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    public class GetPath
    {
        InputOutFactory _factory;
        Graph graph;
        public GetPath(InputOutFactory factory)
        {
            _factory = factory;
            graph = new Graph();
        }
        public async Task FindPathAsync(string source, string dest)
        {
            var filesCav = await _factory.Read().ReadFileAsync(source);
            var path = CurrencUtils.GetCurrenc(filesCav[0], Parsers.ParseCurrency);
            if (path == null)
                return;

            var countPairs = CurrencUtils.GetCurrenc(filesCav[1], Parsers.ParseInt);
            if (countPairs == 0)
                return;
            
            for (var i =0; i< countPairs; i++)
            {
                var pair = CurrencUtils.GetCurrenc(filesCav[i+2], Parsers.ParseCurrency);
                if (pair != null)
                    graph.AddEdge(pair[0].Trim(), pair[1].Trim());
                else
                    return;              
            }
            var del = graph.BFS(path[0].Trim(), path[1].Trim());
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var k in del())
            {
                stringBuilder.Insert(0, $"{k} ");
            }
            await _factory.Write().WriteFileAsync(stringBuilder.ToString(), dest);
            
        }
        
        
    }
}
