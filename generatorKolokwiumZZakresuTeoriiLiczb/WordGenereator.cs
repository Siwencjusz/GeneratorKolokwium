using Novacode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace generatorKolokwiumZZakresuTeoriiLiczb
{
    public class WordGenereator
    {
        public WordGenereator(string path, List<IExercise> exercises)
        {
            Path = path;
            Exercises = exercises;
        }

        public string Path { get; set; }
        public List<IExercise> Exercises { get; set; }

        public void CreateDoc()
        {

            string fileName = Path + "\\Kolokwium Rozwiązania.docx";
            string headlineText = "Kolokwium Teoria Liczb Rozwiązania";
            string paraOne = "";

            // A formatting object for our headline:
            //var headLineFormat = new Formatting();
            //headLineFormat.FontFamily = new FontFamily("Times New Roman");
            //headLineFormat.Size = 24D;
            //headLineFormat.Position = 12;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;

            // Create the document in memory:
            var doc = DocX.Create(fileName);
            Paragraph title =
                doc.InsertParagraph().Append(headlineText).FontSize(20).Font(new FontFamily("Times New Roman"));
            title.Alignment = Alignment.center;
            // Insert the now text obejcts;


            doc.InsertParagraph(paraOne, false, paraFormat);

            foreach (var exercise in Exercises)
            {
                var text = exercise.GetOutput();
                doc.InsertParagraph(text, false, paraFormat);
            }

            // Save to the output directory:

            try
            {
                doc.Save();
                Process.Start("Explorer.EXE", Path);
            }
            catch (Exception)
            {

                MessageBox.Show("Proszę zamknąć plik Word", "Błąd zapisu",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            // Open in Word:
            

            ////////////////////////////////////////////////////
            
            
             /////////////////
            //var doc = DocX.Create(fileName);
            //doc.Save();
            //Word._Application myApp = new Word.Application();
            //myApp.Visible = true;

            //Word.Document myDoc = myApp.Documents.Open(fileName);

            ////The below code add a wdOMathFunctionBox to the document opened.
            //Word.Range myFunctionR = myApp.Selection.OMaths.Add(myApp.Selection.Range);
            //Word.OMathFunction myFunction = myApp.Selection.OMaths[1].Functions.Add(
            //    myApp.Selection.Range, Word.WdOMathFunctionType.wdOMathFunctionBox);
            //Word.OMathBox myBox = myFunction.Box;

            ////Since OMathBox.E property returns an OMath object that represents the base
            ////of the specified equation object. You can then refer to OMath members' page
            ////to see what methods and properties can be used. The below show how to assign
            ////a string to the range of myBox.
            //myBox.E.Range.Text = "Hello World!";
           







        }
    }
}
