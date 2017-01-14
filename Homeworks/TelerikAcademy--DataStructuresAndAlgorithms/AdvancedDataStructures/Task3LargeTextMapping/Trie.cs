using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3LargeTextMapping
{
    public struct Letter
    {
        public const string Chars = "abcdefghijklmnopqrstuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "1234567890";
        public int Index;

        public static implicit operator Letter(char c)
        {
            return new Letter() { Index = Chars.IndexOf(c) };
        }

        public char ToChar()
        {
            return Chars[Index];
        }

        public override string ToString()
        {
            return Chars[Index].ToString();
        }
    }

    public class Trie
    {
        public Node Root = new Node();

        public Trie(string[] words)
        {
            for (int w = 0; w < words.Length; w++)
            {
                var word = words[w];
                var node = Root;
                for (int len = 1; len <= word.Length; len++)
                {
                    var letter = word[len - 1];
                    Node next;
                    if (!node.Edges.TryGetValue(letter, out next))
                    {
                        next = new Node();
                        if (len == word.Length)
                        {
                            next.Word = word;
                        }
                        node.Edges.Add(letter, next);
                    }
                    node = next;
                }
            }
        }

        public bool Contains(string searchWord)
        {
            var currentNode = this.Root;
            char ch;
            for (int chInd = 0; chInd < searchWord.Length; chInd++)
            {
                ch = searchWord[chInd];
                foreach (var node in currentNode.Edges)
                {
                    if (node.Key.ToChar() == ch)
                    {
                        //MessageBox.Show(ch.ToString());
                        currentNode = node.Value;
                        break;
                    }
                }
            }
            if (currentNode.Word != null && currentNode.Word.Equals(searchWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class Node
        {
            public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();
            public string Word;

            public bool IsTerminal { get { return Word != null; } }
        }
    }
}