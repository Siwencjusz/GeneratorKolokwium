using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex1;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex6;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex7;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex8;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.ex9;
using generatorKolokwiumZZakresuTeoriiLiczb.Exercises.exe10;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania;
using generatorKolokwiumZZakresuTeoriiLiczb.Zadania.ex4;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;

namespace generatorKolokwiumZZakresuTeoriiLiczb
{
    public partial class Generator : Form
    {

        public List<string> SelectedItems = new List<string>();

        public Generator()
        {
            InitializeComponent();
        }

        public string path { get; set; }
        public List<IExercise> ExercisesToPrint { get; set; }
        public List<IExercise> Exercises { get; set; }

        private void Generator_Load(object sender, EventArgs e)
        {
            Generate.Enabled = false;
            Exercises = new List<IExercise>();
            ExercisesToPrint = new List<IExercise>();
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
            //
            Exercises.Add(ex1);
            Exercises.Add(ex2);
            Exercises.Add(ex3);
            Exercises.Add(ex4);
            Exercises.Add(ex5);
            Exercises.Add(ex6);
            Exercises.Add(ex7);
            Exercises.Add(ex8);
            Exercises.Add(ex9);
            Exercises.Add(ex10);
            //
            foreach (var exercise in Exercises)
            {
                ExercisesList.Items.Add(exercise.ExerciseName);
            }



            //var data = string.Empty;
            //data += ex1.GetOutput() + Environment.NewLine;
            //data += ex2.GetOutput() + Environment.NewLine;
            //data += ex3.GetOutput() + Environment.NewLine;
            //data += ex4.GetOutput() + Environment.NewLine;
            //data += ex5.GetOutput() + Environment.NewLine;
            //data += ex6.GetOutput() + Environment.NewLine;
            //data += ex7.GetOutput() + Environment.NewLine;
            //data += ex8.GetOutput() + Environment.NewLine;
            //data += ex9.GetOutput() + Environment.NewLine;
            //data += ex10.GetOutput() + Environment.NewLine;
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "EgzaminZadania.txt", data
            //    );
            //Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + @"\" + "EgzaminZadania.txt");

            path = AppDomain.CurrentDomain.BaseDirectory;

            //GeneratePdf pdf = new GeneratePdf(ExercisesToPrint);
            //pdf.doPdf();
            //Process.Start("explorer.exe", path);

        }


        private async void Generate_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Wybierz miejsce do zapisania plików", "Lokalicacja plików");
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                System.Windows.Forms.MessageBox.Show(
                    "Pliki zostaną zapisane tutaj " + fbd.SelectedPath + " pod nazwa Kolokwium rozwiązania",
                    "Lokalizacja plików");

            }
            ExercisesToPrint = new List<IExercise>();
            object[] lengthList = new object[ExercisesList.CheckedItems.Count];
            ExercisesList.CheckedItems.CopyTo(lengthList, 0);

            for (int i = 0; i < lengthList.Length; i++)
            {
                var index = ExercisesList.Items.IndexOf(lengthList[i]);
                if (ExercisesToPrint.All(x => x != Exercises[index]))
                {
                    Exercises[index].ReGenerate();
                    ExercisesToPrint.Add(Exercises[index]);
                }

            }

            /*while (ExercisesToPrint.Count < 5)
            {
                var random = MathService.Stamp.Next(Exercises.Count);
                if (ExercisesToPrint.All(x => x != Exercises[random]))
                {
                    ExercisesToPrint.Add(Exercises[random]);
                    ExercisesList.SetItemCheckState(random, CheckState.Checked);
                }
            }*/
            if (fbd.SelectedPath == "" || fbd.SelectedPath == null)
            {
                fbd.SelectedPath = path;
            }
            //var content = XMLGenereator.BeginofXMl.ToString()+XMLGenereator.BeginOfTex.ToString();
            var content = "";
            foreach (var exercise in ExercisesToPrint)
            {
                content += exercise.GetXML();
            }
            //content += XMLGenereator.EndOFTex.ToString() + XMLGenereator.EndOFXML.ToString();
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+"XMLData.xml", content, Encoding.UTF8);
            WordGenereator word = new WordGenereator(fbd.SelectedPath, ExercisesToPrint);
            word.CreateDoc();

            System.IO.StreamWriter latex =
                new System.IO.StreamWriter(fbd.SelectedPath + "\\latexCode.doc");
            latex.WriteLine(content);
            latex.Close();



            var xml = "";
            //System.IO.File.ReadAllText(
            //    "C:\\Users\\Atencjusz\\Documents\\Visual Studio 2015\\Projects\\GeneratorKolokwium\\generatorKolokwiumZZakresuTeoriiLiczb\\XMLFile1.xml");
            //System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "XMLData.xml");

            string fileName = "Begin.xml";
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Begin.xml");
            xml =
                System.IO.File.ReadAllText(filePath);
            xml += content;
            fileName = "End.xml";
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"End.xml");
            xml += System.IO.File.ReadAllText(filePath);




            try
            {

            
            string responsetext = null;

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://sciencesoft.at/latex");
            byte[] bytes;
            bytes = System.Text.Encoding.UTF8.GetBytes(xml);
            request.ContentType = "application/xml; charset=utf-8";
            request.ContentLength = bytes.Length;
            request.Method = "PUT";
            Stream requestStream = request.GetRequestStream();


            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            HttpWebResponse response;
            response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                responsetext = responseStr;
            }
            //var client = new HttpClient();
            //var content = new StringContent(xml);
            //var httpContent = new StringContent(xml, Encoding.UTF8, "application/soap;");
            //var whatIGet = client.PutAsync("http://sciencesoft.at/latex", httpContent).Result;
            //var contents = await whatIGet.Content.ReadAsStringAsync();

            string toSee = "";
            if (responsetext.IndexOf("<success>true</success>") >= 0)
            {
                int start = responsetext.IndexOf("<data>");
                int end = responsetext.IndexOf("</data>");
                if (start >= 0 && end >= 0)
                {
                    start += "<data>".Length;
                    var toDecode = responsetext.Substring(start, end - start);
                    //var base64EncodedBytes = Encoding.GetEncoding(28592).GetBytes(toDecode);
                    //var base64EncodedBytes = Encoding.Default.GetBytes(toDecode);
                    
                    var base64EncodedBytes = System.Convert.FromBase64String(toDecode);
                    toSee = System.Text.Encoding.ASCII.GetString(base64EncodedBytes);
                    MemoryStream ms = new MemoryStream(base64EncodedBytes, 0,
                        base64EncodedBytes.Length);


                    System.IO.FileStream stream =
                    new FileStream(fbd.SelectedPath + "\\Zadania.pdf", FileMode.Create);
                    //try
                    //{

                    //    System.IO.FileStream stream =
                    //    new FileStream(path + "\\file.pdf", FileMode.Create);
                    //}
                    //catch (Exception)
                    //{
                    //    System.IO.FileStream stream =
                    //    new FileStream(path + "\\file.pdf", FileMode.);
                    //}
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(base64EncodedBytes, 0, base64EncodedBytes.Length);
                    writer.Close();
                    //  Convert byte[] to Image
                    //ms.Write(base64EncodedBytes, 0, base64EncodedBytes.Length);
                    //Image image = Image.FromStream(ms, true);
                    //image.Save(path+  "\\obraz.png", System.Drawing.Imaging.ImageFormat.Jpeg);
                }

            }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z WebApi Latex", "Błąd połączenia",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
      //// Prepare HTTP put

        //    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        //    // Request content will be retrieved directly
        //    // from the input stream
        //    put.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
        //    put.setRequestEntity(new StringRequestEntity(xml, null, "utf-8"));


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCheckEventArgs myEvent = e as ItemCheckEventArgs;
            int sCount = ExercisesList.CheckedItems.Count;
            if (sCount != 0 )
            {
                Generate.Enabled = true;
            }
            else
            {
                Generate.Enabled = false;
            }
            //bool removingAllowed = true;
            //if (ExercisesList.CheckedItems.Count > 4)
            //{
            //    object[] list = new object[ExercisesList.CheckedItems.Count];
            //    ExercisesList.CheckedItems.CopyTo(list, 0);
            //    removingAllowed = !list.Any(x => x == ExercisesList.SelectedItem);
            //}
            //if (ExercisesList.CheckedItems.Count > 4 && removingAllowed)
            //{
            //    ExercisesList.SelectionMode = SelectionMode.None;
            //}
            //ExercisesList.SelectionMode = SelectionMode.One;

        }
    }
}
