//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using Font = iTextSharp.text.Font;

//namespace generatorKolokwiumZZakresuTeoriiLiczb
//{
//    public class GeneratePdf
//    {
//        public GeneratePdf(List<IExercise> exercises )
//        {
//            Exercises = exercises;
//        }
//        public List<IExercise> Exercises= new List<IExercise>();
//        public static Document doc= new Document(iTextSharp.text.PageSize.A4);

//        PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf",FileMode.Create));

//        public void doPdf()
//        {

//            doc.Open();
//            doc.AddAuthor("Adam Raś");
//            doc.AddTitle("Kolokwium Teoria Liczb");

//            Paragraph paragraph = new Paragraph("Kolokwium Teoria Liczb", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 24, Font.BOLDITALIC));
//            paragraph.Alignment = Element.ALIGN_CENTER;
            

//            doc.Add(paragraph);


//            List list = new List(true, 15);
//            foreach (var ex in Exercises)
//            {
//                list.Add(ex.GetOutput());
//            }

//            doc.Add(list);
           

//            //Phrase phrase0 = new Phrase();
//            //Phrase phrase1 = new Phrase("this is a phrase");
//            //// In this example the leading is passed as a parameter
//            //Phrase phrase2 = new Phrase(16, "this is a phrase with leading 16");
//            //// When a Font is passed (explicitly or embedded in a chunk), the default leading = 1.5 * size of the font
//            //Phrase phrase3 = new Phrase("this is a phrase with a red, normal font Courier, size 12", FontFactory.GetFont(FontFactory.COURIER, 12, Font.NORMAL, BaseColor.RED));
//            //Phrase phrase4 = new Phrase(new Chunk("this is a phrase"));
//            //Phrase phrase5 = new Phrase(18, new Chunk("this is a phrase", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
//            //doc.Add(phrase0);
//            //doc.Add(phrase1);
//            //doc.Add(phrase2);
//            //doc.Add(phrase3);
//            //doc.Add(phrase4);
//            //doc.Add(phrase5);
//            doc.Close();
//        }
//    }
//}
