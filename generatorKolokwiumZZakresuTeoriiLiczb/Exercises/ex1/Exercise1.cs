using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;

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
        public int DataDNumberSum { get; set; }
        public bool IsDividable { get; set; }

        public string ExerciseName
        {
            get { return "Zadanie 1"; }

        }

        private void GetNumbers()
        {
            bool random = MathService.Stamp.Next(0, 2) != 0;
            GetPartA(random);
            GetPartB(random);
            GetPartC();
            GetPartD();

        }
        private void GetPartA(bool random)
        {
            DataA = random ? 9 : 11;
        }
        private void GetPartB(bool random)
        {
            var counter = 0;
            P = MathService.Stamp.Next(11, 20);
            var max = P / 2;
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
                if (i==0)
                {
                    index= MathService.Stamp.Next(1, P + 1);
                }
                Number = Number += MathService.BaseNumbers[index];
            }
            DataDNumberSum = MathService.GetNumberSumInDecimal(Number, P);
            //var decimalValue = MathService.StringToDecimalValue(Number, P);
            IsDividable = DataDNumberSum % DataBDivior == 0;
            //IsDividable = decimalValue % DataBDivior==0;
        }

        public string GetOutput()
        {
            string isdividable;
            isdividable = IsDividable ? "Tak" : "Nie";
            return "Zadanie 1" + Environment.NewLine +
                "A) " + DataA + Environment.NewLine +
                " B) p=" + P + " x=" + DataBDivior + Environment.NewLine +
                " C) q=" + Q + " y=" + Y + Environment.NewLine +
                " D)  Czy w systemie P=" + P+ " Liczba " + Number + " jest podzielna przez x=" + DataBDivior + Environment.NewLine+ " Czy podzielna: " + isdividable + Environment.NewLine + " suma cyfr: " + DataDNumberSum+ Environment.NewLine;
        }

        public string GetXML()
        {
            var XML = "\\item Sformułować i udowodnić cechę podzielności przez" + Environment.NewLine +
                      "\\begin{ enumerate} " + Environment.NewLine +
                      "\\item[a)] " + DataA +" w systemie dziesiątkowym " + Environment.NewLine +
                      "\\item[b)]4 w systemie siedemnastkowym " + Environment.NewLine +
                      "\\item[c)]8 w systemie szesnastkowym" + Environment.NewLine +
                      "\\item[d)]sprawdzić, czy liczba $DA954AC02DB75B_{ 17}$ jest podzielna przez 4" +Environment.NewLine +
                      "\\end{ enumerate}" + Environment.NewLine;
            return XML;
        }
        public void ReGenerate()
        {
            bool random = MathService.Stamp.Next(0, 2) != 0;
            GetPartA(random);
            GetPartB(random);
            GetPartC();
            GetPartD();
        }
        //public Paragraph ExerciseText()
        //{
        //    string paraOne = "";
        //    var paraFormat = new Formatting();
        //    paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
        //    paraFormat.Size = 12D;
        //    return new Paragraph(paraOne,);
        //}
    }
}
