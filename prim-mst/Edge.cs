using System;

namespace prim_mst
{
    internal class Edge : IComparable<Edge>
    {

        private double edgeWeight;

        public double EdgeWeight
        {
            get { return edgeWeight; }
            set { edgeWeight = value; }
        }


        private Vertex startVertex;

        public Vertex StartVertex
        {
            get { return startVertex; }
            set { startVertex = value; }
        }


        private Vertex targetVertex;

        public Vertex TargetVertex
        {
            get { return targetVertex; }
            set { targetVertex = value; }
        }


        public Edge(double edgeWeight, Vertex startVertex, Vertex targetVertex)
        {
            this.edgeWeight = edgeWeight;
            this.startVertex = startVertex;
            this.targetVertex = targetVertex;
        }

        public int CompareTo(Edge other)
        {
            return this.edgeWeight.CompareTo(other.edgeWeight);
        }

        public override string ToString()
        {
            return startVertex + " -" + edgeWeight + "-> " + targetVertex;
        }
    }
}
