using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
    /// <summary>
    /// Provides graph breadth-first, depth-first search.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Number of vertices.
        /// </summary>
        private int _v;

        /// <summary>
        /// Adjacency list.
        /// </summary>
        private LinkedList<int>[] _adjL;

        public Graph(int v)
        {
            _v = v;
            _adjL = new LinkedList<int>[v];
            for (int i = 0; i < v; i++)
            {
                _adjL[i] = new LinkedList<int>();
            }
        }

        /// <summary>
        /// Adds edge to the instance of graph.
        /// </summary>
        /// <param name="v">Number of vertices.</param>
        /// <param name="w">Value.</param>
        public void AddEdge(int v, int w)
        {
            _adjL[v].AddLast(w);
        }

        /// <summary>
        /// Provides breadth-first search for the instance of graph.
        /// </summary>
        /// <param name="s">Searched value.</param>
        public void Bfs(int s)
        {
            bool[] visited = new bool[_v];

            Queue<int> queue = new Queue<int>();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                IEnumerator<int> ie = _adjL[s].GetEnumerator();
                while (ie.MoveNext())
                {
                    int n = ie.Current;
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

        public void Dfs(int s)
        {
            bool[] visited = new bool[_v];

            Stack<int> stack = new Stack<int>();

            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                IEnumerator<int> ie = _adjL[s].GetEnumerator();
                while (ie.MoveNext())
                {
                    int n = ie.Current;
                    if (!visited[n])
                    {
                        visited[n] = true;
                        stack.Push(n);
                    }
                }
            }
        }
    }
}
