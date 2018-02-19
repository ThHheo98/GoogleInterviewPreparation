namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/roman-to-integer/
    /// </summary>
    public class RomanToInteger
    {
        // This function returns value of a Roman symbol
        private int value(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;

            return -1;
        }

        public int RomanToInt(string str)
        {
            // Initialize result
            var res = 0;

            // Traverse given input
            for (var i = 0;
                i < str.Length;
                i++)
            {
                // Getting value of symbol s[i]
                var s1 = value(str[i]);

                if (i + 1 < str.Length)
                {
                    // Getting value of symbol s[i+1]
                    var s2 = value(str[i + 1]);

                    // Comparing both values
                    if (s1 >= s2)
                    {
                        // Value of current symbol is greater
                        // or equal to the next symbol
                        res = res + s1;
                    }
                    else
                    {
                        res = res + s2 - s1;
                        i++; // Value of current symbol is
                        // less than the next symbol
                    }
                }
                else
                {
                    res = res + s1;
                    i++;
                }
            }
            return res;
        }
    }
}
