using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    public class SumRootToleafNumbersDfs
    {
        [TestCase]
        public int SumNumbers(TreeNodeIb a)
        {
            if (a == null)
                return 0;

            return DFS(a, 0, 0) % 1003;
        }

        private static int DFS(TreeNodeIb a, int num, int sum)
        {
            if (a == null)
                return sum % 1003;

            num = (num * 10 + a.val) % 1003;

            if (a.left == null && a.right == null)
            {
                sum = (sum + num) % 1003;
                return sum % 1003;
            }

            sum = (sum + DFS(a.left, num, sum) + DFS(a.right, num, sum)) % 1003;
            return sum % 1003;
        }
    }

    internal class SumRootToLeafNumbersDynamic
    {
        public int SumNumbers(TreeNodeIb root)
        {
            var result = 0;
            if (root == null)
                return result;

            var res = new List<List<TreeNodeIb>>();
            var cur = new List<TreeNodeIb>();
            cur.Add(root);
            DFS(root, cur, res);

            foreach (var nodes in res)
            {
                var sb = new StringBuilder();
                foreach (var node in nodes)
                    sb.Append(node.val.ToString());
                var currValue = int.Parse(sb.ToString());
                result = result + currValue;
            }

            return result;
        }

        private static void DFS(TreeNodeIb n, List<TreeNodeIb> l, List<List<TreeNodeIb>> all)
        {
            if (n.left == null && n.right == null)
            {
                var t = new List<TreeNodeIb>();
                t.AddRange(l);
                all.Add(t);
            }

            if (n.left != null)
            {
                l.Add(n.left);
                DFS(n.left, l, all);
                l.RemoveAt(l.Count - 1);
            }

            if (n.right != null)
            {
                l.Add(n.right);
                DFS(n.right, l, all);
                l.RemoveAt(l.Count - 1);
            }
        }
    }
}
