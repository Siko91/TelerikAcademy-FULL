using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_MyLinkedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}