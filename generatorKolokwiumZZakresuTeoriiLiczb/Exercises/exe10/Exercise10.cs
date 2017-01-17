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

            do
            {
                P = MathService.GetPrimeNumber(5, 2);
            } while (P==4);
            
            Q = MathService.GetPrimeNumber(23, 7);
            do
            {
                R = MathService.GetPrimeNumber(50, 11);
            } while (Q == R);
            N = P * P * Q * R;
            var argument = (P - 1) * (Q - 1) * (R - 1);
            Phi = MathService.PHI(N);
            //Phi = P * (Q - 1) * (Q - 1) * (R - 1);
            K1 = MathService.Stamp.Next(2, 1000);
            K2 = MathService.Stamp.Next(2, 100);
            A = MathService.Stamp.Next(1, 10);
            K = K1 * Phi + (Phi - K2);

            GetFullSolution();
            Result = StepsFourth.LastOrDefault();
        }

        private void GetFullSolution()
        {
            BinaryK= new List<string>();
            var tmpK = K;
            DecimalK.Add(tmpK);
            StepsFirst.Add(A % N);
            StepsSecond.Add(A % N);
            StepsThird.Add(K % 2 == 1 ? StepsSecond.LastOrDefault() : 1);
            BinaryK.Add(MathService.IntToString(tmpK, 2));
            tmpK = tmpK / 2;
            while (tmpK > 0)
            {
                BinaryK.Add(MathService.IntToString(tmpK, 2));
                DecimalK.Add(tmpK);
                StepsFirst.Add(Math.Pow(StepsSecond.LastOrDefault(), 2));
                StepsSecond.Add(StepsFirst.LastOrDefault() % N);
                StepsThird.Add(tmpK % 2 == 1 ? StepsSecond.LastOrDefault() : 1);

                tmpK = tmpK / 2;
                if (tmpK==0)
                {
                    tmpK = -10;
                    break;
                }
            };
            StepsFourth.Add((StepsThird[0] * StepsThird[1]) % N);
            for (int i = 2; i < StepsThird.Count-1; i++)
            {
                StepsFourth.Add((StepsFourth.LastOrDefault() * StepsThird[i]) % N);
            }
        }
        List<int> DecimalK = new List<int>();
        List<string> BinaryK = new List<string>();
        List<double> StepsFirst = new List<double>();
        List<double> StepsSecond = new List<double>();
        List<double> StepsThird = new List<double>();
        List<double> StepsFourth = new List<double>();
        public double Result { get; set; }

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
            var solution = "Zadanie 10" + Environment.NewLine + "Phi=" + Phi + " n=" + N + " p=" + P + " q=" + Q + " r" + R +
                   " K1=" + K1 + " K2=" + K2 + " K=" + K + " wynik=" + Result;
            foreach (var k in BinaryK)
            {
                solution += Environment.NewLine + " binary K=" + k + " kolumna F=" + StepsSecond[BinaryK.IndexOf(k)];
            }
            solution += Environment.NewLine + " wynik=" + Result;
            return solution;
        }

        public void ReGenerate()
        {
            GetNumbers();
        }
        public string ExerciseName
        {
            get { return "Zadanie 10"; }

        }

        public string GetXML()
        {
            var XML="\\item Obliczyć $"+A+"^{"+K+"}mod"+N+"$ wykorzystując Twierdzenie Eulera a następnie algorytm szybkiego potęgowania modulo.";
            return XML;
        }
    }
}