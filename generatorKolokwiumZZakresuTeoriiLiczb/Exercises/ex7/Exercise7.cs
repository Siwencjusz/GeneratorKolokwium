using System;
using System.Security.AccessControl;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex7
{
    
    //Wymagania:    1<p,q,r<20- parami różne liczby pierwsze ,  -100<a,b,c <100 (mogą być ujemne)
    //nieskończone
    public class Exercise7 : IExercise
    {
        public Exercise7()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            P = MathService.GetPrimeNumber(20);
            do
            {
                Q = MathService.GetPrimeNumber(20);
            } while (Q==P);
            do
            {
                R = MathService.GetPrimeNumber(20);
            } while (R==Q||R==P);
            A = MathService.Stamp.Next(-100, 100);
            B = MathService.Stamp.Next(-100, 100);
            C = MathService.Stamp.Next(-100, 100);
        }

        public int C { get; set; }

        public int B { get; set; }

        public int A { get; set; }

        public int R { get; set; }

        public int Q { get; set; }

        public int P { get; set; }
        public string GetOutput()
        {
            return "Zadanie 7" + Environment.NewLine + "a=" + A + " b=" + B + " c=" + C + " p=" + P + " q=" + Q + " r=" +
                   R;
        }
    }
}
