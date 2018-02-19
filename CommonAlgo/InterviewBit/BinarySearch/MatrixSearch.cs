using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    public class MatrixSearch
    {
        [Test]
        public void Test()
        {
            var a = new[,]
            {
                { 1, 3, 5, 7 },
                { 10, 11, 16, 20 },
                { 23, 30, 34, 50 }
            };

            var matrix = searchMatrix(a, 16);
            Assert.AreEqual(1, matrix);
        }

        private int searchMatrix(int[,] A, int B)
        {
            var n = A.GetLength(0);
            var m = A.GetLength(1);

            var start = 0;
            var end = n * m - 1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                var row = mid / m;
                var col = mid % m;

                if (A[row, col] == B)
                    return 1;
                if (A[row, col] < B)
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            return 0;
        }
    }
}
