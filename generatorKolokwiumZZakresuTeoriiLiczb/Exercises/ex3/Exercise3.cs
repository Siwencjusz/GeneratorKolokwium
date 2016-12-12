using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Zadania
{
    public class Exercise3 : IExercise
    {
        public Exercise3()
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
        public string GetOutput()
        {

            return "Zadanie 3" + Environment.NewLine + "A) a=" + PartA.a + " b=" + PartA.b + " c=" + PartA.c + "x=" +
                   PartA.x + " y=" + PartA.y + Environment.NewLine +
                   "B)  a=" + PartB.a + " b=" + PartB.b + " c=" + PartB.c + "x=" + PartB.x + " y=" + PartB.y;
        }
        public static string ExerciseText = "Rozwiązać w liczbach całkowitych równania liniowe";
        public EquasionData PartA;
        public EquasionData PartB;
        Random stamp = new Random();
        private List<int> FindAAndB()
        {
            int a;
            int b;
            int divisor = 0;
            
            do
            {
                a = stamp.Next(2, 100);
                b = stamp.Next(2, 100);
                divisor = MathService.GetGreatestCommonDivisor(a, b);
            } while (divisor <= 1);
            return new List<int>() {a,b};
        }
        private List<int> FindXYC(int changeC, EquasionData data)
        {
            int x, y, c;
            Random stamp = new Random();
            do
            {
                x = stamp.Next(2, 10);
                y = stamp.Next(2, 10);
                c = data.a * x + data.b * y+changeC;
            } while (c > 1000);
            return  new List<int>() {x,y,c};
        }


    }
}
