using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Zadania
{
    public class ExerciseNumber1
    {
        public ExerciseNumber1()
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            int baseSys = new Random().Next(10, 15);
            string baseString = MathService.BaseNumbers.Substring(0, baseSys);
            CreateBasedSystem(baseString);
            GenerateBaseNumber();
            //to Delete
            GenerateNumbersInDecimal(4);
            CheckNumber();
           
           
            
        }

        public int A { get; set; }


        public static List<string> BaseNumbersList= new List<string>();
        public static List<string> BaseString = new List<string>();
        private static int BaseInDecimal { get; set; }
        private string exerciseText = "Sformułować i udowodnić cechę podzielności przez  a) ";
        private string exerciseText2 = "b)";
        private string exerciseText3 = "w systemie dziesiątkowym";
        private string exerciseText4 = "c)";
        private string exerciseText5 = "w systemie szesnastkowym";
        private string exerciseText6 = "d)";
        private string exerciseText7 = "systemie siódemkowym";
        private string exerciseText8 = "e)sprawdzić, czy  liczba ";
        private string exerciseText9 = "jest podzielna przez ";
        public bool IsNumberDivisble { get; set; }
        /// <summary>
        /// list of numbers to exercises
        /// </summary>
        public List<int> DivisibilityRules = new  List<int>();

        /// <summary>
        /// Generating number in 17 base
        /// </summary>
        /// <param name="systemNumbers"></param>
        private void CreateBasedSystem(string systemNumbers)
        {
            var sys = systemNumbers.ToList();
            foreach (var number in sys )
            {
                BaseNumbersList.Add(number.ToString());
            }
        }

        private static void GenerateBaseNumber()
        {
            int random;
            while (BaseString.Count != 10)
            {
                random= MathService.Stamp.Next(0,BaseNumbersList.Count);
                BaseString.Add(BaseNumbersList[random]);

            }
            for (int i = 0; i < 10; i++)
            {
                var valueInDecimal = BaseNumbersList.IndexOf(BaseString[i]);
                BaseInDecimal += valueInDecimal * BaseNumbersList.Count() ^ (10 - i);
            }
        }
        /// <summary>
        /// Generating numbers to exercises
        /// </summary>
        /// <param name="howMany"></param>
        /// 
        /// to Delte
        private void GenerateNumbersInDecimal(int howMany)
        {
            int random = 0;
            while (DivisibilityRules.Count != howMany)
            {
                random = MathService.Stamp.Next(2,10);
                if (!DivisibilityRules.Any(x => x == random))
                    DivisibilityRules.Add(random);
            }
            bool isNumberOk = false;
            while (!isNumberOk)
            {
                random = MathService.Stamp.Next(2, BaseNumbersList.Count);
                if (DivisibilityRules.All(x => x != random))
                {
                    DivisibilityRules[3] = random;
                    isNumberOk = true;
                }
            }
        }

        /// <summary>
        /// check if number is divisible
        /// </summary>
        private void CheckNumber()
        {
            IsNumberDivisble = BaseInDecimal/DivisibilityRules.LastOrDefault()==0;
        }
        /* toDo List:
            make rules of divisbility in systems;
        */
    }
}
