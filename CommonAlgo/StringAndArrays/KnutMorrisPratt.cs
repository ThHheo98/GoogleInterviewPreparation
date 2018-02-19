using System;
using NUnit.Framework;

namespace CommonAlgo.StringAndArrays
{
    /// <summary>
    ///     Алгоритм Кнута — Морриса — Пратта (КМП-алгоритм) — алгоритм, осуществляющий поиск подстроки в строке.
    ///     Алгоритм был открыт Д. Кнутом и В. Праттом и, независимо от них, Д. Моррисом.
    ///     Результаты своей работы они опубликовали совместно в 1977 году[2].
    ///     http://e-maxx.ru/algo/prefix_function
    /// </summary>
    [TestFixture]
    public class KnutMorrisPrattTestFixture
    {
        [TestCase("needle", "This is an example of the needle needle", Result = true, TestName = "test1")]
        [TestCase("a", "abc", Result = true, TestName = "test2")]
        [TestCase("b", "abc", Result = true, TestName = "test3")]
        [TestCase("abacaba", "abacaba", Result = true, TestName = "test4")]
        [TestCase("a", "aba", Result = true, TestName = "test5")]
        public bool KnutMorrisPrattTest(string needle, string haystack)
        {
            return KnutMorrisPrattAlgo.FindSubstring(haystack, needle) != -1;
        }

        [TestCase("aaaaaaa")]
        public void KnutMorrisPrattTest1(string haystack)
        {
            var prefix = KnutMorrisPrattAlgo.GetPrefixFunction(haystack);
            Utils.PrintCollection(prefix);
        }

        [TestCase("aaaaaaa")]
        public void KnutMorrisPrattTest2(string haystack)
        {
            var prefix = KnutMorrisPrattAlgo.GetPrefixWiki(haystack);
            Utils.PrintCollection(prefix);
            KnutMorrisPrattAlgo.FindSubstringSimple(haystack, "a");
        }

        [TestCase("Mississippi", "issipp", Result = true, TestName = "mis0")]
        [TestCase("Mississippi", "issipi", Result = false, TestName = "mis1")]
        public bool KnutMorrisPrattTest3(string haystack, string needle)
        {
            var findSubstringWiki = KnutMorrisPrattAlgo.FindSubstringSimple(needle, haystack);
            Console.WriteLine(findSubstringWiki);
            return findSubstringWiki != -1;
        }
    }

    public static class KnutMorrisPrattAlgo
    {
        /// <summary>
        ///     КРИВОЙ МЕТОД НЕ ПРОХОДИТ ДЛЯ ЭТОГО СЛУЧАЯ [TestCase("Mississippi", "issipi", Result = false, TestName = "mis2")]
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [Obsolete]
        public static int[] GetPrefixWiki(string text)
        {
            var r = new int[text.Length];
            var ind = 0;
            for (var i = 1; i < r.Length; i++)
            {
                while ((ind >= 0) && (text[i] != text[ind]))
                {
                    ind--;
                }
                ind++;
                r[i] = ind;
            }
            return r;
        }

        private static int[] GetPrefixEmax(string text)
        {
            var n = text.Length;

            var pi = new int[n];
            pi[0] = 0;

            for (var i = 1; i < n; i++)
            {
                var j = pi[i - 1];

                while (j > 0 && text[j] != text[i])
                {
                    j = pi[j - 1];
                }

                if (text[j] == text[i])
                {
                    j++;
                }

                pi[i] = j;
            }
            return pi;
        }

        /// <summary>
        /// </summary>
        /// <param name="needle"></param>
        /// <param name="haystack"></param>
        /// <returns></returns>
        public static int FindSubstringSimple(string needle, string haystack)
        {
            var s = needle + "$" + haystack;

            var pf = GetPrefixEmax(s);
            Utils.PrintCollection(pf);

            for (var i = 0; i < s.Length; i++)
            {
                if (pf[i] == needle.Length)
                {
                    return i - 2 * needle.Length;
                }
            }
            return -1;
        }

        public static int FindSubstringWiki(string pattern, string text)
        {
            var pr = GetPrefixWiki(pattern);

            //            var ind = 0;
            //            for (var i = 1; i < text.Length; i++)
            //            {
            //                while (ind > 0 && text[i] != text[ind])
            //                    ind = r[ind - 1];
            //
            //                if (text[i] == text[ind])
            //                    ind++;
            //
            //                r[i] = ind;
            //            }

            var index = 0;
            for (var i = 0; i < text.Length; i++)
            {
                while ((index > 0) && (text[i] != pattern[index]))
                {
                    pr[index] = pr[index - 1];
                }

                if (text[i] == pattern[index])
                {
                    index++;
                }
                if (index == pattern.Length)
                {
                    return i - index + 1;
                }
            }
            return -1;
        }

        /// <summary>
        ///     Оценка O(n + m) и O(m) по памяти
        /// </summary>
        /// <param name="needle"></param>
        /// <param name="haystack"></param>
        public static int FindSubstring(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                throw new ArgumentException("Needle should have a value");
            }
            if (string.IsNullOrEmpty(haystack))
            {
                throw new ArgumentException("Haystack should have a value");
            }

            var d = GetPrefixFunction(needle);
            Utils.PrintCollection(d);
            var i = 0;
            var j = 0;
            while ((i < haystack.Length) && (j < needle.Length))
            {
                while ((j >= 0) && (needle[j] != haystack[i]))
                {
                    j = d[j];
                }

                i++;
                j++;
            }

            return j == needle.Length ? i - j : -1;
        }

        public static int[] GetPrefixFunction(string s)
        {
            var k = 0;
            var pi = new int[s.Length];
            pi[0] = -1;
            for (var i = 1; i < s.Length - 1; i++)
            {
                while ((k >= 0) && (s[k] != s[i])) // k >= 0 откатываемся до начала массива и не дальше
                {
                    k = pi[k];
                }

                k++;
                if (s[i] == s[k])
                {
                    pi[i] = pi[k];
                }
                else
                {
                    pi[i] = k;
                }
            }
            return pi;
        }
    }
}
