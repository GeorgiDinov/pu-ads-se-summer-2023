using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_algorithms
{
    internal class DepthFirstSearchRecursive
    {

        public DepthFirstSearchRecursive() { }

        public void DFS(Vertex startVertex)
        {
            Console.Write("DFS = ");
            DFSRecursive(startVertex);
            Console.WriteLine();

        }

        private void DFSRecursive(Vertex startVertex)
        {
            startVertex.IsVisited = true;
            Console.Write(startVertex + " ");
            foreach (Vertex vertex in startVertex.AdjacencyList)
            {
                if (!vertex.IsVisited)
                {
                    vertex.IsVisited = true;
                    DFSRecursive(vertex);
                }
            }
        }



    }
}
