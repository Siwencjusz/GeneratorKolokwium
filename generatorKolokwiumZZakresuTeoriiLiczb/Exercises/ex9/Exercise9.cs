using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex9
{
    //gdzie p jest jedną z liczb pierwszych: 2,3,5;  q jest jedną z liczb pierwszych od 7 do 23,   
    //r jest jedną z liczb pierwszych od 11 do 50 (najlepiej odwołać się do tablicy liczb pierwszych )   
    public class Exercise9 : IExercise
    {
        public Exercise9()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            P = MathService.GetPrimeNumber(5, 2);
            Q = MathService.GetPrimeNumber(13, 7);
            do
            {
                R = MathService.GetPrimeNumber(50, 17);
            } while (R == Q);
            N =P* P * Q * R;
            Phi = MathService.PHI(N);
        }

        public int Phi { get; set; }

        public int N { get; set; }

        public int P { get; set; }

        public int Q { get; set; }

        public int R { get; set; }
        public string GetOutput()
        {
            return "Zadanie 9" + Environment.NewLine +"phi="+Phi+ " n=" + N + " p=" + P + " q=" + Q + " r=" + R;
        }
    }
}
