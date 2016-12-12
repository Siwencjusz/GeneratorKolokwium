using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises
{
    public class Exercise5 : IExercise
    {
        public Exercise5()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            int a, b, divisor;
            do
            {
                b = MathService.Stamp.Next(50, 1000);
                a = MathService.Stamp.Next(50, b);
                divisor = MathService.GetGreatestCommonDivisor(a, b);
            } while (divisor != 1);
            var data = new List<int>() { a, b };
            A = data.FirstOrDefault();
            B = data.LastOrDefault();
            X = 0;
            var counter = 0;
            do
            {
                if (counter==10)
                {
                    break;
                }
                X = MathService.Stamp.Next(B/8-1, B/2);
                Modulo = A*X%B;
                counter++;
            } while (Modulo!=1);
            if (counter==10)
            {
                GetNumbers();
            }
        }

        public int X { get; set; }


        public int B { get; private set; }

        public int A { get; private set; }
        public int Modulo { get; private set; }


        public string GetOutput()
        {
            return "Zadanie 5" + Environment.NewLine + "a=" + A + " b=" + B + " x=" + X;
        }
    }
}
