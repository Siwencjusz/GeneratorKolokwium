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
            return "Zadanie 4 A) "+ Environment.NewLine + "A) a=" + PartA.a + " b=" + PartA.b + " c=" + PartA.c + "x=" +
                   PartA.x + " y=" + PartA.y + Environment.NewLine +
                   "B)  a=" + PartB.a + " b=" + PartB.b + " c=" + PartB.c + "x=" + PartB.x + " y=" + PartB.y;
        }
    }
}
