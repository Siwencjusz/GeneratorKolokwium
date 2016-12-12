using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex1
{
    public class Exercise1:IExercise
    {
        public Exercise1()
        {
            GetNumbers();
        }
        public int DataA { get; set; }
        public int P { get; set; }
        public int Q { get; set; }
        public int Y { get; set; }
        public int DataBDivior { get; set; }
        public string Number { get; set; }
        public bool IsDividable { get; set; }
        private void GetNumbers()
        {
            bool random = MathService.Stamp.Next(0, 2) != 0;
            GetPartA(random);
            GetPartB(random);
            GetPartC();
            GetPartD();

        }

        public string GetOutput()
        {
            return "Zadanie 1"+ Environment.NewLine+ 
                "A) " + DataA + " B) p=" + P + " x=" + DataBDivior + "C) q="+Q+" y="+Y +" D) "+ Number + "Czy podzielna przez x" + IsDividable.ToString();
        }
        

        private void GetPartA(bool random)
        {
            DataA = random ? 9 : 11;
        }
        private void GetPartB(bool random)
        {
            var counter = 0;
            P = MathService.Stamp.Next(11, 20);
            var max = P / 2 + 1;
            if (random)
            {
                var rest = 0;
                do
                {
                    if (counter==10)
                    {
                        break;
                    }
                    DataBDivior = MathService.Stamp.Next(3, max);
                    rest = DataBDivior - 1;
                    counter++;
                } while (P % DataBDivior != rest);
            }
            else
            {
                do
                {
                    if (counter==10)
                    {
                        break;
                    }
                    DataBDivior = MathService.Stamp.Next(3, max);
                    counter++;
                } while (P % DataBDivior != 1);
            }
            if (counter==10)
            {
                GetPartB(random);
            }
        }
        private void GetPartC()
        {
            do
            {
                Q = MathService.Stamp.Next(11, 20);
            } while (Q==P);
            var counter = 0;
            do
            {
                if (counter==10)
                {
                    break;
                }
                Y = MathService.Stamp.Next(3, Q);
                counter++;
            } while (Y==2 || Y ==Q || Q%Y!=0);
            if (counter==10)
            {
                GetPartC();
            }
            
        }
        private void GetPartD()
        {
            var numberLength = MathService.Stamp.Next(6, 9);
            for (int i = 0; i < numberLength; i++)
            {
                var index = MathService.Stamp.Next(0, P + 1);
                Number = Number += MathService.BaseNumbers[index];
            }
            IsDividable = MathService.StringToDecimalValue(Number, P)%DataBDivior==0;
        }

        
    }
}
