using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Zadania
{
    public class EquasionData
    {
        public int a = 0;
        public int b = 0;
        public int c = 0;
        public int x = 0;
        public int y = 0;


        public bool IsHasSolution;
        public int d;
        public int a1;
        public int b1;
        public int c1;
        public int a2;
        public int c2;
        public int x2;

        public EquasionData(List<int> initialData)
        {
            a = initialData.FirstOrDefault();
            b = initialData.LastOrDefault();
            d = MathService.GetGreatestCommonDivisor(a, b);
        }

        public void InsertXYC(List<int> foundedData)
        {
            x = foundedData.FirstOrDefault();
            y = foundedData.ElementAt(1);
            c = foundedData.LastOrDefault();
            a1 = a / d;
            b1 = b / d;
            c1 = c / d;
            a2 = a%b;
            c2 = c%b;
            x2 = x%b;
        }
    }
}
