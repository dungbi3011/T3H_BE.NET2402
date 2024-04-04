using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_BaiTap4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //nhap username = password = "admin"
            Console.Write("Vui long nhap username: ");
            string username = Console.ReadLine();
            Console.Write("Vui long nhap password: ");
            string password = Console.ReadLine();
            while (String.Compare(username, "admin") != 0 || String.Compare(password, "admin") != 0)
            {
                Console.WriteLine("Username hoac password khong hop le.");
                Console.Write("Vui long nhap lai username: ");
                username = Console.ReadLine();
                Console.Write("Vui long nhap lai password: ");
                password = Console.ReadLine();
            }
            Console.WriteLine("Chao mung ban den voi chuong trinh.");
            Console.ReadKey();
        }
    }
}
