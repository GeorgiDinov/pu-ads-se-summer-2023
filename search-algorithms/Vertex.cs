using System.Collections.Generic;

namespace search_algorithms
{
    internal class Vertex
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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

        public Vertex(string name)
        {
            this.name = name;
            this.isVisited = false;
            this.adjacencyList = new List<Vertex>();
        }

        public void AddNeighbour(Vertex neighbour)
        {
            adjacencyList.Add(neighbour);
        }

        public override string ToString()
        {
            return name;
        }
    }

}
