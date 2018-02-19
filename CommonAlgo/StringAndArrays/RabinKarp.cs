using System;
using NUnit.Framework;

namespace CommonAlgo.StringAndArrays
{
    public class RabinKarpOther
    {
        /*  pat  -> pattern
    txt  -> text
    q    -> A prime number
*/

        private void search(string pat, string txt, int q)
        {
            const int d = 256;
            int M = pat.Length;
            int N = txt.Length;
            int i, j;
            int p = 0; // hash value for pattern
            int t = 0; // hash value for txt
            int h = 1;

            // The value of h would be "pow(d, M-1)%q"
            for (i = 0; i < M - 1; i++)
                h = (h*d)%q;

            // Calculate the hash value of pattern and first window of text
            for (i = 0; i < M; i++)
            {
                p = (d*p + pat[i])%q;
                t = (d*t + txt[i])%q;
            }

            // Slide the pattern over text one by one 
            for (i = 0; i <= N - M; i++)
            {
                // Check the hash values of current window of text and pattern
                // If the hash values match then only check for characters on by one
                if (p == t)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < M; j++)
                    {
                        if (txt[i + j] != pat[j])
                            break;
                    }
                    if (j == M) // if p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]
                    {
                        Console.WriteLine("Pattern found at index {0} \n", i);
                    }
                }

                // Calculate hash value for next window of text: Remove leading digit, 
                // add trailing digit           
                if (i < N - M)
                {
                    t = (d*(t - txt[i]*h) + txt[i + M])%q;

                    // We might get negative value of t, converting it to positive
                    if (t < 0)
                        t = (t + q);
                }
            }
        }
    }


    public class RabinKarp
    {
        private readonly int M; // pattern length
        private readonly long Q; // a large prime, small enough to avoid long overflow
        private readonly int R; // radix
        private readonly long RM; // R^(M-1) % Q
        private readonly long patHash; // pattern hash value

        public RabinKarp()
        {
        }

        public RabinKarp(String pat)
        {
            R = 256;
            M = pat.Length;
            Q = 997;

            // precompute R^(M-1) % Q for use in removing leading digit
            RM = 1;
            for (int i = 1; i <= M - 1; i++)
                RM = (R*RM)%Q;
            patHash = hash(pat, M);
        }


        private long hash(String key, int m)
        {
            long h = 0;
            for (int j = 0; j < m; j++)
                h = (R*h + key[j])%Q;
            return h;
        }

        // check for exact match
        private int Search(String txt)
        {
            int n = txt.Length;
            if (n < M) return n;
            long txtHash = hash(txt, M);

            // check for match at offset 0
            if (patHash == txtHash)
                return 0;

            // check for hash match; if hash match, check for exact match
            for (int i = M; i < n; i++)
            {
                // Remove leading digit, add trailing digit, check for match. 
                txtHash = (txtHash + Q - RM*txt[i - M]%Q)%Q;
                txtHash = (txtHash*R + txt[i])%Q;

                // match
                if (patHash == txtHash)
                    return i - M + 1;
            }

            // no match
            return n;
        }

        [TestCase("There is no Needle", "no", Result = 9)]
        public int Test(string haystack, string needle)
        {
            var rabinKarp = new RabinKarp(needle);
            return rabinKarp.Search(haystack);
        }
    }
}