using System;

namespace lab5
{

    class Program
    {
        static bool CheckInput(string[] substrings)
        {
            int data;
            for (int i = 0; i < substrings.Length; i++)
            {

                bool result = int.TryParse(substrings[i], out data);
                if (result == false)
                {
                    Console.WriteLine($"The {i + 1} argument is not a number");
                    return true;
                }
                if (substrings[i].Length != 3)
                {
                    Console.WriteLine($" {i + 1} wrong format");
                    return true;
                }
                if (int.Parse(substrings[i]) < 0)
                {
                    Console.WriteLine($"{i + 1} wrong number");
                    return true;
                }

            }
            return false;
        }
        static int[] CreateArray(string[] substrings)
        {

            int[] array = new int[substrings.Length];
            for (int i = 0; i < substrings.Length; i++)
            {
                array[i] = int.Parse(substrings[i]);
            }
            return array;

        }

        static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                if (element == array[array.Length - 1])
                {
                    Console.Write($"{element}; ");
                }
                else
                {
                    Console.Write($"{element}, ");
                }
            }
        }
        static void Sorting(int[] array)
        {
            int maxelement = array[0];
            int firstelement = array[0];
            foreach (int element in array)
            {
                if (element > maxelement)
                {
                    maxelement = element;
                }
            }

            for (int k = 1; maxelement / k > 0; k *= 10)
            {
                CountingSort(array, k, firstelement);
            }
        }
        static void Main(string[] args)
        {
           string str = "";
            Console.WriteLine("Write 1 to choose the example, type 2 for entering your own data ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    str = "007 006 005\r005 004 228\r625 113 225 114\r007 002 015\r";
                    break;
                case "2":
                    while (true)
                    {
                        Console.Write("write the list of numbers in the format (007 005 ...) or type end for soring procces: ");
                        string read = Console.ReadLine();
                        if (read == "end")
                            break;
                        str += read + '\r';
                    }
                    break;
                default:
                    Console.WriteLine("incorrect choice");
                    break;
            }
            string[] fsub = str.Split('\r');
            for (int i = 0; i < fsub[i].Length; i++)
            {
                string[] substrings = fsub[i].Split(' ');
                bool check = CheckInput(substrings);
                if (!check)
                {
                    int[] array = CreateArray(substrings);
                    bool ucheck = CheckifUnique(array);
                    if (!ucheck)
                    {
                        Sorting(array);
                        if (array[0] > array[1])
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            PrintArray(array);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            PrintArray(array);
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

        }
        static void CountingSort(int[] array, int place, int firstelement)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] casearray = new int[10];

            for (int i = 0; i < n; i++)
            {
                casearray[(array[i] / place) % 10]++;
            }


            for (int i = 1; i < 10; i++)
            {
                casearray[i] += casearray[i - 1];
            }


            for (int i = n - 1; i >= 0; i--)
            {
                output[casearray[(array[i] / place) % 10] - 1] = array[i];
                casearray[(array[i] / place) % 10]--;
            }
            if (firstelement == 7)
            {
                for (int i = 0; i < n; i++)
                {
                    array[i] = output[i];
                }
            }
            else
            {
                int size = n - 1;
                for (int i = 0; i < array.Length; i++)
                {
                    array[size] = output[i];
                    size--;
                }
            }

        }
        static bool CheckifUnique(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {

                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        Console.WriteLine("the numbers aren't unique");
                        return true;
                    }
                }

            }
            return false;
        }
    }
}