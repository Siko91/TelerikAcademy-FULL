using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_MyLinkedList
{
    internal class MyLinkedListItem<T>
    {
        public MyLinkedListItem(T value)
        {
            this.Value = value;
        }

        internal MyLinkedListItem<T> NextItem { get; set; }

        internal MyLinkedListItem<T> PrevItem { get; set; }

        internal T Value { get; set; }
    }
}