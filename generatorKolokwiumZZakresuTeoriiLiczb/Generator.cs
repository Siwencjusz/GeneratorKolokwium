using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex1;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex6;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex7;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex8;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex9;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.exe10;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania.ex4;

namespace generatorKolokwiumZZakresuTeoriiLiczb
{
    public partial class Generator : Form
    {
        public Generator()
        {
            InitializeComponent();
        }

        private void Generator_Load(object sender, EventArgs e)
        {

            Exercise1 ex1 = new Exercise1();
            Exercise2 ex2 = new Exercise2();
            Exercise3 ex3 = new Exercise3();
            Exercise4 ex4 = new Exercise4();

            Exercise5 ex5 = new Exercise5();
            Exercise6 ex6 = new Exercise6();
            Exercise7 ex7 = new Exercise7();
            Exercise8 ex8 = new Exercise8();
            Exercise9 ex9 = new Exercise9();
            Exercise10 ex10 = new Exercise10();

            var data = string.Empty;
            data += ex1.GetOutput() + Environment.NewLine;
            data += ex2.GetOutput() + Environment.NewLine;
            data += ex3.GetOutput() + Environment.NewLine;
            data += ex4.GetOutput() + Environment.NewLine;
            data += ex5.GetOutput() + Environment.NewLine;
            data += ex6.GetOutput() + Environment.NewLine;
            data += ex7.GetOutput() + Environment.NewLine;
            data += ex8.GetOutput() + Environment.NewLine;
            data += ex9.GetOutput() + Environment.NewLine;
            data += ex10.GetOutput() + Environment.NewLine;
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "EgzaminZadania.txt", data
                );
            Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + @"\" + "EgzaminZadania.txt");
        }
    }
}
