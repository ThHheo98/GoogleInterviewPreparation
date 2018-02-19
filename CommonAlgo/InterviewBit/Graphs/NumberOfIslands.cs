using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    /// <summary>
    ///     http://www.geeksforgeeks.org/find-number-of-islands/
    /// </summary>
    public class NumberOfIslands
    {
        [Test]
        public void Test()
        {
            var a = new[,]
            {
                { 1, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1 }
            };

            var count = GetCount(a);
            Assert.AreEqual(9, count);
        }

        private int GetCount(int[,] island)
        {
            var ans = 0;

            var n = island.GetLength(0);
            var m = island.GetLength(1);
            var visited = new bool[n, m];
            for (var i = 0;
                i < n;
                i++)
            {
                for (var j = 0;
                    j < m;
                    j++)
                {
                    if (island[i, j] == 1 && !visited[i, j])
                    {
                        ans++;
                        Dfs(island, visited, i, j);
                    }
                }
            }
            return ans;
        }

        private void Dfs(int[,] island, bool[,] visited, int i, int j)
        {
            int[] rows = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] cols = { -1, 0, 1, -1, 1, -1, 0, 1 };

            visited[i, j] = true;
            for (var k = 0;
                k < 8;
                k++)
            {
                if (IsSafeCell(island, visited, i + rows[k], j + cols[k]))
                    Dfs(island, visited, i + rows[k], j + cols[k]);
            }
        }

        private bool IsSafeCell(int[,] island, bool[,] visited, int i, int j)
        {
            return i >= 0 && i < island.GetLength(0)
                   && j >= 0 && j < island.GetLength(1) && island[i, j] == 1 && !visited[i, j];
        }
    }
}
