using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5BitArray
{
    class BitArray64 : IEnumerable<int>
    {
        /*Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
*/
        private ulong bits;

        public int this[int i]
        {
            get
            {
                if (i < 0 || i > 63)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return ((bits & ((ulong)1 << i)) == ((ulong)1 << i)) ? 1 : 0; 
            }
            set
            {
                if (i < 0 || i > 63)
                {
                    throw new ArgumentOutOfRangeException();
                }
                bits = (bits & ((ulong)value << i));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); //Forward to strongly typed version
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return ((bits & ((ulong)1 << i)) == ((ulong)1 << i))? 1 : 0;
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                return false;
            }
            return this.Equals((BitArray64)obj);
        }
        public bool Equals(BitArray64 array)
        {
            bool result = true;
            for (int i = 0; i < 64; i++)
            {
                if (this[i] != array[i])
                {
                    result = false;
                }
            }
            return result;
        }
        static public bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            return (arr1.Equals(arr2));
        }
        static public bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            return (!arr1.Equals(arr2));
        }
    }
}
