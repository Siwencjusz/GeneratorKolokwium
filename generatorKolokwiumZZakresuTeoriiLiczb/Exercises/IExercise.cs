using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;

namespace generatorKolokwiumZZakresuTeoriiLiczb.Exercises
{
    public interface IExercise
    {
        void ReGenerate();
        string GetOutput();
        string ExerciseName { get;}
    
        //Paragraph ExerciseText();
    }
}
