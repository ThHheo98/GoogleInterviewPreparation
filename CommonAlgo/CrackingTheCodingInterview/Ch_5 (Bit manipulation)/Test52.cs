using System;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test52
    {
        [TestCase(0.72f)]
        public void Test(float n)
        {
            string printBinary = PrintBinary(n);
            string binaryString = ToBinaryString1(n);
            Assert.AreEqual(binaryString, printBinary);
        }

        private static string ToBinaryString1(float n)
        {
            if (n >= 1 || n <= 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            while (n > 0)
            {
                if (sb.Length > 32)
                {
                    return "ERROR";
                }

                float r = n*2;
                if (r >= 1)
                {
                    sb.Append(1);
                    n = r - 1;
                }
                else
                {
                    sb.Append(0);
                    n = r;
                }
            }
            return sb.ToString();
        }

        private string PrintBinary(float f) // from gayle  second solution
        {
            if (f <= 0 || f >= 1)
                return string.Empty;

            var binary = new StringBuilder();

            float frac = 0.5f;
            while (f > 0)
            {
                if (binary.Length > 32) return string.Empty;

                if (f >= frac)
                {
                    binary.Append(1);
                    f -= frac;
                }
                else
                {
                    binary.Append(0);
                }
                frac /= 2;
            }

            return binary.ToString();
        }

        private static string ToBinaryString(float value)
        {
            int bitCount = sizeof (float)*8; // never rely on your knowledge of the size
            var result = new char[bitCount];
            // better not use string, to avoid ineffective string concatenation repeated in a loop

            // now, most important thing: (int)value would be "semantic" cast of the same
            // mathematical value (with possible rounding), something we don't want; so:
            int intValue = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

            for (int bit = 0; bit < bitCount; ++bit)
            {
                int maskedValue = intValue & (1 << bit); // this is how shift and mask is done.
                if (maskedValue > 0)
                    maskedValue = 1;
                // at this point, masked value is either int 0 or 1
                result[bitCount - bit - 1] = maskedValue.ToString()[0];
                // bits go right-to-left in usual Western Arabic-based notation
            }

            return new string(result); // string from character array
        }
    }
}