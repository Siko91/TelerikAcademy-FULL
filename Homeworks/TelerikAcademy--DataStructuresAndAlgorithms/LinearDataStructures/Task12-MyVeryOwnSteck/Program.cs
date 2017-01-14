using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_MyVeryOwnSteck
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MySteck<int> st = new MySteck<int>();
            for (int i = 0; i < 20; i++)
            {
                st.Push(i);
            }
            while (st.Count > 0)
            {
                Console.Write(st.Pop() + ", ");
            }
        }
    }
}