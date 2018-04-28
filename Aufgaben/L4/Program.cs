using System;

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
            public TreeNode<T> parentNode;
            public TreeNode<T>[] childNodes;
            public int numberOfChildNodes = 0;
            public T nodeContent;

            public void AppendChild(TreeNode<T> node)
            {
                if (numberOfChildNodes == 0)
                {
                    childNodes = new TreeNode<T>[] { node };
                }
                else
                {
                    TreeNode<T>[] childNodesOld = childNodes;
                    childNodes = new TreeNode<T>[numberOfChildNodes+1];
                    Array.Copy(childNodesOld, childNodes, numberOfChildNodes);
                    childNodes[numberOfChildNodes] = node;
                }

                numberOfChildNodes++;
                node.parentNode = this;
            }

            public void RemoveChild(TreeNode<T> node)
            {
                if (numberOfChildNodes == 0)
                {
                    Console.WriteLine(node.nodeContent + ": Diese Baumstruktur besitzt keine Child-Knoten");
                }
                else
                {
                    Boolean found = false;
                    for (int i = 0; i < childNodes.Length - 1; i++)
                    {
                        if (childNodes[i].Equals(node))
                        {
                            found = true;
                        }

                        if (found)
                        {
                            childNodes[i] = childNodes[i+1];
                        }
                    }

                    numberOfChildNodes--;

                    TreeNode<T>[] childNodesOld = childNodes;
                    childNodes = new TreeNode<T>[numberOfChildNodes];
                    Array.Copy(childNodesOld, childNodes, numberOfChildNodes);
                }
            }

            public void PrintTree(String Hierarchy = "")
            {
                Console.WriteLine(Hierarchy + nodeContent.ToString());

                if (numberOfChildNodes > 0)
                {
                    foreach(var node in childNodes)
                    {
                        node.PrintTree(Hierarchy+"*");
                    }
                }
            }
        }

    }
}
