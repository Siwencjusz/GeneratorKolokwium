using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatorKolokwiumZZakresuTeoriiLiczb
{
    public static class XMLGenereator
    {
        public static string BeginofXMl
        {
            get
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine +
"<latex ochem=\"false\" utf8=\"true\"> " + Environment.NewLine +
 "<dev papersize=\"a4\"" + Environment.NewLine +
  "dpi =\"600\"" + Environment.NewLine +
  "pdfwrite =\"UTF-8\"" + Environment.NewLine +
  "utf8 =\"true\">" + Environment.NewLine +
  " pdfwrite</dev> " + Environment.NewLine +
  "<src> " + Environment.NewLine +
    "<![CDATA[" + Environment.NewLine;
            }
        }

        public static string BeginOfTex
        {
            get
            {
                return "\\documentclass[a4paper,12pt]{memoir}" + Environment.NewLine +
"\\usepackage{etoolbox}" + Environment.NewLine +
"\\pagestyle{empty}" + Environment.NewLine +
"\\usepackage[utf8]{inputenc}" + Environment.NewLine +
"\\usepackage{amsmath}" + Environment.NewLine +
"\\usepackage[french,german,polish,english]{babel}" + Environment.NewLine +
"\\usepackage{polski}" + Environment.NewLine +
"\\DeclareTextCompositeCommand{\\k}{LY1}{a}" + Environment.NewLine +
"{\\oalign{a\\crcr\\noalign{\\kern-.27ex}\\hidewidth\\char7}}" + Environment.NewLine +
"\\DeclareTextCompositeCommand{\\k}{LY1}{e}" + Environment.NewLine +
"{\\oalign{e\\crcr\\noalign{\\kern-.27ex}\\hidewidth\\char7\\hidewidth}}" + Environment.NewLine +
"\\DeclareTextCompositeCommand{\\k}{LY1}{E}" + Environment.NewLine +
"{\\oalign{E\\crcr\\hidewidth\\char7\\hidewidth}}" + Environment.NewLine +
"\\selectlanguage{polish}" + Environment.NewLine +
"\\usepackage{lmodern}" + Environment.NewLine +
"\\usepackage[LGR,T1]{fontenc}" + Environment.NewLine +
"%	options include 12pt or 11pt or 10pt" + Environment.NewLine +
"%	classes include article, report, book, letter, thesis" + Environment.NewLine +
"\\usepackage{datetime}" + Environment.NewLine +
"\\newdateformat{specialdate}{\\THEYEAR-\\twodigit{\\THEMONTH}-\\twodigit{\\THEDAY}}" + Environment.NewLine +
"\\pagestyle{empty}" + Environment.NewLine +
"\\setlength{\\droptitle}{-15pt}     % Eliminate the default vertical space" + Environment.NewLine +
"%\\addtolength{\\droptitle}{-11pt}" + Environment.NewLine +
"\\title{{\\huge Kolokwium Teoria Liczb}}" + Environment.NewLine +
"\\date{\\specialdate\\today}" + Environment.NewLine +
"\\begin{document}" + Environment.NewLine +
"\\maketitle" + Environment.NewLine +
"\\thispagestyle{empty}" + Environment.NewLine +
"\\setlength{\\parindent}{0pt}" + Environment.NewLine +
"\\setlength{\\parskip}{1.2ex plus 1.2ex minus 1.2ex}" + Environment.NewLine +
"\\begin{enumerate}" + Environment.NewLine;
            }
        }
        public static string EndOFTex
        {
            get
            {
                return "\\end{ enumerate}\\end{ document}";
            }
        }

        public static string EndOFXML
        {
            get
            {
                return "]]>  </src>  <embeddedData>true</embeddedData></latex>";
            }
        }
    }
}
