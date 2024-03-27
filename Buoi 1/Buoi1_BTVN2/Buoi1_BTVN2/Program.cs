using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1_BTVN2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh tong cac so chan nho hon so N duoc nhap tu ban phim");

            Console.WriteLine("So N:");
            int N = Convert.ToInt32(Console.ReadLine());

            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Tong cua cac so chan nho hon N:");
            Console.WriteLine(sum);

            Console.ReadKey();
        }
    }
}
