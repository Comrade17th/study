using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd10
{
    class Program
    {
        public class Graph
        {
            LinkedList<int>[] linkedList;

            public Graph(int v)
            {
                linkedList = new LinkedList<int>[v];
            }
            public void Add(int i, int j)
            {
                if (linkedList[i] == null)
                {
                    linkedList[i] = new LinkedList<int>();
                    linkedList[i].AddFirst(j);
                }
                else
                {
                    var last = linkedList[i].Last;
                    linkedList[i].AddAfter(last, j);
                }
            }

            internal void DFSHelper(int i, bool[] visited)
            {
                visited[i] = true;
                Console.Write(i + "->");
                if (linkedList[i] != null)
                {
                    foreach (var item in linkedList[i])
                    {
                        if (!visited[item] == true)
                        {
                            DFSHelper(item, visited);
                        }
                    }
                }
            }

            internal void DFS()
            {
                Console.WriteLine("алгоритм поиска в глубину");
                Console.WriteLine("");
                bool[] visited = new bool[linkedList.Length + 1];
                DFSHelper(1, visited);
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            Graph graph = new Graph(9);
            graph.Add(1, 3);
            graph.Add(3, 4);
            graph.Add(1, 2);
            graph.Add(2, 5);
            graph.Add(5, 7);
            graph.Add(5, 6);
            graph.Add(6, 8);
            graph.Add(2, 3);
            graph.Add(3, 6);
            graph.DFS();
        }
    }
}
