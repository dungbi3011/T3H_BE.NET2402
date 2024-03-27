using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BTVN5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Su dung do-while de doan 1 so ngau nhien tu 1 toi 100 bang cach so sanh dap an\n");
            Random random = new Random();
            int randomNumber = random.Next(1, 100); // Số ngẫu nhiên từ 1 đến 100

            int guessedNumber;
            do
            {
                Console.Write("Nhap 1 so tu 1 toi 100: ");
                bool isNumeric = int.TryParse(Console.ReadLine(), out guessedNumber);

                while (isNumeric == false || guessedNumber < 1 || guessedNumber > 100)
                {
                    Console.Write("Vui long nhap lai 1 so tu 1 toi 100: ");
                    isNumeric = int.TryParse(Console.ReadLine(), out guessedNumber);
                }

                if (guessedNumber > randomNumber)
                {
                    Console.WriteLine("Hay thu so be hon.");
                }
                else if (guessedNumber < randomNumber)
                {
                    Console.WriteLine("Hay thu so lon hon.");
                }
            } while (guessedNumber != randomNumber);

            Console.WriteLine("Chuc mung ban da doan dung!!!");
            Console.ReadKey();
        }
    }
}
