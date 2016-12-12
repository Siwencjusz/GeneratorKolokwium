using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Zadania
{
    //     20>p>10  , x1- zapis dziesiętny liczby x oraz p^2<x1<p^3
    //6> q>2    , y1- zapis dziesiętny liczby y oraz q^4<y1<q^5
    //Ponadto, NWD(x1,y1)>1 oraz niech z będzie iloczynem trzech liczb z zakresu od 2 do 10.
    //x – liczba x1 w systemie p, y –  w systemie q

    public class Exercise2 : IExercise
    {
        public Exercise2()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            GetX();
            GetY();
            Z = MathService.Stamp.Next(10, 100);
            LCM = MathService.FindLeastCommonMultpile(X1, X1);
        }

        

        private void GetY()
        {
            bool divisorLength;
            bool divisorCondition;
            var counter = 0;
            do
            {
                if (counter==20)
                {
                    break;
                }
                Q = MathService.Stamp.Next(3, 6);
                var min = Convert.ToInt32(Math.Pow(Q, 4));
                var max = Convert.ToInt32(Math.Pow(Q, 5));
                Y1 = MathService.Stamp.Next(min, max);
                Y = MathService.IntToString(Y1, Q);
                GCD = MathService.GetGreatestCommonDivisor(X1, Y1);
                divisorCondition = GCD != 1;
                divisorLength = MathService.IsNumberHas3Divisors(Y1,3);
                counter++;
            } while (!(divisorCondition && divisorLength));
            if (counter==20)
            {
                GetY();
            }
        }

        private void GetX()
        {
            P = MathService.Stamp.Next(10, 20);
            var max = Convert.ToInt32(Math.Pow(P, 3));
            var min = Convert.ToInt32(Math.Pow(P, 2));
            X1 = MathService.Stamp.Next(min, max);
            X = MathService.IntToString(X1, P);
        }

        public string Y { get; set; }

        public int Y1 { get; set; }

        public int Q { get; set; }

        public string X { get; set; }

        public int X1 { get; set; }

        public int P { get; set; }

        public int GCD { get; set; }
        public int Z { get; set; }
        public int LCM { get; set; }

        public string GetOutput()
        {
            return "Zadanie 2 " + Environment.NewLine+
            "P=" + P + " x1=" + X1 + "x w sytemie P " + X + " q=" + Q + " y1=" + Y1 + "y w sytemie P " + Y +
                   "Największy współny dzielnik=" + GCD + " Najmniejszy wspólns wielokrotność=" + LCM;
        }
    }
}
