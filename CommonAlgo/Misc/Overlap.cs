namespace CommonAlgo.Misc
{
    public class Overlap
    {
        // program interview exposed ch 11 task 2 overlap

        public bool IsOverlap(Rect a, Rect b)
        {
            return a.UL._x <= b.LR._x && a.UL._y >= b.LR._y
                   && a.LR._x >= b.UL._x
                   && a.LR._y <= b.UL._y;
        }

        public struct Point
        {
            public int _x;
            public int _y;

            public Point(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }

        public struct Rect
        {
            public Point LR;
            public Point UL;

            public Rect(Point ul, Point lr)
            {
                UL = ul;
                LR = lr;
            }
        }
    }
}