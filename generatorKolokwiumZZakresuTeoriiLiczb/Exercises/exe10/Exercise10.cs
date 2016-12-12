using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises.exe10
{

    //10.	Obliczyć wykorzystując Twierdzenie Eulera a następnie algorytm szybkiego potęgowania modulo.

    //Wymagania:   a^k mod n.
    //Wybieramy n tak samo jak w zad.9 n= p * p * q * r, obliczamy :   φ(n)=p*(p-1)*(q-1)*(r-1),  obliczamy k = k1 * φ(n) + (φ(n) – k2), gdzie k1>2,  2< k2<100.  Wybieramy 1<a<10.
    public class Exercise10 : IExercise
    {
        public Exercise10()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {

            P = MathService.GetPrimeNumber(5, 2);
            Q = MathService.GetPrimeNumber(23, 7);
            do
            {
                R = MathService.GetPrimeNumber(50, 11);
            } while (Q == R);
            N = P*P * Q * R;
            var argument = (P - 1) * (Q - 1) * (R - 1);
            Phi = MathService.PHI(argument);
            K1 = MathService.Stamp.Next(2, 1000);
            K2 = MathService.Stamp.Next(2, 100);
            A = MathService.Stamp.Next(1, 10);
            K = K1 * Phi + (Phi - K2);
            Result = A ^ K % N;

        }

        public int Result { get; set; }

        public int K { get; set; }

        public int A { get; set; }

        public int K2 { get; set; }

        public int K1 { get; set; }

        public int Phi { get; set; }

        public int N { get; set; }

        public int R { get; set; }

        public int Q { get; set; }

        public int P { get; set; }
        public string GetOutput()
        {
            return "Zadanie 10" + Environment.NewLine + "Phi=" + Phi + " n=" + N + " p=" + P + " q=" + Q + " r" + R +
                   " K1=" + K1 + " K2=" + K2 + " k=" + K + " wynik=" + Result;
        }
    }
}
