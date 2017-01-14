using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sort
{
    class Program
    {

        static Encoding encoding = Encoding.GetEncoding(1251);

        static string GetFirstChar(char ch)
        {
            switch (ch)
            {
                case 'а': return "01-A";
                case 'б': return "02-B";
                case 'в': return "03-V";
                case 'г': return "04-G";
                case 'д': return "05-D";
                case 'е': return "06-E";
                case 'ж': return "07-ZH";
                case 'з': return "08-Z";
                case 'и': return "09-I";
                case 'й': return "10-I'";
                case 'к': return "11-K";
                case 'л': return "12-L";
                case 'м': return "13-M";
                case 'н': return "14-N";
                case 'о': return "15-O";
                case 'п': return "16-P";
                case 'р': return "17-R";
                case 'с': return "18-S";
                case 'т': return "19-T";
                case 'у': return "20-U";
                case 'ф': return "21-F";
                case 'х': return "22-H";
                case 'ц': return "23-TS";
                case 'ч': return "24-CH";
                case 'ш': return "25-SH";
                case 'щ': return "26-SHT";
                case 'ъ': return "27-EOA";
                case 'ь': return "28-EOA'";
                case 'ю': return "29-IU";
                case 'я': return "30-IA";

                default:
                    break;
            }
            return "0000";
        }

        static void Main(string[] args)
        {
            long num = 0;

            StreamReader reader = new StreamReader(@"..\..\111.txt", encoding);
            
            string line = reader.ReadLine().ToLower();

            while (line != null)
            {
                num++;
                if (line.Equals("\t"))
                {
                    line = reader.ReadLine().ToLower();
                    continue;
                }
                if (line.Equals(string.Empty))
                {
                    line = reader.ReadLine().ToLower();
                    continue;
                }


                string firstLetter = GetFirstChar(line[0]);
                string secondLetter = "";
                if ('я' - line[1] > 15)
                {
                    secondLetter = "A-P";
                }
                else if ('я' - line[1] <= 15)
                {
                    secondLetter = "P-IA";
                }

                StreamWriter write = new StreamWriter(@"..\..\" + secondLetter + ")" + firstLetter + "--" + secondLetter + ".txt", true, encoding);
                write.WriteLine("case \"" + line + "\": return true;" );
                write.Dispose();
                Console.WriteLine("Word Writen - " + num);
                line = reader.ReadLine().ToLower();
            }

            reader.Dispose();
            Console.WriteLine("Done!");
        }
    }
}
