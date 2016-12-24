using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Zadania.ex4
{
    public class Exercise4 : IExercise
    {
        public Exercise4()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            PartA = new EquasionData(FindAAndB());
            PartA.InsertXYC(FindXYC(0, PartA));
            PartA.IsHasSolution = true;
            PartB = new EquasionData(FindAAndB());
            PartB.InsertXYC(FindXYC(1, PartB));
        }

        public static string ExerciseText = "Rozwiązać kongruencje liniowe";
        //Wymagania:     0<a,b,c<1000
        public EquasionData PartA;
        public EquasionData PartB;
        private List<int> FindAAndB()
        {
            int a;
            int b;
            int divisor = 0;
            
            do
            {
                a = MathService.Stamp.Next(2, 100);
                b = MathService.Stamp.Next(2, 20);
                divisor = MathService.GetGreatestCommonDivisor(a, b);
            } while (divisor <= 1);
            return new List<int>() { a, b };
        }
        private List<int> FindXYC(int changeC, EquasionData data)
        {
            int x, y, c;
            Random stamp = new Random();
            do
            {
                x = stamp.Next(2, data.b);
                y = stamp.Next(2, 10);
                c = data.a * x + data.b * y+changeC;
            } while (c > 1000);
            return new List<int>() { x, y, c };
        }

        public string GetOutput()
        {
            return "Zadanie 4 " + Environment.NewLine + "A) a=" + PartA.a + " b=" + PartA.b + " c=" + PartA.c + " x=" +
                   PartA.x + " y=" + PartA.y + " a1=" + PartA.a1 + " b1=" + PartA.b1 + " c1=" + PartA.c1 +
                   " d=NWD(a,b)=" + PartA.d + " a2=" + PartA.a2 + " c2=" + PartA.c2 + " x2=" + PartA.x2+


                   Environment.NewLine +
                   "B)  a=" + PartB.a + " b=" + PartB.b + " c=" + PartB.c + "x=" + PartB.x + " y=" + PartB.y + " a2=" + PartB.a2 + " c2="+ PartB.c2+" brak rozwiązania";
        }
    }
}
//Odpowiedź: a) d=NWD(a, b), a1=a/d, b1=b/d, c1=c/d, x, y oraz
// a2=a mod b, c2=c mod b, x2=x mod b
//b) brak rozwiązania oraz a2 = a mod b, c2 = c mod b
