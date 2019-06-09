using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests.AlgorithmsTests
{
    [TestFixture]
    public class GraphTests
    {
        private Graph _g;

        [SetUp]
        public void SetUp()
        {
            _g = new Graph(8);
        }

        [Test]
        public void Bfs()
        {
            _g.AddEdge(0, 1);
            _g.AddEdge(1, 0);
            _g.AddEdge(1, 4);
            _g.AddEdge(4, 1);
            _g.AddEdge(4, 6);
            _g.AddEdge(6, 4);
            _g.AddEdge(6, 0);
            _g.AddEdge(0, 6);
            _g.AddEdge(1, 5);
            _g.AddEdge(5, 1);
            _g.AddEdge(5, 3);
            _g.AddEdge(3, 5);
            _g.AddEdge(3, 0);
            _g.AddEdge(0, 3);
            _g.AddEdge(5, 2);
            _g.AddEdge(2, 5);
            _g.AddEdge(2, 7);
            _g.AddEdge(7, 2);

            _g.Bfs(0);
        }

        [Test]
        public void Dfs()
        {
            _g.AddEdge(0, 1);
            _g.AddEdge(1, 0);
            _g.AddEdge(1, 4);
            _g.AddEdge(4, 1);
            _g.AddEdge(4, 6);
            _g.AddEdge(6, 4);
            _g.AddEdge(6, 0);
            _g.AddEdge(0, 6);
            _g.AddEdge(1, 5);
            _g.AddEdge(5, 1);
            _g.AddEdge(5, 3);
            _g.AddEdge(3, 5);
            _g.AddEdge(3, 0);
            _g.AddEdge(0, 3);
            _g.AddEdge(5, 2);
            _g.AddEdge(2, 5);
            _g.AddEdge(2, 7);
            _g.AddEdge(7, 2);

            _g.Dfs(0);
        }
    }
}
