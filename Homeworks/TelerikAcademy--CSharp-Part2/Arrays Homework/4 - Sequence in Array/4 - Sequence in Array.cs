using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, [2, 2, 2], 1}  {2, 2, 2}.*/

class SequenceinArray
{
    static void Main(string[] args)
    {
        Console.Write("The Array will be a string. Input string: ");
        string str = Console.ReadLine();
        char[] charArray = str.ToCharArray();

        int longestLength = 0;
        int position = 0;

        for (int i = 0; i < charArray.Length; i++)
        {
            int temp = 0;

            for (int y = i+1; y < charArray.Length; y++)
            {
                if (charArray[i] == charArray[y])
                {
                    temp++;
                }
                else
                {
                    break;
                }
            }
            if (temp > longestLength)
            {
                position = i;
                longestLength = temp;
            }

            i += temp;
        }
        Console.Write("Bigest sequence: ");
        for (int i = 0; i <= longestLength; i++)
        {
            Console.Write(charArray[i+position]);
        }
        Console.WriteLine();
    }
}
