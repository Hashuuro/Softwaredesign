using System;
using System.Collections;
using System.Globalization;

namespace L4
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child2");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            root.PrintTree();
        }

        public class Tree<T>
        {
            public TreeNode<T> CreateNode(T content)
            {
                TreeNode<T> node = new TreeNode<T>();
                node.nodeContent = content;
                return node;
            }
        }

        public class TreeNode<T>
        {
            public TreeNode<T> parent;
            public TreeNode<T>[] child;
            public int numberOfChildren = 0;
            public T nodeContent;

            public void AppendChild(TreeNode<T> node)
            {
                if (numberOfChildren == 0)
                {
                    child = new TreeNode<T>[] { node };
                }
                else
                {
                    TreeNode<T>[] childOld = child;
                    child = new TreeNode<T>[numberOfChildren+1];
                    Array.Copy(childOld, child, numberOfChildren);
                    child[numberOfChildren] = node;
                }

                numberOfChildren++;
                node.parent = this;
            }

            public void RemoveChild(TreeNode<T> node)
            {
                if (numberOfChildren == 0)
                {
                    Console.WriteLine(node.nodeContent + ": Diese Baumstruktur besitzt keine Child-Knoten");
                }
                else
                {
                    Boolean found = false;
                    for (int i = 0; i < child.Length - 1; i++)
                    {
                        if (child[i].Equals(node))
                        {
                            found = true;
                        }

                        if (found)
                        {
                            child[i] = child[i+1];
                        }
                    }

                    numberOfChildren--;

                    TreeNode<T>[] childOld = child;
                    child = new TreeNode<T>[numberOfChildren];
                    Array.Copy(childOld, child, numberOfChildren);
                }
            }

            public void PrintTree(String Hierarchy = "")
            {
                Console.WriteLine(Hierarchy + nodeContent.ToString());

                if (numberOfChildren > 0)
                {
                    foreach(var node in child)
                    {
                        node.PrintTree(Hierarchy+"*");
                    }
                }
            }

            public void Find(string s ){

           
              
            }
        }

    }
}
