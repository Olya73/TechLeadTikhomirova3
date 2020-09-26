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
        public void AddVertex(string name)
        {
            if (GetVertex(name) == null) AllVertexes.Add(new Vertex(name));
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
            Vertex sourceVertex = GetVertex(sourceName);
            Vertex destVertex = GetVertex(destName);
            if (sourceVertex != null && destVertex != null)
            {
                sourceVertex.AddEdge(destVertex);
            }
        }

        public Func<List<Vertex>> BFS(string sourceName, string destName)
        {
            var src = GetVertex(sourceName);
            var dest = GetVertex(destName);
            if (GetVertex(sourceName) == null || GetVertex(destName) == null) return null ;
            if (GetVertex(sourceName)==GetVertex(destName)) return null;
           // var visited = new HashSet<Vertex>();
            var neighbours = new Dictionary<Vertex, Vertex>();
            //visited.Add(src);
            var queue = new Queue<Vertex>();
            var count = 0;
            queue.Enqueue(src);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                //if (neighbours.ContainsKey(curr)) continue;
                //neighbours.Add(curr);
                count++;
                foreach (var v in curr.ConnectedVertexes)
                {
                    if (neighbours.ContainsKey(v)) continue;
                    neighbours[v] = curr;
                    if (v == dest) return () =>
                    {
                        List<Vertex> vertices = new List<Vertex>();
                        var c = dest;
                        do
                        {
                            vertices.Add(c);
                            c = neighbours[c];
                        } while (!c.Equals(src));
                        vertices.Add(c);
                        return vertices;
                    };
                    queue.Enqueue(v);
                }
            }

            

            return null;
        }
    }
}
