using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Zadania
{
    public class EquasionData
    {
        public int a = 0;
        public int b = 0;
        public int c = 0;
        public int x = 0;
        public int y = 0;

        public EquasionData(List<int> initialData)
        {
            a = initialData.FirstOrDefault();
            b = initialData.LastOrDefault();
        }

        public void InsertXYC(List<int> foundedData)
        {
            x = foundedData.FirstOrDefault();
            y = foundedData.ElementAt(1);
            c = foundedData.LastOrDefault();
        }
    }
}
