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
            P = MathService.GetPrimeNumber(14);
            A = MathService.Stamp.Next(-1000, 1000);
            B = MathService.Stamp.Next(-1000, 1000);
            C = MathService.Stamp.Next(-1000, 1000);
            D = MathService.Stamp.Next(-1000, 1000);
            E = MathService.Stamp.Next(-1000, 1000);
            K = MathService.Stamp.Next(1000, 10000);
            N = K*(P - 1) + 3;


           // Odpowiedź: wypisać d1 = d mod p oraz e1 = e mod p. 
           //Następnie w wyrażeniu podstawiać w miejsce x kolejne liczby od 1 do p - 1 i wypisać otrzymaną wartość w oraz w1 = w mod p.
           //Jeżeli w1 = e1 to x jest rozwiązaniem, w pp nie jest rozwiązaniem.

            d1 = D%P;
            e1 = E%P;
            for (int i = 1; i < P; i++)
            {
                var w = Math.Pow((A + 1)*i, 3) + Math.Pow(B*i, 2) + C*i + D;
                var w1 = w%P;
                var row = "W=" + w + " W1=" + w1;
                if (w1==e1)
                {
                    row = row + " x=" + i + " jest rozwiązaniem";
                }
                else
                {
                    row= row + " x=" + i + " nie jest rozwiązaniem";
                }
                wList.Add(row);
            }
        }

        public int e1 { get; set; }
        private List<string> wList= new List<string>();
        public int d1 { get; set; }

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
            var solution = "Zadanie 6" + Environment.NewLine + "a=" + A + " b=" + B + " c=" + C + " d=" + D + "e=" + E +
                           " n=" +
                           N + " k=" + K + " p=" + P ;
            foreach (var w in wList)
            {
                solution=solution + Environment.NewLine + w;
            }
            return solution;
        }

        public void ReGenerate()
        {
            GetNumbers();
        }
        public string ExerciseName
        {
            get { return "Zadanie 6"; }

        }
    }
}
