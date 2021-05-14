using System;
using static System.Console;

namespace lab_8
{
    public class Node
    {
        public Node left, right, Parent;
        public int Data;
        /*public Node()
        {

        }*/
        public Node(int d)
        {
            Data = d;
            left = right = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            Console.WriteLine("You can enter: add and print commands");
            while (true)
            {
                Console.WriteLine("Commmand: ");
                string input = Console.ReadLine();
                string[] substrings = input.Split(' ');
                if (substrings.Length == 2 && substrings[0] == "add")
                {
                    int num;
                    bool check = int.TryParse(substrings[1], out num);
                    if (!check || num < 0)
                    {
                        Console.WriteLine("incorrect number");
                        continue;
                    }
                    tree.Insert(num);
                   
                }
                else if (substrings.Length == 1 && substrings[0] == "print")
                {
                    WriteLine();
                    tree.Print();
                    WriteLine();
                }
                else if (substrings.Length == 1 && substrings[0] == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("incorrect command");
                    continue;
                }

                if (!tree.IsComplete())
                {
                    WriteLine("the tree is not completed");
                    continue;
                }
                tree.preorderTraversal();
                if (tree.maxHeap == false)
                {
                    WriteLine("the tree isn't the maximum binary heap");
                    Write("list of nodes that need to be edited: ");
                    foreach (Node item in tree.nodes)
                    {
                        Write($"{item.Data.ToString()} ");
                    }
                    tree.nodes.Clear();
                    WriteLine("maximum binary heap: ");
                    WriteLine();
                    tree.Print();
                }
                else
                {
                    WriteLine("the tree is the maximum binary heap");
                }


            }
        }
    }
}
