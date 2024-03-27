using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int month = 1; month <= 12; month++)
            {
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        Console.WriteLine($"Thang {month} co 31 ngay.");
                        break;
                    case 2:
                        Console.WriteLine("Thang 2 co 28-29 ngay.");
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        Console.WriteLine($"Thang {month} có 30 ngay.");
                        break;
                    default:
                        Console.WriteLine("Khong co thang nay trong nam.");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
