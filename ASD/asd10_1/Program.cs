
using System;
using System.Collections.Generic;
class GFG
{

    static List<int>[] graph = new List<int>[100];
    static List<int>[] cycles = new List<int>[100];
    static int cyclenumber;


    static void cycle(int u, int p, int[] color, int[] par)
    {
        if (color[u] == 2)
        {
            return;
        }

        if (color[u] == 1)
        {

            List<int> l = new List<int>();
            int cur = p;
            l.Add(cur);

            while (cur != u)
            {
                cur = par[cur];
                l.Add(cur);
            }
            cycles[cyclenumber] = l;
            cyclenumber++;
            return;
        }
        par[u] = p;

        color[u] = 1;

        foreach (int v in graph[u])
        {
            if (v == par[u])
            {
                continue;
            }
            cycle(v, u, color, par);
        }

        color[u] = 2;
    }


    static void add(int u, int v)
    {
        graph[u].Add(v);
        graph[v].Add(u);
    }
    
    static void printCycles()
    {
        for (int i = 0;
                 i < cyclenumber; i++)
        {
            Console.Write("Cycle Number " + (i + 1) + ":");
            foreach (int x in cycles[i])
                Console.Write(" " + x);
            Console.WriteLine();
        }
    }


    public static void Main(String[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            graph[i] = new List<int>();
            cycles[i] = new List<int>();
        }

        add(1, 2);
        add(1, 3);
        add(2, 3);
        add(2, 5);
        add(5, 7);
        add(5, 6);
        add(3, 6);
        add(3, 4);
        add(6, 8);


        int[] color = new int[100];
        int[] par = new int[100];


        cyclenumber = 0;

        cycle(1, 0, color, par);

        printCycles();
    }
}