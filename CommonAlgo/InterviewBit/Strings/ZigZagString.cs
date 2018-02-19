using System.Text;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/zigzag-string/
    /// </summary>
    public class ZigZagString
    {
        public string convert(string s, int n)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            if (n <= 1) return s;

            var arr = new string[n];
            for (var i = 0;
                i < n;
                i++) arr[i] = string.Empty;
            var step = 0;
            var row = 0;

            for (var i = 0;
                i < s.Length;
                i++)
            {
                arr[row] += s[i];

                if (row == 0) step = 1;
                else if (row == n - 1) step = -1;

                row += step;
            }

            var sb = new StringBuilder();
            for (var i = 0;
                i < n;
                i++)
                sb.Append(arr[i]);

            return sb.ToString();
        }
    }
}
