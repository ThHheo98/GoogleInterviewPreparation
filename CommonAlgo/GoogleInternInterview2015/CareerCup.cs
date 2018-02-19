using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    /// <summary>
    ///     http://www.careercup.com/question?id=5715287577985024
    /// </summary>
    public class TestCarrerCup
    {
        private const string DataFilePath = @"D:\work\Files\_Efremov\2015-11-30\data.bin";

        private static bool IsNumber(char ch)
        {
            return '0' <= ch && ch <= '9';
        }
        private static string GetMax(IEnumerable<char> ds, char delim)
        {
            if (ds == null) throw new ArgumentNullException();
            using (var en = ds.GetEnumerator())
            {
                var sb = new StringBuilder(int.MaxValue.ToString().Length);
                var curDelimCnt = 0;
                var lastDelimCnt = 0;
                var lastLineLength = int.MinValue;
                var curLineLength = 0;
                long sum = 0;
                var max = long.MinValue;
                bool hasNext;
                long value;
                var ch = char.MinValue;
                do
                {
                    hasNext = en.MoveNext();
                    if (!hasNext) continue;

                    ch = en.Current;
                    curLineLength++;

                    if (IsNumber(ch))
                        sb.Append(ch);
                    else if (ch == delim)
                    {
                        var s = sb.ToString();
                        value = s.Length == 0 ? 0 : long.Parse(s);
                        max = value > max ? value : max;
                        sb.Clear();
                        curDelimCnt++;
                        if (curDelimCnt == lastDelimCnt + 1)
                        {
                            if (curLineLength <= lastLineLength)
                                return "Invalid";

                            sum += max;
                           
                            max = long.MinValue;

                            lastDelimCnt = curDelimCnt;
                            curDelimCnt = 0;

                            lastLineLength = curLineLength;
                            curLineLength = 0;
                        }
                    }
                } while (hasNext);

                //  check that last line length more that previous
                if (curLineLength <= lastLineLength)
                    return "Invalid";
                //check last char
                if (ch != char.MinValue && !IsNumber(ch)) return "Invalid";

                value = long.Parse(sb.ToString());
                sum += value > max ? value : max;
                return sum.ToString();
            }
        }


        private static IEnumerable<char> GetDataSource(string s)
        {
            if (string.IsNullOrEmpty(s)) yield break;
            using (var reader = new StringReader(s))
            {
                int ch;
                while ((ch = reader.Read()) != -1)
                    yield return (char)ch;
            }
        }
        [TestCase]
        public void MainTest()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"1#1#2", "3"},
                {"1#1#2#", "Invalid"},
                {"1#1#2#1#2#3", "6"},
                {"1#1#2#1#2#3#", "Invalid"},
                {"1#1#2#1#2#3#1#2#3", "Invalid"},
                {"1#1#2#1#2#3#1#2#3#1", "9"},
                {"1", "1"},
                {"11", "11"},
                {";", "Invalid"},
                {"#", "Invalid"},
                {"1#2", "Invalid"},
                {"1##", "Invalid"},
                {"1##2", "Invalid"},
                {"1#2#3#7#4#8", "12"},
                {"7#3#7#1#7#5#6#1#9#7", "30"},
                {"7#3#7#1#7#5#6#1#9#7\0", "30"}
            };

            foreach (var pair in dictionary)
                Assert.AreEqual(pair.Value, GetMax(GetDataSource(pair.Key), '#'));
        }
        
        private static IEnumerable<char> GetDataSourceFromFile(string path)
        {
            if (string.IsNullOrEmpty(path)) yield break;
            using (var reader = new StreamReader(path, Encoding.ASCII, false, 1024 * 1024))
            {
                int ch;
                while ((ch = reader.Read()) != -1)
                    yield return (char)ch;
            }
        }

        [TestCase]
        public void Test2FromFile()
        {
            var dataSource = GetDataSourceFromFile(DataFilePath);
            var m = GetMax(dataSource, '#');
            Console.WriteLine(m);
        }

        private static double SolveQuadratic(double a, double b, double c)
        {
            var d = b*b - 4*a*c;
            if (d > 0)
            {
                var x1 = (-b + Math.Sqrt(d))/(2*a);
                var x2 = (-b - Math.Sqrt(d))/(2*a);
                return x1 > x2 ? x1 : x2;
            }

            var x = (-b + Math.Sqrt(d))/(2*a);
            return Math.Abs(x);
        }

        // compute interation count 
        // size_of_file = encoding_len * cnt_of_chars
        // cnt_of_chars = (len(digit) + len(delim)) * (n*(n+1)/2) = (len(digit) + len(delim)) * ( (n^2 + n)/2 )
        // len(digit) = length of digit returned by Random Generator
        // So  encoding_len * ( (len(digit) + len(delim)) * (n^2 + n)/2 ) = size_of_file
        // n^2 + n = 2*size_of_file / (encoding_len *(len(digit) + len(delim)))
        // For instance:
        // generate 1 Mb file in ASCII encoding consinst of 3 digits number with 1 char delimeter
        // size of file = len(ascii) * (len(digit)+len(delim)) * ( (n^2+n)/2 )
        // 1e6 = 1 * (3+1)*(n^2+n)/2 = 2(n^2+n)
        // n^2 + n - 5*1e5 = 0
        // n = 706.61
        // 1GB
        // n^2 + n - 5*1e8 = 0
        private static int GetN(double size, int digitLen, int delimLen, Encoding enc)
        {
            var encodingLen = 1; // FOR ASCII
            if (Equals(enc, Encoding.ASCII))
                encodingLen = 1;
            else return 0;

            //n ^ 2 + n 
            var rp = 2*size/(encodingLen*(digitLen + delimLen));
            var solveQuadratic = SolveQuadratic(1, 1, -rp);
            return (int) Math.Floor(solveQuadratic);
        }

        /// <summary>
        /// Method generate triangle file with random 3-digits numbers
        /// </summary>
        [TestCase((int)1e2, TestName = "Test")]
        //[TestCase((int)1e6, TestName = "MB1")]
        //[TestCase((int)1e9, TestName = "GB1")]
        //[TestCase((int)2e9, TestName = "GB2")]
        //[TestCase((int)4e9, TestName = "GB4")]
        //[TestCase((int)200e6, TestName = "MB200")]
        public void GenerateData(int sizeInBytes)
        {
            const string path = DataFilePath;
            const char delim = '#';
            var rnd = new Random((int) DateTime.Now.Ticks);

            long n = GetN(sizeInBytes, 3, 1, Encoding.ASCII);

            var chunkSize = (int)Math.Min(100, n);

            var j = 0;
            var prevLen = 0;
            var prevCnt = int.MinValue;
            var curCnt = 0;

            var sb = new StringBuilder();
            using (
                var writer =
                    new StreamWriter(new FileStream(path, FileMode.Create), Encoding.ASCII, 1024*1024)
                )
            {
                writer.AutoFlush = true;
                while (j < n)
                {
                    var curLen = 0;
                    while (curLen < prevLen || curCnt < prevCnt)
                    {
                        curCnt++;
                        var value = rnd.Next(100, 1000).ToString(); // 3 - digit chars
                        sb.Append(value);

                        curLen += value.Length + 1;

                        if (j + 1 != n || curLen < prevLen) sb.Append(delim);

                        // ReSharper disable once InvertIf
                        if ((curLen + 1) % chunkSize == 0)
                        {
                            writer.Write(sb.ToString());
                            sb.Clear();
                        }
                    }
                    prevLen = curLen + 1;
                    prevCnt = curCnt;
                    j++;
                    writer.Write(sb.ToString());
//                    if (j < n) writer.Write(Environment.NewLine);
                    sb.Clear();
                }
            }
        }
    }
}