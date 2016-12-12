using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex6
{
    //6.	Rozwiązać kongruencję      wykorzystując Małe Twierdzenie Fermata.
    //Wymagania:     p-liczba pierwsza <100 (najlepiej przechowywać liczby pierwsze z tego zakresu w tablicy liczb pierwszych) 
    //, -1000< a,b,c,d,e<1000 (mogą być ujemne),   n=k*(p-1)+3,   gdzie 1000<k<10000

    public class Exercise6 : IExercise
    {
        public Exercise6()
        {          
            GetNumbers();
        }

        private void GetNumbers()
        {
            P = MathService.GetPrimeNumber(100);
            A = MathService.Stamp.Next(-1000, 1000);
            B = MathService.Stamp.Next(-1000, 1000);
            C = MathService.Stamp.Next(-1000, 1000);
            D = MathService.Stamp.Next(-1000, 1000);
            E = MathService.Stamp.Next(-1000, 1000);
            K = MathService.Stamp.Next(1000, 10000);
            N = K*(P - 1) + 3;

        }
        public int N { get; set; }
        public int K { get; set; }
        public int E { get; set; }
        public int D { get; set; }
        public int C { get; set; }
        public int B { get; set; }
        public int A { get; set; }
        public int P { get; set; }
        public string GetOutput()
        {
            return "Zadanie 6" + Environment.NewLine + "a=" + A + " b=" + B + " c=" + C + " d=" + D + "e=" + E + " n=" +
                   N + " k=" + K + " p=" + P;
        }
    }
}
