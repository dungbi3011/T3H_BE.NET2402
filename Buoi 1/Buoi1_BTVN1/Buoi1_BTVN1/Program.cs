using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1_BTVN1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tong 2 so X va Y duoc nhap tu ban phim:");
            Console.WriteLine("So X:");
            int X = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("So Y:");
            int Y = Convert.ToInt32(Console.ReadLine());

            int sum = X + Y;
            Console.WriteLine("Tong cua X va Y:");
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}


