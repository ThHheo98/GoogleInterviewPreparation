using System;
using NUnit.Framework;

namespace CommonAlgo.ProjectEuler
{
    internal class Test8
    {

//        private int MaxMul(int[] a)
//        {
//            int max_ended_here = 1;
//            int min_ended_here = 1;
//            int max = 1;
//            int r = -1;
//            int k = 0;
//            for (int i = 0; i < a.Length; i++)
//            {
//                if (a[i] > 0)
//                {
//                    max_ended_here = max_ended_here*a[i];
//                    min_ended_here = Math.Min(1, min_ended_here*a[i]);
//                }
//                else if (a[i] == 0)
//                {
//                    max_ended_here = 1;
//                    min_ended_here = 1;
//                }
//                else
//                {
//                    int tmp = max_ended_here;
//                    max_ended_here = Math.Max(min_ended_here*a[i], 1);
//                    min_ended_here = tmp*a[i];
//                }
//                if (max_ended_here > max)
//                {
//                    max = max_ended_here;
//                    r = i;
//                    k++;
//                    if (k==13)
//                        break;
//                }
//            }
//            Console.WriteLine(max);
//
////            if (r != -1)
////            {
////                
////                int temp = max;
////                int left = r;
////                while (temp != 1)
////                {
////                    temp = temp / a[left--];
////                }
////                left++;
////                Console.WriteLine(left + " " + r);
////               
////                temp = 1;
////                for (int i = left; i < left+13; i++)
////                {
////                    temp *= a[i];
////                }
////                Console.WriteLine(temp);
////                Console.WriteLine(temp/a[r]);
////                Console.WriteLine(temp/a[r-1]/a[r]);
////            }
//            
//
//            return max;
//        }




        [TestCase(@"7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450")]
      //  [TestCase("4561000")]
        public void Test(string s)
        {
            var ints = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                ints[i] = int.Parse(s[i].ToString());
            }

            MaxMul(ints);
        }

        private void MaxMul(int[] ints)
        {
            long p = 1;
            long pl = int.MinValue;
            for (int i = 0; i < ints.Length -13; i++)
            {
                p = 1;
                for (int j = i; j < i+13; j++)
                {
                    p = p*ints[j];
                }
                if (p > pl)
                {
                    pl = p;
                }
            }
            Console.WriteLine(pl);
        }
    }
}