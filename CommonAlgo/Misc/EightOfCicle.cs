using System;

namespace CommonAlgo.Misc
{
    public class EightOfCicle
    {
        // program interview exposed chapter 11 task 1
        private void DraqEightOfCicle(int radius)
        {
            int x = 0;
            int y = radius;
            while (y > x)
            {
                y = (int) ((Math.Sqrt(radius*radius - x*x)) + 0.5);
                SetPixel(x, y);
                x++;
            }
        }

        private void SetPixel(int x, int y)
        {
        }
    }
}