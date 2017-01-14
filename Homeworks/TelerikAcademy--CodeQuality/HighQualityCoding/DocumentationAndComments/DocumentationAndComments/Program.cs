using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.ILS.Common;

namespace DocumentationAndComments
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ohahи! My наме ис Jing Хао Бао aaaaa Aha"
                .GetStringBetween("Oha","Aha")
                .CapitalizeFirstLetter()
                .GetFirstCharacters("hи! My наме ис Jing Хао Бао".Length)
                .ConvertCyrillicToLatinLetters()

                + "\n\nJust kidding. My name is Alex (or is it?)\nThis is just a little test.\n\nIt's a poorly done test. Please don't score it."
                );
            Console.ReadKey();
        }
    }
}
