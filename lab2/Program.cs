using System;

namespace lab2
{
    class Program
    {
        static void min(int[,] main, int N)
        {
            int min = main[0, 0];
            int x1 = 0;
            int y1 = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int value = main[i, j];
                    if (value < min)
                    {
                        min = value;
                        x1 = i;
                        y1 = j;
                    }
                }
            }
            Console.WriteLine(" min = {0}" + "\r\n" + " index = [{1}, {2}]", min, x1, y1);
            if (x1 + y1 == N - 1) Console.WriteLine(" на побічній діагоналі");
            else if (x1 + y1 > N - 1) Console.WriteLine(" під побічною діагоналлю");
            else Console.WriteLine(" над побічною діагоналлю");
        }
        static void PrintNum(int[,] controle, int N)
        {
            int count = 0;
            int n = 0;
            int x = N / 2;
            int y = N / 2;
            while (count<N*N)
            {
                if (count == N * N) break;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" " + controle[x++, y]);
                    count++;
                }

                for (int i = 0; i < n; i++)
                {
                    Console.Write(" " + controle[x, y--]);
                    count++;
                }
                n++;

                if (count == N * N) break;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" " + controle[x--, y]);
                    count++;
                }
                if (count == N * N) break;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" " + controle[x, y++]);
                    count++;
                }
                if (count == N * N) break;
                n++;
            }
            Console.WriteLine();
        }

        static void PrintMatrix(int[,] matrix, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int value = matrix[i, j];
                    Console.Write("{0, 4} ", value);
                }
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            Console.Write(" введіть розмір квадратної матриці, число непарне : ");
            int N = int.Parse(Console.ReadLine());
            if (N < 0 || N % 2 == 0)
            {
                Console.WriteLine(" неправильні вхідні данні");
            }
            else
            {
                Console.Write(" Введіть 1 для вибору сгенерованої матриці, або 2 для контрольної: ");
                int choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    //основная матрица
                    Random random = new Random();
                    int[,] main = new int[N, N];
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            main[i, j] = random.Next(1, 100);
                        }

                    }
                    PrintMatrix(main, N);
                    Console.WriteLine();
                    PrintNum( main, N);
                    min(main, N);

                }
                else if (choose == 2)
                {
                    {
                        //контрольная матрица
                        int[,] controle = new int[N, N];
                        for (int index1 = 0; index1 < N; index1++)
                        {
                            for (int index2 = 0; index2 < N; index2++)
                            {
                                controle[index1, index2] = N * index1 + index2;
                            }

                        }
                        PrintMatrix(controle, N);
                        Console.WriteLine();
                        PrintNum(controle, N);
                        min(controle, N);

                    }
                }
                else
                    Console.WriteLine(" неможливий вибір");



            }

        }
    }
}
