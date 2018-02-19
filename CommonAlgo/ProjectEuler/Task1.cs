using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    /// <summary>
    ///     Multiples of 3 and 5
    ///     https://projecteuler.net/problem=1
    /// </summary>
    public class Task1
    {
        //[TestCase(1000, TestName = "test1000")]
        [TestCase(10, TestName = "test_to_3_5", Result = 23)]
        [TestCase(16, TestName = "test_to_3_51", Result = 60)]
        [TestCase(1000, TestName = "test_to_3_51", Result = 1000)]
        public int Test(int n)
        {
            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                {
                    result += i;
                }
            }
            return result;
        }


        /// <summary>
        /// однако, если будет, например, n = 100000000
        /// то будет переполнение
        /// Решение: 
        /// 1) использовать для хранения результата переменную большого размера (напр. long)
        /// 2) Переработать алгоритм т.е. 
        ///    вернуть сумма_чисел_которые_делятся_на_3(а) + сумма_чисел_которые_делятся_на_5(б)
        ///     - сумма_чисел_которые_делятся_на_15(потому что они посчитаны дважды при предыдущем суммировании (а + б))
        /// https://projecteuler.net/overview=001
        /// </summary>
        /// <param name="n"></param>
        [TestCase(1000, TestName = "test1000")]
        [TestCase(1000000, TestName = "test1000000")]
        public void TestEffecient(int n)
        {
            var res = SumDivisibleBy(n-1, 3) + SumDivisibleBy(n-1, 5) - SumDivisibleBy(n-1, 15);
            Assert.AreEqual(SimpleSolution(n), res);

        }


        /// <summary>
        /// Данная формула получается из другой известной формулы + 1 рассуждения
        /// Формула частичной суммы натурального ряда: 0.5*n*(n+1) (треугольное число)
        /// https://ru.wikipedia.org/wiki/%D0%A2%D1%80%D0%B5%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%BE%D0%B5_%D1%87%D0%B8%D1%81%D0%BB%D0%BE
        /// И рассуждения, что мы будем по сути суммировать
        /// Сумма чисел меньше 1000, которые делятся на 3
        /// 3 + 6 + 9 + ... + 333 = 3*(1+2+3+...+111)
        /// То есть сумма равна => делитель*частичную_сумму_нат_ряда_в_дипазоне_от_1_до_(1000-1)_div_делитель
        /// Или:
        /// p = (1000-1)/делитель
        /// result = n*(0.5*(p*(p + 1)))
        /// </summary>
        /// <param name="target"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private long SumDivisibleBy(int target, int n)
        {
            var p = target/n; // операция div
            return (long) (n * (0.5 * (p * (p + 1))));
        }

        private int SimpleSolution(int n)
        {
            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            return result;
        }


        [TestCase(1000, TestName = "test_to_3_5")]
        public void Test1(int n)
        {
            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            Console.WriteLine(result);
        }
    }
}