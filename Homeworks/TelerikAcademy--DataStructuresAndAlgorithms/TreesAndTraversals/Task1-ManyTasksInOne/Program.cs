using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ManyTasksInOne
{
    internal class Program
    {
        internal class TreeNode<T>
        {
            internal TreeNode(T value)
            {
                this.Value = value;
                this.Children = new List<TreeNode<T>>();
            }

            internal List<TreeNode<T>> Children { get; set; }

            internal TreeNode<T> Parent { get; set; }

            internal T Value { get; set; }
        }

        private static void FindLongestPath(TreeNode<int> tree, ref int current, ref int max, ref TreeNode<int> fartherestNode)
        {
            current++;
            foreach (TreeNode<int> item in tree.Children)
            {
                if (item.Children.Count > 0)
                {
                    FindLongestPath(item, ref current, ref max, ref fartherestNode);
                }
                else if (max < current)
                {
                    max = current;
                    fartherestNode = item;
                }
            }
        }

        private static void Main(string[] args)
        {
            TreeNode<int> tree = ReadAndBuildTree("tree.txt");

            PrintRootNode(tree);

            Console.WriteLine("--------------");

            PrintMiddleNodes(tree);

            Console.WriteLine("--------------");

            PrintLeafNodes(tree);

            Console.WriteLine("--------------");

            int current = 0;
            int max = 0;
            TreeNode<int> fartherestNode = new TreeNode<int>(-1);
            FindLongestPath(tree, ref current, ref max, ref fartherestNode);
            PrintPathTo(fartherestNode);

            Console.WriteLine("--------------");

            PrintAllPathsWithSum(tree, 9);

            Console.WriteLine("--------------");

            PrintAllSubtreesWithSum(tree, 6);
        }

        private static void PrintAllPathsWithSum(TreeNode<int> tree, int p)
        {
            // TODO: Implement this method
            //throw new NotImplementedException();
        }

        private static void PrintAllSubtreesWithSum(TreeNode<int> tree, int p)
        {
            // TODO: Implement this method
            //throw new NotImplementedException();
        }

        private static void PrintLeafNodes(TreeNode<int> tree)
        {
            foreach (TreeNode<int> item in tree.Children)
            {
                if (item.Children.Count > 0)
                {
                    PrintLeafNodes(item);
                }
                else
                {
                    Console.WriteLine("Leaf: " + item.Value);
                }
            }
        }

        private static void PrintMiddleNodes(TreeNode<int> tree)
        {
            foreach (TreeNode<int> item in tree.Children)
            {
                if (item.Children.Count > 0)
                {
                    Console.WriteLine("Middle: " + item.Value);
                    PrintMiddleNodes(item);
                }
            }
        }

        private static void PrintPathTo(TreeNode<int> node)
        {
            Stack<TreeNode<int>> nodes = new Stack<TreeNode<int>>();

            nodes.Push(node);

            while (node.Parent != null)
            {
                node = node.Parent;
                nodes.Push(node);
            }
            Console.WriteLine("Longest path: ");

            do
            {
                node = nodes.Pop();
                Console.Write(node.Value + " -> ");
            } while (nodes.Count > 0);

            Console.WriteLine("End of path;");
        }

        private static void PrintRootNode(TreeNode<int> tree)
        {
            Console.WriteLine("Root: " + tree.Value);
        }

        private static TreeNode<int> ReadAndBuildTree(string filePath)
        {
            TreeNode<int>[] nodes;
            using (StreamReader reader = new StreamReader(filePath))
            {
                int size = int.Parse(reader.ReadLine());
                nodes = new TreeNode<int>[size];

                string LineStr = reader.ReadLine();

                while (LineStr != null)
                {
                    string[] line = LineStr.Split(' ');

                    int parentIndex = int.Parse(line[0]);
                    int childIndex = int.Parse(line[1]);

                    if (nodes[parentIndex] == null)
                    {
                        nodes[parentIndex] = new TreeNode<int>(parentIndex);
                    }
                    if (nodes[childIndex] == null)
                    {
                        nodes[childIndex] = new TreeNode<int>(childIndex);
                    }

                    TreeNode<int> parent = nodes[parentIndex];
                    TreeNode<int> child = nodes[childIndex];

                    parent.Children.Add(child);
                    child.Parent = parent;

                    LineStr = reader.ReadLine();
                }
            }

            TreeNode<int> mainNode = new TreeNode<int>(-1);
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Parent == null)
                {
                    mainNode = nodes[i];
                }
            }
            return mainNode;
        }
    }
}