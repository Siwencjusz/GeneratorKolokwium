using System;
using System.Collections.Generic;
using System.Linq;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises
{
    public static class MathService
    {
        public static Random Stamp = new Random();
        public static string BaseNumbers = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static char[] baseNumbers = BaseNumbers.ToCharArray();
        public static string IntToString(int value, int sysBase)
        {
            char[] baseChars = baseNumbers.Take(sysBase).ToArray();
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                
                if (value>0)
                {
                    var index = value % targetBase;
                    var toAdd = baseChars[index].ToString();
                    result = toAdd + result;
                    value = value / targetBase;
                }
            }
            while (value > 0);

            return result;
        }

        public static int ConvertToInt(int number, int fromBase)
        {
           
            double result = 0;
            int digitIndex = 0;

            while (number > 0)
            {
                result += (number % 10) * Math.Pow(fromBase, digitIndex);

                digitIndex++;
                number /= 10;
            }

            return Convert.ToInt32(result);
        }

        public static int GetGreatestCommonDivisor(int a, int b)
        {
            while (a != b)
                if (a > b)
                    a -= b; //or a = a - b;
                else
                    b -= a; //or b = b-a
            return a; // or b - both are equal NWD(a,b)
        }

        public static int GetPrimeNumber(int max, int min=0)
        {
            
            var primeList= new List<int>();
            for (int i = 2; i <= max; i++)
            {
                for (int a = 2; a <= i / 2; a++)
                {
                    bool notEqal = a != i/2;
                    bool rest = i%a == 0;
                    if (notEqal & rest)
                    {
                        a=i+1;    
                    }
                    if (a==i/2)
                    {
                        primeList.Add(i);
                    }

                }
            }
            int result;
            do
            {
                var indexToReturn = Stamp.Next(0, primeList.Count);
                result = primeList[indexToReturn];
            } while (result<min);
           

            return result;

        }

        // A simple method to evaluate Euler Totient Function
        public static int PHI(int n)
        {
            int result = n;   // Initialize result as n

            // Consider all prime factors of n and subtract their
            // multiples from result
            for (int p = 2; p * p <= n; ++p)
            {
                // Check if p is a prime factor.
                if (n % p == 0)
                {
                    // If yes, then update n and result 
                    while (n % p == 0)
                        n /= p;
                    result -= result / p;
                }
            }

            // If n has a prime factor greater than sqrt(n)
            // (There can be at-most one such prime factor)
            if (n > 1)
                result -= result / n;
            return result;
        }

        public static int StringToDecimalValue(string number, int numberBase)
        {
            var array = number.ToCharArray();
            int power = 0;
            int result=0;
            for (int i = array.Length; i >0 ; i--)
            {
                int parsedNumber = baseNumbers.ToList().IndexOf(array[i-1]);
                result += parsedNumber*Convert.ToInt32(Math.Pow(numberBase, power));
                power += 1;
            }
            return result;
        }

        public static bool IsNumberHas3Divisors(int number, int numberOfDivisors)
        {
            List<int> listofDivisors=new List<int>();
            do
            {
                var listLength = listofDivisors.Count;
                if (listLength== numberOfDivisors)
                {
                    return true;
                }
                for (int i = 2; i < 10; i++)
                {
                    if (number%i==0)
                    {
                        number = number/i;
                        if (!listofDivisors.Contains(i))
                        {
                            listofDivisors.Add(i);
                        }
                    }
                }
                if (listLength==listofDivisors.Count)
                {
                    return false;
                }
            } while (number>=1);
            return false;
        }
        public static int FindLeastCommonMultpile(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }

        public static int GetNumberSumInDecimal(string number,int numberBase)
        {
            var numberArray = number.ToCharArray();
            var result = 0;

            foreach (var letter in numberArray)
            {
                result += MathService.StringToDecimalValue(letter.ToString(), numberBase);
            }
            

            return result;
        }
    }
}
