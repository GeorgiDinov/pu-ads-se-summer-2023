using System;
using System.Collections.Generic;

namespace prim_mst
{
    internal class Vertex : IComparable<Vertex>
    {

        private string name;

        private bool isVisited;
        public bool IsVisited
        {
            get { return isVisited; }
            set { isVisited = value; }
        }

        private List<Vertex> adjacencyList;
        public List<Vertex> AdjacencyList
        {
            get { return adjacencyList; }
        }


        private List<Edge> edgeList;
        public List<Edge> EdgeList
        {
            get { return edgeList; }
            set { edgeList = value; }
        }


        //distance from the starting vertex(source)
        private double distance;
        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        //the previous vertex on the shortest path
        private Vertex predecessor;
        public Vertex Predecessor
        {
            get { return predecessor; }
            set { predecessor = value; }
        }


        public Vertex(string name)
        {
            this.name = name;
            this.isVisited = false;
            this.adjacencyList = new List<Vertex>();
            this.edgeList = new List<Edge>();
            this.distance = double.PositiveInfinity; // double.MaxValue
            this.predecessor = null;
        }


        public void AddNeighbor(Vertex vertex)
        {
            adjacencyList.Add(vertex);
        }

        public void AddEdge(Edge edge)
        {
            edgeList.Add(edge);
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Vertex vertex = (Vertex)obj;
            return this.name.Equals(vertex.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + 31;
        }

        public int CompareTo(Vertex vertex)
        {
            return this.distance.CompareTo(vertex.distance);
        }

    }
}
