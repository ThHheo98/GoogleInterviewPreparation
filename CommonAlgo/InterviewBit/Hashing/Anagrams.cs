using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/anagrams/
    ///     http://aliev.me/runestone/SortSearch/Hashing.html#fig-stringhash2
    /// </summary>
    /*
     Given an array of strings, return all groups of strings that are anagrams. Represent a group by a 
     list of integers representing the index in the original list. Look at the sample case for clarification.

 Anagram : a word, phrase, or name formed by rearranging the letters of another, such as 'spar', formed from 'rasp' 
 Note: All inputs will be in lower-case. 
Example :

Input : cat dog god tca
Output : [[1, 4], [2, 3]]
cat and tca are anagrams which correspond to index 1 and 4. 
dog and god are another set of anagrams which correspond to index 2 and 3.
The indices are 1 based ( the first element has index 1 instead of index 0).

 Ordering of the result : You should not change the relative ordering of the words / phrases w

        Anagrams will map to the same string if the characters in the string are sorted. 
Can you use the above fact to come up with a strategy ?

        Anagrams will map to the same string if the characters in the string are sorted.
We can maintain a hashmap with the key being the sorted string and the value being the list of strings ( which have the sorted characters as key ).
         */
    public class Anagrams
    {
        [Test]
        public void Test()
        {
            var list = new List<string> { "cat", "dog", "god", "tca" };

            var res = MyAnagramsMethod(list);

            var q = new Queue<List<int>>();
            q.Enqueue(new List<int> {1,4});
            q.Enqueue(new List<int> {2,3});
            int i = 0;
            while (q.Count>0)
            {
                CollectionAssert.AreEqual(q.Dequeue(),res[i]);
                i++;
            }

            res = AnagramsInterviewBit(list);

            q.Enqueue(new List<int> { 1, 4 });
            q.Enqueue(new List<int> { 2, 3 });
            i = 0;
            while (q.Count > 0)
            {
                CollectionAssert.AreEqual(q.Dequeue(), res[i]);
                i++;
            }
        }

        #region InterviewBit Solution with key sort

        public List<List<int>> AnagramsInterviewBit(IEnumerable<string> strings)
        {
            var res = new List<List<int>>();
            var hashMap = new Dictionary<string, List<int>>();

            var i = 1;
            foreach (var str in strings)
            {
                var array = str.ToCharArray();
                Array.Sort(array);
                var sorted = new string(array);

                if (hashMap.ContainsKey(sorted))
                {
                    hashMap[sorted].Add(i);
                }
                else
                {
                    var list = new List<int> { i };
                    hashMap[sorted] = list;
                }

                i++;
            }

            foreach (var entrySet in hashMap)
                res.Add(entrySet.Value);

            return res;
        }

        #endregion

        #region My solution

        private static int GetHash(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (s.Length == 1) return s[0] - '0';
            var r = 0;
            for (var i = 0; i < s.Length; i++)
                r += s[i] - '0';
            return r;
        }

        public List<List<int>> MyAnagramsMethod(List<string> a)
        {
            if (a == null || a.Count == 0) return new List<List<int>>();

            var d = new SortedDictionary<int, List<int>>();

            for (var i = 0; i < a.Count; i++)
            {
                var word = a[i];
                var hash = GetHash(word);
                if (!d.ContainsKey(hash))
                    d.Add(hash, new List<int>());

                d[hash].Add(i + 1);
            }

            var res = new List<List<int>>();

            var i1 = 0;
            while (i1 < a.Count && d.Count > 0)
            {
                var word = a[i1];
                var hash = GetHash(word);
                if (d.ContainsKey(hash))
                {
                    res.Add(d[hash]);
                    d.Remove(hash);
                }
                i1++;
            }

            return res;
        }

        #endregion
    }
}
