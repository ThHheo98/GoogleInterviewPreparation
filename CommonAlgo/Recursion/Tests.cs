using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.Recursion
{
    public class Tests
    {
        // 1. remove first char 
        // 2. find permutations of the rest of chars
        // 3. Attach the first char to each of those permutations.
        //     3.1  for each permutation, move firstChar in all indexes to produce even more permutations.
        // 4. Return list of possible permutations.

        private const int PhoneNumberLength = 7;

        private IEnumerable<string> FindPermutations(string str)
        {
            if (str.Length == 2)
            {
                char[] c = str.ToCharArray();
                var s = new string(new[] {c[1], c[0]});
                return new[]
                {
                    str,
                    s
                };
            }

            var result = new List<string>();

            char firstChar = str[0];
            IEnumerable<string> permutations = FindPermutations(str.Substring(1));
            foreach (string s in permutations)
            {
                string temp = firstChar + s;
                result.Add(temp);

                char[] chars = temp.ToCharArray();
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    Swap(chars, i, i + 1);
                    var item = new string(chars);
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        private void Swap(char[] s, int i, int i1)
        {
            char t = s[i];
            s[i] = s[i1];
            s[i1] = t;
        }

        [TestCase("ABC")]
        public void PermutationTest(string s)
        {
            IEnumerable<string> findPermutations = FindPermutations(s);
            foreach (string findPermutation in findPermutations)
            {
                Console.WriteLine(findPermutation);
            }
        }

        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7})]
        public void PrintAllWordByNumber(int[] phoneNum)
        {
            var result = new char[PhoneNumberLength];
            DoPrintTelephoneWords(phoneNum, 0, result);
        }

        private void DoPrintTelephoneWords(int[] phoneNum, int curDigit,
            char[] result)
        {
            if (curDigit == PhoneNumberLength)
            {
                Console.WriteLine(new string(result));

                return;
            }
            for (int i = 1; i <= 3; i++)
            {
                result[curDigit] = GetCharKey(phoneNum[curDigit], i);
                DoPrintTelephoneWords(phoneNum, curDigit + 1, result);
                if (phoneNum[curDigit] == 0 ||
                    phoneNum[curDigit] == 1) return;
            }
        }


        [TestCase("ABC")]
        public void CombinationTest(string s)
        {
            var sb = new StringBuilder();
            PrintCombination(s.ToCharArray(), s.Length, sb, 0);
        }

        

        [TestCase("ABC")]
        public void CombinationTest1(string s)
        {
            var combinations = Helper.Combinations(s, s.Length);
            foreach (var combination in combinations)
            {
                Utils.PrintCollection(combination.ToArray());
            }

            var result = Helper.Combinations(new[] { 1, 2, 3, 4, 5 }, 4);
            foreach (var combination in result)
            {
                Utils.PrintCollection(combination.ToArray());
            }
        }

        private void PrintCombination(char[] s, int length, StringBuilder sb, int start)
        {
            for (int i = start; i < length; i++)
            {
                sb.Append(s[i]);
                Console.WriteLine(sb);
                if (i < length - 1)
                {
                    PrintCombination(s, length, sb, i + 1);
                }
                sb.Length = sb.Length - 1;
            }
        }

        private static char GetCharKey(int i, int i1)
        {
            return 'a';
        }

        [TestCase()]
        public void Combine()
        {
            int n = 2;
            int k = 1;
            var r = new List<IList<int>>();
            //http://www.martinbroadhurst.com/source/combination.c.html
            var a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = i + 1;

            IList<int> b = Enumerable.Range(1, n).Select(x => x).ToList();
             for(int i = 0; i < n; i++)
                 Console.WriteLine(b[i]);


            int j = 0;
            do
            {
                r.Add(new List<int>());
                //Console.WriteLine("j=" + j);


                for (int i = 0; i < k; i++)
                {
                    r[j].Add(a[i]);
                  //  Console.WriteLine(r[j][i]);
                }

                j++;
            } while (NextComb(a, k));

            //Console.WriteLine();


            for (int i = 0; i < r.Count; i++)
            {
              //  for (int h = 0; h < r[i].Count; h++)
                   // Console.Write(r[i][h] + " ");
            }
            //return r;
        }

        private bool NextComb(int[] a, int k)
        {
            bool finished = false;
            bool changed = false;
            int i = 0;
            if (k > 0)
            {
                for (i = k - 1; !finished && !changed; i--)
                {
                    if (a[i] < (a.Length - 1) - (k - 1) + i + 1)
                    {
                        /* Increment this element */
                        a[i]++;
                        if (i < k - 1)
                        {
                            /* Turn the elements after it into a linear sequence */
                            for (int j = i + 1; j < k; j++)
                            {
                                a[j] = a[j - 1] + 1;
                            }
                        }
                        changed = true;
                    }
                    finished = i == 0;
                }
                if (!changed)
                {
                    /* Reset to first combination */
                    for (i = 0; i < k; i++)
                    {
                        a[i] = i;
                    }
                }
            }
            return changed;
        }
    }

    static class Helper
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            switch (k)
            {
                case 0:
                    return new[] { new T[0] };
                default:
                    return elements.SelectMany((e, i) =>
                            Combinations(elements.Skip(i + 1), k - 1).Select(c => new[] { e }.Concat(c)));
            }
        }
    }
}