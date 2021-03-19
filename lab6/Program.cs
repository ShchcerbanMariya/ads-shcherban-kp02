using System;

namespace lab6
{
    class SlList
    {
        public Node head;
        public Node tail;
        public int size = 0;
        public Node current;

        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
            }
        }
        public SlList()
        {

        }
        public SlList(int data)
        {
            head = new Node(data);
        }
        public void Enqueue(int data)
        {
            Node node = new Node(data);
            Node tempNode = tail;
            tail = node;
            if (size == 0)
                head = tail;
            else
                tempNode.next = tail;
            size++;
        }
        public void DeleteAHalf(int position)
        {
            if (position == 0)
            {
                tail = null;
                head = tail;
                size = 0;
            }
            else
            {
                int count = 1;
                current = head;
                while (current != null && count != position)
                {
                    current = current.next;
                    count++;
                }
                current = current.next;
                head = current;
                size = size - position;
            }

        }
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            Node current = head;
            Console.Write("Current list: ");
            while (current != null)
            {
                Console.Write(current.data);
                if (current.next != null) Console.Write(" -> ");
                current = current.next;
            }

            Console.WriteLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SlList list = new SlList();
            int count = 0;
            Random random = new Random();
            Console.WriteLine("Write 1 to choose the example, type 2 for entering your own data ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    while (count != 3)
                    {
                        int num = random.Next(-10, 50);
                        Console.WriteLine("enteres number is " + num);
                        if (num < 0)
                        {
                            int position;
                            if (list.size % 2 != 0)
                            {
                                position = list.size / 2 + 1;
                            }
                            else
                            {
                                position = list.size / 2;
                            }
                            list.DeleteAHalf(position);
                            count++;
                            list.Print();
                        }
                        else
                        {
                            list.Enqueue(num);
                            list.Print();
                        }
                    }

                    break;
                case "2":
                    while (count != 3)
                    {
                        Console.Write("add a number: ");
                        int num;
                        bool Ncheck = int.TryParse(Console.ReadLine(), out num);
                        if (Ncheck)
                        {
                            if (num < 0)
                            {
                                int position;
                                if (list.size % 2 != 0)
                                {
                                    position = list.size / 2 + 1;
                                }
                                else
                                {
                                    position = list.size / 2;
                                }
                                list.DeleteAHalf(position);
                                count++;
                            }
                            else
                            {
                                list.Enqueue(num);
                            }
                        }
                        else
                            Console.WriteLine("number is needed");
                        list.Print();
                    }
                    break;
                default:
                    Console.WriteLine("incorrect choice");
                    break;



            }
        }
    }
}
