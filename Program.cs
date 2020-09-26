using CurrencyConverterConsoleApplication.FileDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddVertex("1");
            graph.AddVertex("2");
            graph.AddVertex("4");
            graph.AddVertex("3");
            graph.AddVertex("5");

            graph.AddEdge("5", "1");
           // graph.AddEdge("5", "3");
            graph.AddEdge("5", "2");
            graph.AddEdge("1", "3");
            graph.AddEdge("4", "2");
            graph.AddEdge("4", "3");
            graph.AddEdge("4", "5");

            var del = graph.BFS("5","3");

            TextFile file = new TextFile();
            var sb = await file.ReadFileAsync("input.txt");

            foreach (var k in Parser.Parse(new Regex(@"[A-Z]{3}|"), sb)) 
            {
                Console.WriteLine(k);
            }
            Console.ReadKey();
        }
    }
}
