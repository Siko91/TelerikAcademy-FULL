using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6Tree
{
    class NodeElement<T> : ICloneable where T: ICloneable
    {
        private T value;

        private NodeElement<T> leftChild;
        private NodeElement<T> rightChild;

        public T Value { get { return this.value; } set { this.value = value; } }
        public NodeElement<T> LeftChild { get { return this.leftChild; } }
        public NodeElement<T> RightChild { get { return this.rightChild; } }

        public NodeElement(T value, NodeElement<T> leftChild = null, NodeElement<T> rightChild = null)
        {
            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
        public void AddLeftChild(NodeElement<T> leftChild)
        {
            this.leftChild = leftChild;
        }
        public void AddRightChild(NodeElement<T> rightChild)
        {
            this.rightChild = rightChild;
        }
        public override string ToString()
        {
            string result = this.value.ToString();
            if (this.leftChild != null || this.rightChild != null)
            {
                result += "{ " + this.leftChild.ToString() + ", " + this.rightChild.ToString() + " }";
            }
            return result;
        }
        public bool Equals(NodeElement<T> element)
        {
            return (this.value.Equals(element.value));
        }
        public override bool Equals(object obj)
        {
            if (obj is NodeElement<T>)
            {
                return this.Equals((NodeElement<T>)obj);
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode(); // I seriously don't know how it should be done. What's the proper way?
        }
        public static bool operator ==(NodeElement<T> n1, NodeElement<T> n2)
        {
            return n1.Equals(n2);
        }
        public static bool operator !=(NodeElement<T> n1, NodeElement<T> n2)
        {
            return n1.Equals(n2);
        }
        public object Clone()
        {
            NodeElement<T> clone = new NodeElement<T>((T)this.value.Clone());
            if (this.leftChild != null)
            {
                clone.AddLeftChild((NodeElement<T>)this.leftChild.Clone());
            }
            if (this.leftChild != null)
            {
                clone.AddRightChild((NodeElement<T>)this.rightChild.Clone());
            }
            return clone;
        }
    }
}
