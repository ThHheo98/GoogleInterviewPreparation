using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class Test105
    {
        [Test]
        public void Test()
        {
            string[] a = {"a", "", "b", "", "c", "", "d"};
            const string toFind = "c";

            Assert.AreEqual(4, Search(a, toFind));
        }

        private int Search(string[] a, string toFind)
        {
            if (string.IsNullOrEmpty(toFind) || a == null)
                return -1;
            return Search(a, 0, a.Length, toFind);
        }


        private int Search(string[] a, int l, int r, string toFind)
        {
            int mid = l + (r - l)/2;
            // проверим, если строка пустая, то обрабаытваем соответсвенным образом
            if (string.IsNullOrEmpty(a[mid]))
            {
                int midLeft = mid - 1; // проверим элемнет справа и слева
                int midRight = mid + 1;
                while (true)
                {
                    // проверим вырожденный случай
                    if (midLeft < l || midRight > r)
                    {
                        return -1;
                    }

                    if (midRight <= l && !string.IsNullOrEmpty(a[midRight]))
                    {
                        mid = midRight;
                        break;
                    }

                    if (midLeft >= l && !string.IsNullOrEmpty(a[midLeft]))
                    {
                        mid = midLeft;
                        break;
                    }

                    midLeft--; // расходимся в  стороны от средней точки
                    midRight++;
                }
            }


            if (a[mid] == toFind)
            {
                return mid;
            }

            if (String.Compare(a[mid], toFind, StringComparison.CurrentCultureIgnoreCase) < 0)
            {
                return Search(a, mid + 1, r, toFind); // поиск вправо т.к. toFind больше a[mid]
            }
            return Search(a, l, mid - 1, toFind); // поиск влево т.к. toFind меньше a[mid]
        }
    }
}