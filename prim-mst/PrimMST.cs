using System;
using System.Collections.Generic;

namespace prim_mst
{

    internal class PrimMST
    {
        private List<Vertex> unvisitedVertices;
        private List<Edge> spanningTree;
        private BinaryHeap<Edge> edgeHeap;
        private double mstFullCost;


        public PrimMST(List<Vertex> unvisitedVertices)
        {
            this.unvisitedVertices = unvisitedVertices;
            this.spanningTree = new List<Edge>();
            this.edgeHeap = new BinaryHeap<Edge>();
            this.mstFullCost = 0.0;
        }

        public void FindMST(Vertex startingVertex)
        {
            unvisitedVertices.Remove(startingVertex);
            while (unvisitedVertices.Count > 0)
            {
                foreach (Edge edge in startingVertex.EdgeList)
                {
                    if (unvisitedVertices.Contains(edge.TargetVertex))
                    {
                        edgeHeap.Add(edge);
                    }
                }
                Edge minWeightEdge = edgeHeap.Poll();
                spanningTree.Add(minWeightEdge);
                mstFullCost += minWeightEdge.EdgeWeight;
                startingVertex = minWeightEdge.TargetVertex;
                unvisitedVertices.Remove(startingVertex);
            }

            ShowMST();
        }


        private void ShowMST()
        {
            Console.WriteLine("The minimum spanning tree costs '" + mstFullCost + "' units");
            foreach (Edge edge in spanningTree)
            {
                Console.WriteLine(edge);
            }
        }
    }

}