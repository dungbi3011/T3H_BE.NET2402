using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BTVN6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Su dung do-while de kiem tra mat khau duoc nhap tu ban phim (co 6-12 ki tu va dau @)\n");
            string password;
            do
            {
                Console.Write("Nhap mat khau tu 6 toi 12 ki tu (co chua dau @): ");
                password = Console.ReadLine();
            } while (!IsValid(password));

            Console.WriteLine("Mat khau hop le.");
            Console.ReadKey();
        }

        static bool IsValid(string password)
        {
            if (password.Length < 6 || password.Length > 12)
            {
                return false;
            }

            if (!password.Contains("@"))
            {
                return false;
            }

            return true;
        }
    }
}
