using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13_MyOwnQueueueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new MyQueueue<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Enqueue(i);
            }
            while (list.Count > 0)
            {
                Console.WriteLine(list.Dequeue());
            }
        }
    }
}