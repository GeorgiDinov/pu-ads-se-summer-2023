using System;
using System.Collections.Generic;
using System.Linq;

namespace dijkstra_shortest_path
{
    internal class Program
    {



        /*
        * Example of the Graph we will search shortest path in
        * 
        *      5-------->(B)-------15------->(D)
        *     /           |  \               ↑ |
        *    /            |    \           /   |
        *   /             4     12       3     |
        *  /              |        \    /      |
        * /               ↓          ↓/        |
        *(A)------8----->(H)---7--->(C)        9 
        *  \             ↑  \       ↑  \       | 
        *   \          /     6    1     \      |    
        *    9       5       ↓  /        \     |
        *     \     /        (F)         11    | 
        *       ↓  /          ↑\          \    | 
        *       (E)-----4----/  \          \   | 
        *        |                 13       \  |
        *        |                   \       ↓ ↓   
        *        |                     \---->(G)  
        *         \                           ↑  
        *          -----------20-------------/
        */


        static void Main(string[] args)
        {
            //Constructing the Graph
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            Vertex f = new Vertex("F");
            Vertex g = new Vertex("G");
            Vertex h = new Vertex("H");

            a.AddEdge(new Edge(5, a, b));
            a.AddEdge(new Edge(9, a, e));
            a.AddEdge(new Edge(8, a, h));

            b.AddEdge(new Edge(12, b, c));
            b.AddEdge(new Edge(15, b, d));
            b.AddEdge(new Edge(4, b, h));

            c.AddEdge(new Edge(3, c, d));
            c.AddEdge(new Edge(11, c, g));

            d.AddEdge(new Edge(9, d, g));

            e.AddEdge(new Edge(5, e, h));
            e.AddEdge(new Edge(4, e, f));
            e.AddEdge(new Edge(20, e, g));

            f.AddEdge(new Edge(1, f, c));
            f.AddEdge(new Edge(13, f, g));

            //g doesn't have outgoing connections

            h.AddEdge(new Edge(7, h, c));
            h.AddEdge(new Edge(6, h, f));


            ConstructShortestPathTreeFrom(a);

            PrintSHortestPathTo(a);
            PrintSHortestPathTo(b);
            PrintSHortestPathTo(c);
            PrintSHortestPathTo(d);
            PrintSHortestPathTo(e);
            PrintSHortestPathTo(f);
            PrintSHortestPathTo(g);
            PrintSHortestPathTo(h);
        }


        private static void ConstructShortestPathTreeFrom(Vertex startingVertex)
        {

            BinaryHeap<Vertex> priorityQueue = new BinaryHeap<Vertex>();

            startingVertex.Distance = 0d;
            priorityQueue.Add(startingVertex);

            while (priorityQueue.Size() > 0)
            {
                Vertex currentVertex = priorityQueue.Remove();
                foreach (Edge edge in currentVertex.EdgeList)
                {

                    Vertex targetVertex = edge.TargetVertex;

                    double distance = currentVertex.Distance + edge.EdgeWeight;
                    if (distance < targetVertex.Distance)
                    {
                        //bottle neck - removal/poll will be O(n)
                        //unless something like this is used https://github.com/sqeezy/FibonacciHeap.git
                        //The idea is to set the new distance to the vertex and put it back to the heap
                        //and every time we remove we will get the smallest distance vertex
                        priorityQueue.Poll(targetVertex);
                        targetVertex.Distance = distance;
                        targetVertex.Predecessor = currentVertex;
                        priorityQueue.Add(targetVertex);
                    }
                }
            }
        }


        private static void PrintSHortestPathTo(Vertex vertex)
        {
            List<Vertex> path = GetShortestPathTo(vertex);
            Vertex first = path.First();
            Console.Write("Shortest Path from '" + first + "' to '" + vertex + "' is " + vertex.Distance + " weight units: ");
            for (int i = 0; i < path.Count; i++)
            {
                string msg = (i < path.Count - 1) ? path.ElementAt(i) + " -> " : path.ElementAt(i) + "\n";
                Console.Write(msg);
            }
        }

        private static List<Vertex> GetShortestPathTo(Vertex vertex)
        {
            List<Vertex> path = new List<Vertex>();
            for (Vertex v = vertex; v != null; v = v.Predecessor)
            {
                path.Add(v);
            }
            path.Reverse();
            return path;
        }


    }

}
