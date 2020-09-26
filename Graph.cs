using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterConsoleApplication
{
    public class Graph
    {
        public List<Vertex> AllVertexes { get; }

        public Graph()
        {
            AllVertexes = new List<Vertex>();
        }
        public Vertex AddVertex(string name)
        {
            Vertex vertex = GetVertex(name);
            if (vertex == null)
            {
                vertex = new Vertex(name);
                AllVertexes.Add(vertex);
            }
            return vertex;
        }
        public Vertex GetVertex(string name)
        {
            foreach (var v in AllVertexes)
            {
                if (v.Name.Equals(name)) return v;
            }
            return null;
        }
        public void AddEdge(string sourceName, string destName)
        {
            Vertex sourceVertex = GetVertex(sourceName) ?? AddVertex(sourceName);
            Vertex destVertex = GetVertex(destName) ?? AddVertex(destName);
            if (sourceVertex != null && destVertex != null)
            {
                sourceVertex.AddEdge(destVertex);
            }
        }

        public Func<List<Vertex>> BFS(string sourceName, string destName)
        {
            var src = GetVertex(sourceName);
            var dest = GetVertex(destName);
            List<Vertex> verticesFinalList = new List<Vertex>();

            if (src == null || dest == null) return null ;
            if (src.Equals(dest)) return () => verticesFinalList;

            var neighbours = new Dictionary<Vertex, Vertex>();
            var queue = new Queue<Vertex>();

            queue.Enqueue(src);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach (var v in curr.ConnectedVertexes)
                {
                    if (neighbours.ContainsKey(v)) continue;
                    neighbours[v] = curr;
                    if (v == dest) return () =>
                    {
                        var c = dest;
                        do
                        {
                            verticesFinalList.Add(c);
                            c = neighbours[c];
                        } while (!c.Equals(src));
                        verticesFinalList.Add(c);
                        return verticesFinalList;
                    };
                    queue.Enqueue(v);
                }
            }
            return () => verticesFinalList;
        }
    }
}
