using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/2-sum-binary-tree/
    ///     // это решение работает и очень хорошо
    /// </summary>
    public class t2SumIb
    {
        [TestCase(Result = 1)]
        public int T2Sum()
        {
            var root = new TreeNodeIb(10) { right = new TreeNodeIb(20), left = new TreeNodeIb(9) };
            var sum = 19;
            var sumIb = new Bst(root);

            var x1 = sumIb.Left();
            var x2 = sumIb.Right();

            while (x1 < x2)
            {
                if (x1 + x2 == sum)
                    return 1;
                if (x1 + x2 < sum)
                    x1 = sumIb.Left();
                else
                    x2 = sumIb.Right();
            }
            return 0;
        }

        private class Bst
        {
            private readonly Stack<TreeNodeIb> _mys1 = new Stack<TreeNodeIb>();
            private readonly Stack<TreeNodeIb> _mys2 = new Stack<TreeNodeIb>();
            private TreeNodeIb _cur1;
            private TreeNodeIb _cur2;

            public Bst(TreeNodeIb root)
            {
                _cur1 = _cur2 = root;
            }

            public int Left()
            {
                while (true)
                {
                    if (_cur1 != null)
                    {
                        _mys1.Push(_cur1);
                        _cur1 = _cur1.left;
                        continue;
                    }

                    if (_mys1.Count > 0)
                    {
                        _cur1 = _mys1.Peek();
                        var ans = _cur1.val;
                        _mys1.Pop();
                        _cur1 = _cur1.right;
                        return ans;
                    }
                    break;
                }
                return int.MinValue;
            }

            public int Right()
            {
                while (true)
                {
                    if (_cur2 != null)
                    {
                        _mys2.Push(_cur2);
                        _cur2 = _cur2.right;
                        continue;
                    }

                    if (_mys2.Count > 0)
                    {
                        _cur2 = _mys2.Peek();
                        var ans = _cur2.val;
                        _mys2.Pop();
                        _cur2 = _cur2.left;
                        return ans;
                    }

                    break;
                }
                return int.MaxValue;
            }
        }
    }

    /// <summary>
    ///     http://www.geeksforgeeks.org/find-a-pair-with-given-sum-in-bst/
    ///     не прошло на interviewbit
    /// </summary>
    public class T2SumGeeks
    {
        [TestCase(Result = 1)]
        public int t2Sum()
        {
            var a = new TreeNodeIb(5) { right = new TreeNodeIb(7) { right = new TreeNodeIb(10) } };
            var b = 10;
            if (a == null)
                return 0;
            if (a.left == null && a.right == null)
                return 0;

            var r = isExistsSum(a, b);
            return r ? 1 : 0;
        }

        private bool isExistsSum(TreeNodeIb root, int sum)
        {
            var leftStack = new Stack<TreeNodeIb>();
            var rightStack = new Stack<TreeNodeIb>();

            var leftDone = false;
            var rightDone = false;

            var leftValue = -1;
            var rightValue = -1;

            var leftIter = root;
            var rightIter = root;

            while (true)
            {
                // Find next node in normal Inorder traversal. See following post
                while (!leftDone)
                {
                    if (leftIter != null)
                    {
                        leftStack.Push(leftIter);
                        leftIter = leftIter.left;
                    }
                    else
                    {
                        if (leftStack.Count == 0)
                        {
                            leftDone = true;
                        }
                        else
                        {
                            leftIter = leftStack.Pop();
                            leftValue = leftIter.val;
                            leftIter = leftIter.right;
                            leftDone = true;
                        }
                    }
                }

                // Find next node in REVERSE Inorder traversal. The only
                // difference between above and below loop is, in below loop
                // right subtree is traversed before left subtree
                while (!rightDone)
                {
                    if (rightIter != null)
                    {
                        rightStack.Push(rightIter);
                        rightIter = rightIter.right;
                    }
                    else
                    {
                        if (rightStack.Count == 0)
                        {
                            rightDone = true;
                        }
                        else
                        {
                            rightIter = rightStack.Pop();
                            rightValue = rightIter.val;
                            rightIter = rightIter.left;
                            rightDone = true;
                        }
                    }
                }

                if (rightValue != leftValue && leftValue + rightValue == sum)
                    return true;

                if (rightValue + leftValue < sum)
                {
                    leftDone = false;
                    continue;
                }

                if (rightValue + leftValue > sum)
                {
                    rightDone = false;
                    continue;
                }

                // If any of the inorder traversals is over, then there is no pair
                // so return false
                if (leftValue >= rightValue)
                    return false;
            }
            return false;
        }
    }
}
