
namespace search_algorithms
{
    internal class Program
    {

        //                     GRAPH
        //                       A
        //                     /   \
        //                   C      B
        //                  /     /   \
        //                 G    D _____ E
        //                            /
        //                           F
        //

        //          ADJACENCY MATRIX REPRESENTATION
        //                  A B C D E F G
        //               A | |1|1| | | | |
        //               B |1| | |1|1| | |
        //               C |1| | | | | |1|
        //               D | |1| | |1| | |
        //               E | |1| |1| |1| |
        //               F | | | | |1| | |
        //               G | | |1| | | | |


        //           ADJACENCY LIST REPRESENTATION
        //                   A {C, B}
        //                   B {A, D, E}
        //                   C {G, A}
        //                   D {B, E}
        //                   E {D, B, F}
        //                   F {E}
        //                   G {C}

        static void Main(string[] args)
        {
            //Create the verices
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            Vertex f = new Vertex("F");
            Vertex g = new Vertex("G");

            //Construct the graph from the above schema
            //ADJACENCY LIST IMPLEMENTATION

            //A {C, B}
            a.AddNeighbour(c);
            a.AddNeighbour(b);

            //B {A, D, E}
            b.AddNeighbour(a);
            b.AddNeighbour(d);
            b.AddNeighbour(e);

            //C {G, A}
            c.AddNeighbour(g);
            c.AddNeighbour(a);

            //D {B, E}
            d.AddNeighbour(b);
            d.AddNeighbour(e);

            //E {D, B, F}
            e.AddNeighbour(d);
            e.AddNeighbour(b);
            e.AddNeighbour(f);

            //F {E}
            f.AddNeighbour(e);

            //G {C}
            g.AddNeighbour(c);


            //The array is to restart the visited state between traversals
            Vertex[] graph = new Vertex[] { a, b, c, d, e, f, g };

            new BreadthFirstSearch().BFS(a);
            RestartGraphState(graph);

            new DepthFirstSearch().DFS(a);
            RestartGraphState(graph);

            new DepthFirstSearchRecursive().DFS(a);
            RestartGraphState(graph);

            //string startingUrl = "http://fmi-plovdiv.org";
            //new BFSBasedSimpleWebCrawler().crawlTheWebFrom(startingUrl);
        }

        private static void RestartGraphState(Vertex[] graph)
        {
            foreach (Vertex vertex in graph)
            {
                vertex.IsVisited = false;
            }
        }
    }
}
