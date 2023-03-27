using System;
using System.Collections.Generic;

namespace search_algorithms
{
    internal class BreadthFirstSearch
    {

        private Queue<Vertex> queue;

        public BreadthFirstSearch()
        {
            this.queue = new Queue<Vertex>();
        }

        public void BFS(Vertex startVertex)
        {
            Console.Write("BFS = ");
            startVertex.IsVisited = true;
            queue.Enqueue(startVertex);
            while (queue.Count > 0)
            {
                Vertex current = queue.Dequeue();
                current.IsVisited = true;
                Console.Write(current + " ");
                foreach (Vertex vertex in current.AdjacencyList)
                {
                    if (!vertex.IsVisited)
                    {
                        vertex.IsVisited = true;
                        queue.Enqueue(vertex);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
