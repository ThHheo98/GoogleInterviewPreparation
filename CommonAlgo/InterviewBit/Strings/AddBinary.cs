using System;
using System.Text;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/add-binary-strings/
    /// </summary>
    public class AddBinary
    {
        public string addBinary(string a, string b)
        {
            var sb = new StringBuilder();
            int i = a.Length - 1, j = b.Length - 1, carry = 0;
            while (i >= 0 || j >= 0)
            {
                var sum = carry;
                if (j >= 0) sum += b[j--] - '0';
                if (i >= 0) sum += a[i--] - '0';
                sb.Append(sum % 2);
                carry = sum / 2;
            }
            if (carry != 0) sb.Append(carry);

            var ans = sb.ToString().ToCharArray();
            Array.Reverse(ans);
            return new string(ans);
        }
    }
}
