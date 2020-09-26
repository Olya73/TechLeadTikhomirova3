using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
            ConnectedVertexes = new List<Vertex>();
        }

        public string Name { get; }
        public List<Vertex> ConnectedVertexes { get; }
        public void AddEdge(Vertex vertex)
        {
           // Vertex vertex = new Vertex(name);
            if (!ConnectedVertexes.Contains(vertex))
                ConnectedVertexes.Add(vertex);
        }

        public override string ToString() => Name;

    }
}
