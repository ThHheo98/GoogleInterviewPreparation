using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/shortest-unique-prefix/
    /// </summary>
    public class SolutionIb
    {
        private Node _root;

        public List<string> prefix(List<string> list)
        {
            var res = new List<string>();

            foreach (var str in list)
                _root = BuildTree(_root, str, 0);

            foreach (var str in list)
            {
                var strB = new StringBuilder();
                var prefix = GetPrefix(_root, str, 0, strB);
                res.Add(prefix);
            }

            return res;
        }

        private string GetPrefix(Node node, string str, int index, StringBuilder sb)
        {
            var c = str[index];

            if (c < node.ch)
                return GetPrefix(node.left, str, index, sb);
            if (c > node.ch)
                return GetPrefix(node.right, str, index, sb);
            if (node.val == 1)
            {
                sb.Append(node.ch);
                return sb.ToString();
            }
            sb.Append(node.ch);
            return GetPrefix(node.mid, str, index + 1, sb);
        }

        private static Node BuildTree(Node node, string str, int index)
        {
            if (index == str.Length)
                return node;

            if (node == null)
                node = new Node(str[index]);

            var c = str[index];

            if (c < node.ch)
            {
                node.left = BuildTree(node.left, str, index);
            }
            else if (c > node.ch)
            {
                node.right = BuildTree(node.right, str, index);
            }
            else
            {
                node.mid = BuildTree(node.mid, str, index + 1);
                node.val += 1;
            }

            return node;
        }

        public class Node
        {
            public readonly char ch;
            public Node left;
            public Node mid;
            public Node right;
            public int val;

            public Node(char c)
            {
                ch = c;
                val = 0;
            }
        }
    }

    public class Solution
    {
        private const int alphabetSize = 256;

        // Method to insert a new string into Trie
        private void Insert(TrieNode root, string s)
        {
            var t = root;

            for (var level = 0;
                level < s.Length;
                level++)
            {
                int index = s[level];

                if (t.Children[index] == null)
                    t.Children[index] = new TrieNode();
                else
                    t.Children[index].Frequency++;

                t = t.Children[index];
            }
        }

        private static void FindPrefixes(ICollection<string> r,
            TrieNode root, char[] prefix, int index)
        {
            if (root == null)
                return;

            if (root.Frequency == 1)
            {
                prefix[index] = '\0';
                var c = 0;
                while (prefix[c] != '\0')
                    c++;
                var cpy = new char[c];
                Array.Copy(prefix, cpy, c);
                r.Add(new string(cpy));
                return;
            }

            for (var i = 0;
                i < alphabetSize;
                i++)
            {
                if (root.Children[i] != null)
                {
                    prefix[index] = (char)i;
                    FindPrefixes(r, root.Children[i], prefix, index + 1);
                }
            }
        }

        private List<string> FindPrefixes(List<string> arr)
        {
            var root = new TrieNode { Frequency = 0 };
            for (var i = 0;
                i < arr.Count;
                i++)
                Insert(root, arr[i]);

            var r = new List<string>();
            var prefix = new char[500];

            FindPrefixes(r, root, prefix, 0);

            return r;
        }

        public List<string> prefix(List<string> a)
        {
            if (a == null || a.Count == 0)
                return null;
            var r = FindPrefixes(a);
            return r;
        }

        [TestCase]
        public void Test()
        {
            var a = new List<string> { "zebra", "dog", "duck", "dove" };
            var r = prefix(a);
            foreach (var item in r)
                Console.WriteLine(item);
        }

        private class TrieNode
        {
            public readonly TrieNode[] Children = new TrieNode[alphabetSize];
            public int Frequency = 1;
        }
    }
}
