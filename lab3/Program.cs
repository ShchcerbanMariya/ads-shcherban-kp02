using System;

namespace lab3
{
    class Program
    {
        static void CreateMatrix(int[,] array)
        {
            Random random = new Random();
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(10, 100);
                    do
                    {
                        count = 0;
                        foreach (int element in array)
                        {
                            if (element == array[i, j])
                                count++;
                        }
                        if (count > 1)
                            array[i, j] = random.Next(10, 100);
                    }
                    while (count != 1);
                }
            }
        }

        static void Sortlements(int[] main, int[] second, int size)
        {
            for (int i = 1; i < size; i++)
            {
                int key = main[i];
                int j = i - 1;
                while (j >= 0 && main[j] < key)
                {
                    main[j + 1] = main[j];
                    j = j - 1;
                }
                main[j + 1] = key;
            }
            for (int i = 1; i < size; i++)
            {
                int key = second[i];
                int j = i - 1;
                while (j >= 0 && second[j] > key)
                {
                    second[j + 1] = second[j];
                    j = j - 1;
                }
                second[j + 1] = key;
            }
            
        }
        static void SortWithCommonElement(int[] main, int[] second, int element_index, int size)
        {
            int save = main[element_index];
            main[element_index] = main[size - 1];
            main[size - 1] = save;
            for (int i = 1; i < size - 1; i++)
            {
                int key = main[i];
                int j = i - 1;
                while (j >= 0 && main[j] < key)
                {
                    main[j + 1] = main[j];
                    j = j - 1;
                }
                main[j + 1] = key;

            }

            int swap = main[size - 1];
            for (int i = size - 2; i >= element_index; i--)
            {
                main[i + 1] = main[i];
            }
            main[element_index] = swap;


            save = second[element_index];
            second[element_index] = second[size - 1];
            second[size - 1] = save;
            for (int i = 1; i < size - 1; i++)
            {
                int key = second[i];
                int j = i - 1;
                while (j >= 0 && second[j] > key)
                {
                    second[j + 1] = second[j];
                    j = j - 1;

                }
                second[j + 1] = key;

            }

            swap = second[size - 1];
            for (int i = size - 2; i >= element_index; i--)
            {
                second[i + 1] = second[i];
            }
            second[element_index] = swap;
        }
        static void PrintArray(int[] array, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0}, ", array[i]);
            }
            Console.WriteLine();
        }
        static void PrintMatrix(int[,] matrix, bool check_element, int element_index)
        {
            int N = matrix.GetLength(0);
            int M = matrix.GetLength(1);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (i == j || j == M - i - 1)
                    {
                        if (check_element)
                        {

                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            int value = matrix[i, j];
                            if (i == element_index)
                            {
                                Console.ResetColor();
                                Console.Write("{0, 4} ", value);
                            }
                            else
                            {
                                Console.Write("{0, 4} ", value);
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            int value = matrix[i, j];
                            Console.Write("{0, 4} ", value);
                            Console.ResetColor();
                        }


                    }
                    else
                    {
                        int value = matrix[i, j];
                        Console.Write("{0, 4} ", value);
                    }
                }
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            Console.Write(" введіть розмір  матриці: ");
            int N;
            bool Ncheck = int.TryParse(Console.ReadLine(), out N); //tryparse
            Console.Write(" введіть розмір  матриці: ");
            int M;
            bool Mcheck = int.TryParse(Console.ReadLine(), out M);
            if (Ncheck && N > 0 && Mcheck && M > 0)
            {
                int size;
                if (N > M)
                    size = M;
                else size = N;

                int element_index = 0;
                bool check_element = false;
                int[,] array = new int[N, M];
                int[] main = new int[size];
                int[] second = new int[size];

                CreateMatrix(array);
                

                for (int i = 0; i < size; i++)
                {
                    main[i] = array[i, i];
                    second[i] = array[i, M - 1 - i];
                }

                //find common index
                for (int i = 0; i < size; i++)
                {
                    if (N % 2 == 0 && M % 2 == 0)
                        break;
                    if (main[i] == second[i])
                    {
                        check_element = true;
                        element_index = i;
                        break;
                    }
                }

                PrintMatrix(array, check_element, element_index);

                if (check_element)
                {
                    SortWithCommonElement(main, second, element_index, size);
                }
                else
                {
                    Sortlements(main, second, size);
                }


                for (int i = 0; i < size; i++)
                {
                    array[i, i] = main[i];
                    array[i, M - 1 - i] = second[i];
                }
               
                Console.WriteLine();
                PrintMatrix(array, check_element, element_index);

            }
            else
                Console.WriteLine("incorrect input");
        }
    }
}
