using System;

namespace task2
{
    class Program
    {
         static int countdays (int m, int d)
         {
            int result=0;
        
            for (int i=1; i<m; i++) 
                {
                    if (i==2)
                        result += 28;
                    else 
                        result += monthdays(i);
                }
            return result+d;
            
         }
               
        static int monthdays (int m)
        {
            if (m >=8)
                m++;
            if (m % 2 == 1)
                return 31;
            else
                return 30;
        }
        static bool checkInput(int d, int m)
        {
            if (d>0 && d<=31 && m>0 && m<=12)
            {
                if (m==2 && d<29)
                    return true;
                else  
                {
                    if (m==2 && d>28)
                        return false;
                    if (d<=monthdays(m))
                        return true;
                    else 
                        return false;
                }
            }
            else 
                return false;
            
        }
        static void Main(string[] args)
        {
            Console.Write("Write the day ");
            int d = int.Parse(Console.ReadLine());

            Console.Write("Write the month ");
            int m = int.Parse(Console.ReadLine());

                                        
            bool check = checkInput(d, m);
            if (check == false)
                Console.WriteLine("Incorrect input");
            else
            {
               
                int week = countdays(m,d)%7;
                

                if (week == 1)
                    Console.WriteLine("{0}.{1} is wednesday", d,m);
                else if (week == 2)
                    Console.WriteLine("{0}.{1} is thursday", d,m);
                else if (week == 3)
                    Console.WriteLine("{0}.{1} is friday", d,m);
                else if (week == 4)
                    Console.WriteLine("{0}.{1} is saturday", d,m);
                else if (week == 5)
                    Console.WriteLine("{0}.{1} is sunday", d,m);
                else if (week == 6)
                    Console.WriteLine("{0}.{1} is monday", d,m);
                else Console.WriteLine("{0}.{1} is tuesday", d,m);
                                               
                }

            


                

        }
    }
}
