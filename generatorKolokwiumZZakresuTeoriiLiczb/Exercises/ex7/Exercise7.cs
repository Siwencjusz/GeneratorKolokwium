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
//        Odpowiedź: wypisać M = p * q * r  M1=q* r, M2 = p * r, M3 = p * q
//Stosując rozszerzony algorytm Euklidesa rozwiązujemy każdą z trzech kongruencji
// .Wypisać x1, x2, x3 a następnie x=a* x1*M1+b* x2*M2+c* x3*M3 oraz x4=x modulo M.
        private int GetXNumber(int m)
        {
            var i = 1;
            var nwd=0;
            do
            {
                i++;
                nwd=MathService.GetGreatestCommonDivisor(i, m);
            } while (nwd!=1);
            return i;
        }
        private void GetNumbers()
        {
            P = MathService.GetPrimeNumber(14);
            do
            {
                Q = MathService.GetPrimeNumber(14);
            } while (Q==P);
            do
            {
                R = MathService.GetPrimeNumber(14);
            } while (R==Q||R==P);
            A = MathService.Stamp.Next(-100, 100);
            B = MathService.Stamp.Next(-100, 100);
            C = MathService.Stamp.Next(-100, 100);
            M = P*Q*R;
            M1 = Q*R;
            M2 = P*R;
            M3 = P*Q;
            X1 = GetXNumber(M1);
            X2 = GetXNumber(M2);
            X3 = GetXNumber(M3);
            X = A*X1*M1 + B*X2*M2 + C*X3*M3;
            X4 = X%M;

        }

        public int X4 { get; set; }

        public int X { get; set; }

        public int X3 { get; set; }

        public int X2 { get; set; }

        public int X1 { get; set; }

        public int M3 { get; set; }

        public int M2 { get; set; }

        public int M1 { get; set; }

        public int M { get; set; }

        public int C { get; set; }

        public int B { get; set; }

        public int A { get; set; }

        public int R { get; set; }

        public int Q { get; set; }

        public int P { get; set; }
        public string GetOutput()
        {
            return "Zadanie 7" + Environment.NewLine + "a=" + A + " b=" + B + " c=" + C + " p=" + P + " q=" + Q + " r=" +
                   R+ Environment.NewLine
                   +"Rozwiązanie: M="+M+ " M1="+M1 + " M2="+ M2+ " M3="+ M3 + " x1="+X1+ " x2="+X2+ " x3="+X3+ " x="+X + " x4="+ X4 + Environment.NewLine;


        }

        public void ReGenerate()
        {
            GetNumbers();
        }

        public string ExerciseName
        {
            get { return "Zadanie 7"; }

        }

        public string GetXML()
        {
            var XML="\\item Rozwiązać układ kongruencji"+  Environment.NewLine+
                    "$\\left\\{ \\begin{array}{ll}"+  Environment.NewLine+
                    "x\\equiv_{"+P+"}"+A+"& \\\\"+  Environment.NewLine+
                    "x\\equiv_{"+Q+"}"+B+"& \\\\"+  Environment.NewLine+
                    "x\\equiv_{"+R+"}"+C+"& "+  Environment.NewLine+
                    "\\end{array} \\right.$"+  Environment.NewLine;
            return XML;
        }
    }
}
