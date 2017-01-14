using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6Tree
{
    struct BinaryTree<T> where T : ICloneable
    {
        NodeElement<T> root;
        public override string ToString()
        {
            return root.ToString();
        }
    }
}
