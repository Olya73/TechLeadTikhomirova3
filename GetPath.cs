using CurrencyConverterConsoleApplication.FileDir;
using CurrencyConverterConsoleApplication.Utils;
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
            var path = CurrencUtils.GetCurrenc(filesCav[0], ParseCurrency);
            if (path == null)
                return;

            var countPairs = CurrencUtils.GetCurrenc(filesCav[1], ParseInt);
            if (countPairs == 0)
                return;

            Graph graph = new Graph();
            for (var i =0; i< countPairs; i++)
            {
                var pair = CurrencUtils.GetCurrenc(filesCav[i], ParseCurrency);
                if (pair != null) graph.AddEdge(pair[0], pair[1])
                // graph.AddEdge(Parse(new Regex(@"[A-Z]{3}"), filesCav[i+2])[0], Parse(new Regex(@"[A-Z]{3}"), filesCav[i + 2])[1]);
            }
           // var del = graph.BFS(pathToFind[0], pathToFind[1]);
           /// StringBuilder stringBuilder = new StringBuilder();
           // foreach (var k in del())
           // {
           //     stringBuilder.Insert(0, k);
          //  }
           // await _factory.Write().WriteFileAsync(stringBuilder.ToString(), dest);
            
        }
        public Result<List<string>> ParseCurrency(string input)
        {
            var strings = CurrencUtils.Parse(new Regex(@"[A-Z]{3}"), input);
            if (strings.Count == 2)
                return new Result<List<string>>.Ok(strings);
            else
                return new Result<List<string>>.Error("Не правильно введены валюты для поиска");
        }
        public Result<int> ParseInt(string input)
        {
            int value;
            if (Int32.TryParse(input, out value))
                if (value > 0)
                    return new Result<int>.Ok(value);
                else return new Result<int>.Error("Не является положительным числом");
            else 
                return new Result<int>.Error("Не число");
        }
        
    }
}
