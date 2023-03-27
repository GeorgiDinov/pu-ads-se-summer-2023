using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_algorithms
{
    internal class DepthFirstSearch
    {

        private Stack<Vertex> stack;

        public DepthFirstSearch()
        {
            this.stack = new Stack<Vertex>();
        }

        public void DFS(Vertex startVertex)
        {
            Console.Write("DFS = ");
            startVertex.IsVisited = true;
            stack.Push(startVertex);
            while (stack.Count > 0)
            {
                Vertex current = stack.Pop();
                current.IsVisited = true;
                Console.Write(current + " ");
                foreach (Vertex vertex in current.AdjacencyList)
                {
                    if (!vertex.IsVisited)
                    {
                        vertex.IsVisited = true;
                        stack.Push(vertex);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
