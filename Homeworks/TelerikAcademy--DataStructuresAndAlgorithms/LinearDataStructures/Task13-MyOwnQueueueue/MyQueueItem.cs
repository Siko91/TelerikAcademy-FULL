using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13_MyOwnQueueueue
{
    internal class MyQueueItem<T>
    {
        internal MyQueueItem(T value)
        {
            this.Value = value;
        }

        internal MyQueueItem<T> NextItem { get; set; }

        internal T Value { get; set; }
    }
}