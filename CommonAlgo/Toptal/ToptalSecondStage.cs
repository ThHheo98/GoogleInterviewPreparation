using System;
using NUnit.Framework;

namespace CommonAlgo.Toptal
{
    internal class ToptalSecondStage
    {
        [TestCase(1000000, Result = 55)]
        public static int Test(int n)
        {
            //Problem 35 CircularPrime 
            var result = 0;
            for (var i = 0; i <= n; i++)
            {
                if (!IsCircularPrime(i)) continue;
                result++;
            }
            return result;
        }
        
        private static bool IsCircularPrime(int n)
        {
            if (!IsPrime(n)) return false;
            if (n < 10) return true;
            var div = 1;
            while (n/div >= 10)
            {
                div *= 10;
            }
            var t = n;
            do
            {
                var last = t%10;
                t = last*div + t/10;
                if (!IsPrime(t))
                    return false;
            } while (t != n);
            return true;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            var n = (int) Math.Sqrt(number);
            for (var i = 2; i <= n; i++)
            {
                if (number%i == 0)
                    return false;
            }
            return true;
        }
    }

    /*
     * 
     * import java.io.*;
import java.lang.*;
 
 
class RotateNumber {   
 
 
      public static void RotateNumber(long number)
      {
            long start = number;
 
            int numdigits = (int) Math.log10((double)number); // would return numdigits - 1
            int multiplier = (int) Math.pow(10.0, (double)numdigits);
 
            //System.out.println(numdigits);
            //System.out.println(multiplier);
           
            while(true)
            {
                  long q = number / 10;
                  long r = number % 10;
 
                  //1234 = 123;
                  number = number / 10;
                  number = number + multiplier * r;
 
                  System.out.println(number);
                 
                  if(number == start)
                        break;
            }
      }
 
 
    public static void main(String[] args) {
 
            String inpstring = "";
            InputStreamReader input = new InputStreamReader(System.in);
            BufferedReader reader = new BufferedReader(input);
 
            try
            {
                  System.out.println("Enter a Number to Rotate:");
                  inpstring = reader.readLine();
                  long number = Long.parseLong(inpstring, 10);
                  RotateNumber(number);
            }
            catch (Exception e)
            {
                  e.printStackTrace();
            }
    }
}
     */
}