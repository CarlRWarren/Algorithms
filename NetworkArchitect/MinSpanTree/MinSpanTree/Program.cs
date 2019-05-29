using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSpanTree
{
    class Graph
    {
        // A class to represent a graph edge 
        public class Edge : IComparable<Edge>
        {
            public int src, dest, weight;
            // Comparator function used for sorting edges  
            // based on their weight 
            public int CompareTo(Edge other)
            {
                return weight - other.weight;
            }
        }

        // A class to represent a Subset for union-find 
        public class Subset
        {
            public int parent, rank;
        };

        public int V, E;    // V-> no. of vertices & E->no.of edges 
        public Edge[] edges; // collection of all edges 

        // Creates a graph with V vertices and E edges 
        Graph(int v, int e)
        {
            V = v;
            E = e;
            edges = new Edge[E];
            for (int i = 0; i < e; i++)
            {
                edges[i] = new Edge();
                Console.WriteLine("Edge added");
            }
        }

        // A utility function to find set of an element i 
        // (uses path compression technique) 
        int Find(Subset[] subsets, int i)
        {
            // find root and make root as parent of i (path compression) 
            if (subsets[i].parent != i) subsets[i].parent = Find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        // A function that does union of two sets of x and y 
        // (uses union by rank) 
        void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            // Attach smaller rank tree under root of high rank tree 
            // (Union by Rank) 
            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            // If ranks are same, then make one as root and increment 
            // its rank by one 
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        // The main function to construct MST using Kruskal's algorithm 
        public void KruskalMST()
        {
            Edge[] result = new Edge[V];  // This will store the resultant MST 
            int e = 0;  // An index variable, used for result[] 
            int i = 0;  // An index variable, used for sorted edges 
            for (i = 0; i < V; i++)
                result[i] = new Edge();

            // Step 1:  Sort all the edges in non-decreasing order of their 
            // weight.  If we are not allowed to change the given graph, we 
            // can create a copy of array of edges 
            Array.Sort(edges);

            // Allocate memory for creating V ssubsets 
            Subset[] subsets = new Subset[V];
            for (i = 0; i < V; i++)
                subsets[i] = new Subset();

            // Create V subsets with single elements 
            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0;  // Index used to pick next edge 

            // Number of edges to be taken is equal to V-1 
            while (e < V - 1)
            {
                // Step 2: Pick the smallest edge. And increment  
                // the index for next iteration 
                Edge next_edge = new Edge();
                if (i < e)
                {
                    next_edge = edges[i++];
                }

                int x = Find(subsets, next_edge.src);
                int y = Find(subsets, next_edge.dest);

                // If including this edge does't cause cycle, 
                // include it in result and increment the index  
                // of result for next edge 
                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
                // Else discard the next_edge 
            }
            Console.WriteLine("Following are the edges in " +
                                     "the constructed MST");
            for (i = 0; i < e; i++)
                Console.WriteLine(iteratorsToIDs[result[i].src] + " -- " +
                       iteratorsToIDs[result[i].dest] + " == " + result[i].weight);
        }
        public static List<string> iteratorsToIDs = new List<string>();
        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("What is the file path?");
            //C:\Users\Carl\OneDrive - Neumont University\q7\Algorithms\NetworkArchitect\NetworkInputTest.txt
            path = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(@path);
            string[] ids = lines[0].Split(',');
            iteratorsToIDs.AddRange(ids);
            List<string[]> sockets = new List<string[]>();
            int numberOfEdges = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] connections = lines[i].Split(',');
                numberOfEdges += connections.Length - 1;
                sockets.Add(connections);
            }
            numberOfEdges /= 2;
            Graph graph = new Graph(ids.Length - 1, numberOfEdges);
            int socketLength = 0;
            int connectionLength = 0;
            foreach(Edge edge in graph.edges)
            {
                //edge.src=
                //edge.dest=
                //edge.weight=
            }
        }
    }
}
