using System;

namespace lab4
{
    class SlList
    {
        public Node head;
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
        public void Print()
        {
            Console.WriteLine();
            Console.Write("Changed list: ");
            if (head == null)
            {
                Console.WriteLine(" is empty");
                return;
            }

            Node current = head;

            while (current != null)
            {
                Console.Write(current.data);
                if (current.next != null) Console.Write(" -> ");
                current = current.next;
            }

            Console.WriteLine();
        }
        public void AddBeforeTail(int data)
        {
            current = head;
            Node newTail = new Node(data);
            if (head == null)
            {
                head = newTail;
                size++;
            }
            else if (size == 1)
            {
                Node tmp = head;
                head = newTail;
                newTail.next = tmp;
                tmp = null;
                size++;
            }
            else
            {
                current = head;
                while (current.next.next != null)
                {
                    current = current.next;
                }
                Node tail = current.next;
                current.next = newTail;
                newTail.next = tail;
                size++;
            }

        }

    }

    class DLList
    {
        public DlNode head;
        public DlNode current;
        public int size = 0;
        public int min;
        public DlNode minpos;
        public int max;
        public DlNode maxpos;

        public class DlNode
        {
            public int data;
            public DlNode next;
            public DlNode prev;


            public DlNode(int data)
            {
                this.data = data;
            }

        }
        public DLList()
        {

        }
        public DLList(int data)
        {
            head = new DlNode(data);

        }



        public void AddFirst(int data)
        {
            DlNode newHead = new DlNode(data);

            if (head == null)
            {
                head = newHead;
                size = 1;

            }
            else
            {
                head.prev = newHead;
                newHead.next = head;
                head = newHead;
                size++;
            }

        }

        public void AddAtPosition(int data, int pos)
        {
            if (pos < 1 || pos > size)
            {
                Console.WriteLine("incorrect index, added into head");
                AddFirst(data);
                return;
            }
            current = head;
            DlNode newElement = new DlNode(data);
            for (int i = 1; i < pos - 1; i++)
            {
                current = current.next;
            }

            newElement.next = current.next;
            newElement.prev = current;
            current.next = newElement;
            current.next.prev = newElement;
            size++;
        }


        public void AddLast(int data)
        {

            current = head;
            DlNode newTail = new DlNode(data);
            if (head == null)
            {
                head = newTail;
                size = 1;
            }
            else
            {
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newTail;
                newTail.prev = current;
                current = newTail;
                size++;
            }

        }

        public void DeleteFirst()
        {
            if (head == null)
            {
                Console.WriteLine("the list is empty");
                return;
            }
            current = head;
            head = head.next;
            current.next = null;
            head.prev = null;
            size--;
        }
        public void DeleteLast()
        {
            if (current == null)
            {
                Console.WriteLine("the list is empty");
                return;
            }

            current = head;
            while (current.next != null)
            {
                current = current.next;
            }


            if (current != null && current.prev != null)
            {
                current = current.prev;
                current.next = null;
                size--;
            }
            else
            {
                head = null;
                current = null;
                size = 0;
            }


        }

        public void DeleteAtPosition(int position)
        {
            if (position < 1 || position > size)
            {
                Console.WriteLine("incorrect.position");
                return;
            }
            else if (position == 1)
            {
                DeleteFirst();
            }
            else if (position == size)
            {
                DeleteLast();
            }
            else
            {
                uint count = 1;
                current = head;
                while (current != null && count != position)
                {
                    current = current.next;
                    count++;
                }
                current.prev.next = current.next;
                current.next.prev = current.prev;
                size--;
            }

        }



        public void Print()
        {
            Console.WriteLine();
            Console.Write("Current list: ");
            if (head == null)
            {
                Console.WriteLine(" is empty");
                return;
            }

            DlNode current = head;

            while (current != null)
            {
                Console.Write(current.data);
                if (current.next != null) Console.Write(" <-> ");
                current = current.next;
            }
            Console.WriteLine();


        }

        private void FindMinAndMAx()
        {
            if (head == null)
            {
                Console.WriteLine("the list is empty");
                return;
            }
            minpos = head;
            maxpos = head;
            DlNode current = head;
            for (int i = 0; i < size; i++)
            {
                if (current.data < minpos.data)
                {
                    minpos = current;
                    min = i;
                }
                if (current.data > maxpos.data)
                {
                    maxpos = current;
                    max = i;
                }
                current = current.next;
            }

        }
        public void CopyList(SlList copylist)
        {
            FindMinAndMAx();

            if (minpos.next == maxpos || maxpos.next == minpos || minpos == maxpos)
            {
                Console.WriteLine("there is no element to delete");
                return;
            }

            current = head;
            int count = 0;

            for (int j = 0; j < size; j++)
            {
                count = j;
                if (j == min || j == max)
                {
                    break;
                }
                current = current.next;
            }

            if (current == minpos)
            {
                while (current.next != maxpos)
                {
                    copylist.AddBeforeTail(current.next.data);
                    this.DeleteAtPosition(count + 2);
                }

            }
            else if (current == maxpos)
            {
                while (current.next != minpos)
                {
                    copylist.AddBeforeTail(current.next.data);
                    this.DeleteAtPosition(count + 2);
                }
            }


        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            DLList list = new DLList();
            SlList copylist = new SlList();

            while (true)
            {
                Console.WriteLine(@"Write the number of the command you want to choose:
                                    1. Add First 
                                    2. Add Last
                                    3. Add at a position
                                    4. Delete First
                                    5. Delete Last
                                    6. Delete At a position
                                    7. Create a second list
                                    or print end to stop the program ");

                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "1":
                        {
                            Console.WriteLine("enter the number you want to add");
                            int num;
                            bool Ncheck = int.TryParse(Console.ReadLine(), out num);
                            if (Ncheck)
                            {
                                list.AddFirst(num);
                            }
                            else
                                Console.WriteLine("number is needed");
                            list.Print();

                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("enter the number you want to add");
                            int num;
                            bool Ncheck = int.TryParse(Console.ReadLine(), out num);
                            if (Ncheck)
                            {
                                list.AddLast(num);
                            }
                            else
                                Console.WriteLine("number is needed");
                            list.Print();

                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("enter the position where you want to add a number");
                            int pos;
                            bool Poscheck = int.TryParse(Console.ReadLine(), out pos);
                            if (Poscheck)
                            {
                                Console.WriteLine("enter the number you want to add");
                                int num;
                                bool Ncheck = int.TryParse(Console.ReadLine(), out num);
                                if (Ncheck)
                                {
                                    list.AddAtPosition(num, pos);
                                }
                                else
                                    Console.WriteLine("incorrect position");
                            }
                            else
                                Console.WriteLine("incorrect number");
                            list.Print();

                            break;
                        }
                    case "4":
                        {
                            list.DeleteFirst();
                            list.Print();

                            break;
                        }
                    case "5":
                        {
                            list.DeleteLast();
                            list.Print();

                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("enter the position where you want to delete a number");
                            int pos;
                            bool Poscheck = int.TryParse(Console.ReadLine(), out pos);
                            if (Poscheck)
                            {
                                list.DeleteAtPosition(pos);
                            }
                            else
                                Console.WriteLine("incorrect position");
                            list.Print();

                            break;
                        }
                    case "7":
                        {
                            list.CopyList(copylist);
                            list.Print();
                            if (copylist == null)
                            {
                                Console.WriteLine("no element");
                            }
                            else
                                copylist.Print();
                            break;
                        }

                    default:
                        Console.WriteLine("Wrong command");
                        break;


                }

            }
        }
    }
}
