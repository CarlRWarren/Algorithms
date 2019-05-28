using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    class Program
    {

        public class Node
        {
            public string data;
            public string[] connections;
            public Node(string d, string[] conn) { data = d; connections = conn; }
        }
        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("What is the file path?");
            path = @"C:\Users\Carl\OneDrive - Neumont University\q7\Algorithms\Graphs\TestMazes.txt";
            //path = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(@path);
            List<List<string>> mazes = new List<List<string>>();
            List<string> maze = new List<string>();
            foreach (var line in lines)
            {
                if (line != "")
                {
                    if (line.ElementAt(0) != '/')
                    {
                        maze.Add(line);
                    }
                }
                else
                {
                    mazes.Add(maze);
                    maze = new List<string>();
                }
                if (line == lines[lines.Length - 1]) mazes.Add(maze);
            }

            foreach(var maz in mazes)
            {
                List<string[]> nodeRelations = new List<string[]>();
                string[] startEnd=null;
                string[] relation=null;
                for (int i=0; i<maz.Count; i++)
                {
                    if (i == 1)
                    {
                        startEnd = maz[i].Split(',');
                    }
                    else
                    {
                        relation = maz[i].Split(',');
                        nodeRelations.Add(relation);
                    }
                }
                string shortestPath = FindShortestPath(startEnd, nodeRelations);                
                Console.WriteLine(shortestPath);                
            }
        }

        private static string FindShortestPath(string[] startEnd, List<string[]> nodeRelations)
        {
            Queue<Node> nodeToRelations = new Queue<Node>();
            string nodePath = "";

            Node start = new Node(startEnd[0], FindRelation(startEnd[0], nodeRelations));
            nodeToRelations=NodeTraversal(start, nodeRelations);
            foreach(Node node in nodeToRelations)
            {
                nodePath += node.data+",";
            }
            nodePath.Trim();
            if (nodePath.LastIndexOf(',') > 0)
            {
                nodePath = nodePath.Remove(nodePath.LastIndexOf(','));
            }
            string[] shortest = nodePath.Split(',');
            if (shortest[0] != startEnd[0] || shortest[shortest.Length - 1] != startEnd[1])
            {
                nodePath = "Solution Not Found";
            }             
            return nodePath;
        }

        private static string[] FindRelation(string node, List<string[]> nodeRelations)
        {
            foreach(string[] arr in nodeRelations)
            {
                if (arr[0] == node)
                {
                    arr[0] ="";
                    return arr;
                }
            }
            return new string[] { };
        }
        static Queue<Node> path = new Queue<Node>();
        public static Queue<Node> NodeTraversal(Node node, List<string[]> nodeRelations)
        {
            path = new Queue<Node>();
            path.Enqueue(node);
            List<Node> nodes = new List<Node>();
            foreach(string connection in node.connections)
            {
                Node newNode = new Node(connection, FindRelation(connection, nodeRelations));
                if (newNode != node)
                {
                    nodes.Add(newNode);
                }
                
            }
            foreach(Node n in nodes)
            {
                if (!(path.Contains(n)))
                {
                    path = NodeTraversal(n, nodeRelations);
                }
            }
            return path;
        }
    }
}
