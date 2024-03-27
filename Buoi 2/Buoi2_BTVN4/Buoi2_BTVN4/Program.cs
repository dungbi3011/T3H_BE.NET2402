using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BTVN4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Su dung do-while de tinh giai thua cua 1 so\n");
            Console.Write("Nhap mot so tu nhien tu 1 den 1000000: ");
            int number;
            bool isNumeric = int.TryParse(Console.ReadLine(), out number);

            while (isNumeric == false || number > 1000000 || number < 1)
            {
                Console.Write("Vui long nhap lai mot so tu nhien tu 1 den 1000000: ");
                isNumeric = int.TryParse(Console.ReadLine(), out number);
            }

            if (isNumeric & (number <= 1000000 || number >= 1))
            {
                long factorial = Factorial(number);
                Console.WriteLine($"Giai thua cua {number} la {factorial}.");
            }
            Console.ReadKey();
        }

        static long Factorial(int number)
        {
            long result = 1;
            int i = 1;

            do
            {
                result *= i;
                i++;
            } while (i <= number);

            return result;
        }
    }
}
