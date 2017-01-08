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

        private bool option = false;
        private void GetNumbers()
        {
            GetX();
            option = 50<MathService.Stamp.Next(0, 100);
            if (option)
            {
                GetY();

                Z = MathService.Stamp.Next(10, 100);
                LCM = MathService.FindLeastCommonMultpile(X1, Y1);
            }
            else
            {
                GetY1();
                Z = MathService.Stamp.Next(10, 100);
                GCD = MathService.GetGreatestCommonDivisor(X1, Y1);
            }
        }
        public string ExerciseName
        {
            get { return "Zadanie 2"; }

        }
        private void GetY1()
        {
            bool divisorLength;
            bool divisorCondition;
            var counter = 0;
            do
            {
                if (counter == 20)
                {
                    break;
                }
                Q = MathService.Stamp.Next(3, 6);
                var min = Convert.ToInt32(Math.Pow(Q, 4));
                var max = Convert.ToInt32(Math.Pow(Q, 5));
                Y1 = MathService.Stamp.Next(min, max);
                Y = MathService.IntToString(Y1, Q);
                LCM = MathService.FindLeastCommonMultpile(X1, Y1);
                divisorCondition = LCM != 1;
                divisorLength = MathService.IsNumberHasXDivisors(Y1, 3);
                counter++;
            } while (!(divisorCondition && divisorLength));
            if (counter == 20)
            {
                GetY1();
            }
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
                divisorLength = MathService.IsNumberHasXDivisors(Y1,3);
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
            string optionText;
            if (option)
            {
                optionText = "NWW(NWD";
            }
            else
            {
                optionText = "NWD(NWW";
            }
            return "Zadanie 2  option="+ option + Environment.NewLine+
            "P=" + P + " x1=" + X1 + " x w systemie P x=" + X + " q=" + Q + " y1=" + Y1 + " w systemie P  y=" + Y +
                   " największy wspólny dzielnik x1 i y1=" + GCD + " najmniejsza wspólna wielokrotność x1 i y1=" + LCM;
        }

        public void ReGenerate()
        {
            GetNumbers();
        }
    }
}
