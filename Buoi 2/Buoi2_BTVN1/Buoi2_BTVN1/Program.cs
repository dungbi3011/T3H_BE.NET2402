using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BTVN1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hien thi cac so nguyen to nho hon so n duoc nhap tu ban phim\n");

            Console.Write("So n: ");
            int n;
            bool isNumeric = int.TryParse(Console.ReadLine(), out n);

            while (isNumeric == false || n < 1 || n > 1000000) {
                Console.Write("Vui long nhap lai so tu nhien n tu 1 den 1000000:");
                isNumeric = int.TryParse(Console.ReadLine(), out n);
            }

            if (isNumeric & (n <= 1000000 || n >= 1))
            {
                Console.Write("Cac so nguyen to nho hon n: ");
                for (int i = 2; i < n; i++)
                {
                    if (checkPrime(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            Console.ReadKey();
        }
        static bool checkPrime(int n) {
            for (int i = 2; i <= n/2; i++) {
                if (n % i == 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
