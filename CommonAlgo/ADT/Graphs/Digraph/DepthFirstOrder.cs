using System.Collections.Generic;
using CommonAlgo.ADT.Graphs.Base;

namespace CommonAlgo.ADT.Graphs.Digraph
{
    public class DepthFirstOrder
    {
        private readonly bool[] _marked;
        private readonly Queue<int> _post = new Queue<int>(); // edge on postorder
        private readonly Queue<int> _pre = new Queue<int>(); // edge in preorder

        private readonly Stack<int> _reversePost = new Stack<int>();
            // edge in reverse postorder (Proposition F. Reverse postorder in a DAG is a topological sort.)

        public DepthFirstOrder(IDigraph g)
        {
            _marked = new bool[g.V];

            for (int v = 0; v < g.V; v++)
            {
                if (!_marked[v]) Dfs(g, v);
            }
        }

        public IEnumerable<int> Pre
        {
            get { return _pre; }
        }

        public IEnumerable<int> Post
        {
            get { return _post; }
        }

        public IEnumerable<int> ReversePost
        {
            get { return _reversePost; }
        }

        private void Dfs(IDigraph g, int v)
        {
            _pre.Enqueue(v);
            _marked[v] = true;
            for (int w = 0; w < g.V; w++)
            {
                if (!_marked[v]) Dfs(g, w);
            }
            _post.Enqueue(v);
            _reversePost.Push(v);
        }
    }
}