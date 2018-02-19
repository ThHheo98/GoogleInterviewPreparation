using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Operation Fill in Graphic Editor
    ///     screen[y][x] удобный способ работы с массивом пикселей
    /// </summary>
    public class Test97
    {
        public enum Color
        {
            Black,
            White,
            Red,
            Yellow,
            Green
        }

        [TestCase]
        public void Test()
        {
            var ar = new Color[5][];

            ar[0] = new Color[5];
            ar[1] = new Color[5];
            ar[2] = new Color[5];
            ar[3] = new Color[5];
            ar[4] = new Color[5];

            ar[0][0] = Color.Black;
            ar[0][1] = Color.Black;
            ar[0][2] = Color.Black;
            ar[0][3] = Color.Black;
            ar[0][4] = Color.Black;

            ar[1][0] = Color.Black;
            ar[1][1] = Color.White;
            ar[1][2] = Color.White;
            ar[1][3] = Color.White;
            ar[1][4] = Color.White;

            ar[2][0] = Color.Red;
            ar[2][1] = Color.Red;
            ar[2][2] = Color.Red;
            ar[2][3] = Color.Red;
            ar[2][4] = Color.Red;

            ar[3][0] = Color.Red;
            ar[3][1] = Color.Red;
            ar[3][2] = Color.Red;
            ar[3][3] = Color.Red;
            ar[3][4] = Color.Red;

            ar[4][0] = Color.Red;
            ar[4][1] = Color.Red;
            ar[4][2] = Color.Red;
            ar[4][3] = Color.Red;
            ar[4][4] = Color.Red;


            PaintFill(ar, 0, 0, Color.Green);

            Assert.IsTrue(ar[0][0] == Color.Green);
            Assert.IsTrue(ar[0][1] == Color.Green);
            Assert.IsTrue(ar[0][2] == Color.Green);
            Assert.IsTrue(ar[0][3] == Color.Green);
            Assert.IsTrue(ar[0][4] == Color.Green);
            Assert.IsTrue(ar[1][0] == Color.Green);
            Assert.IsTrue(ar[1][1] == Color.White);
        }

        private bool PaintFill(Color[][] screen, int x, int y, Color ocolor, Color ncolor)
        {
            if (x < 0 || x >= screen[0].Length || y < 0 || y >= screen.Length)
            {
                return false;
            }
            if (screen[y][x] == ocolor)
            {
                screen[y][x] = ncolor;
                PaintFill(screen, x - 1, y, ocolor, ncolor); // left
                PaintFill(screen, x + 1, y, ocolor, ncolor); // right
                PaintFill(screen, x, y - 1, ocolor, ncolor); // top
                PaintFill(screen, x, y + 1, ocolor, ncolor); // bottom
            }
            return true;
        }

        public bool PaintFill(Color[][] screen, int x, int y, Color ncolor)
        {
            return PaintFill(screen, x, y, screen[y][x], ncolor);
        }
    }
}