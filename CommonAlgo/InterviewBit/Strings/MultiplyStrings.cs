using System;
using System.Text;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/multiply-strings/
    /// </summary>
    public class MultiplyStrings
    {
        public string multiply(string num1, string num2)
        {
            var num1ch = num1.ToCharArray();
            var num2ch = num2.ToCharArray();
            Array.Reverse(num1ch);
            Array.Reverse(num2ch);
            var n1 = new string(num1ch);
            var n2 = new string(num2ch);

            var d = new int[num1.Length + num2.Length];

            //multiply each digit and sum at the corresponding positions
            for (var i = 0;
                i < n1.Length;
                i++)
            {
                for (var j = 0;
                    j < n2.Length;
                    j++)
                    d[i + j] += (n1[i] - '0') * (n2[j] - '0');
            }

            var sb = new StringBuilder();

            //calculate each digit
            for (var i = 0;
                i < d.Length;
                i++)
            {
                var mod = d[i] % 10;
                var carry = d[i] / 10;
                if (i + 1 < d.Length)
                    d[i + 1] += carry;
                sb.Insert(0, mod);
            }

            //remove front 0's
            while (sb[0] == '0' && sb.Length > 1)
                sb.Remove(0, 1);

            return sb.ToString();
        }
    }
}
