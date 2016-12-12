using System;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex8
{

    //Wymagania:     a,b,c,d,e,f <20 (mogą być ujemne), 10<n<40, k=ad-bc, 
    //oraz k1-reszta z dzielenia k przez n(jeśli wychodzi ujemna to dodać n),  musi być NWD(k1, n)=1.

    public class Exercise8 : IExercise
    {
        public Exercise8()
        {
            GetNumbers();
        }
        private void GetNumbers()
        {
            A = MathService.Stamp.Next(-20, 20);
            B = MathService.Stamp.Next(-20, 20);
            C = MathService.Stamp.Next(-20, 20);
            D = MathService.Stamp.Next(-20, 20);
            K = A * D - B * C;
            N = MathService.Stamp.Next(10, 40);
            E = MathService.Stamp.Next(-20, 20);
            F = MathService.Stamp.Next(-20, 20);
            K1 = K % N;

            if (K1 < 0)
            {
                K1 += N;
            }
            bool checkLCD = MathService.GetGreatestCommonDivisor(K1, N) != 1;
            if (checkLCD)
            {
                GetNumbers();
            }


        }



        public int K1 { get; set; }

        public int N { get; set; }
        public int F { get; set; }
        public int K { get; set; }
        public int E { get; set; }
        public int D { get; set; }
        public int C { get; set; }
        public int B { get; set; }
        public int A { get; set; }
        public string GetOutput()
        {
            return "Zadanie 8" + Environment.NewLine + " a=" + A+ " b="+ B+ " c="+C+ " d"+ D+ " e"+ E + " f"+ F+ " k="+ K+ " n="+N+ " k1-"+ K1;
        }
    }
}
