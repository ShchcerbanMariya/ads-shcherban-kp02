using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.Write("Wrte x: ");
            double x=double.Parse(Console.ReadLine());

            Console.Write("Wrte y: ");
            double y=double.Parse(Console.ReadLine());

            Console.Write("Wrte z: ");
            double z=double.Parse(Console.ReadLine());

            if (z==0)
            Console.WriteLine("Error");
            else
            {
            if (Math.Sin(Math.PI+x)==0)
            Console.WriteLine("Error");
            else 
            {
            double a = Math.Pow(Math.Sin((x+y)/z), 2)/(2*Math.Sin(Math.PI+x));
                if (a==0)
                Console.WriteLine("Error");
                else 
                {
                    if (x<0 && a%1!=0)
                    Console.WriteLine("Error");
                    else 
                    {
                        if(a+z<=0)
                        Console.WriteLine("Error");
                        else {
                        double b = Math.Log(a+z)/(a*a)+1/Math.Pow(x,a);
                        Console.WriteLine("a={0}, b={1}", a, b);
                        }
                    }
                }

            }
            }
        }
    }
}
