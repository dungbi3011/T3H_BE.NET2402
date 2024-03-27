using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BTVN3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dem so lan xuat hien cua 1 ki tu trong chuoi\n");

            Console.Write("Vui long nhap 1 chuoi bat ki: ");
            string chuoi = Console.ReadLine();

            Console.Write("Vui long nhap 1 ki tu bat ki: ");
            string KiTu = Console.ReadLine();
            while (KiTu.Length > 1)
            {
                Console.Write("Vui long nhap lai 1 ki tu bat ki: ");
                KiTu = Console.ReadLine();
            }
            char Ki_Tu = KiTu.ToCharArray()[0];
            int count = demKiTu(chuoi, Ki_Tu);

            Console.WriteLine($"\nKi tu {Ki_Tu} xuat hien {count} lan trong chuoi duoc nhap.");
            Console.ReadKey();
    }

        static int demKiTu(string chuoi, char Ki_Tu)
        {
            int count = 0;

            foreach (char c in chuoi)
            {
                if (c == Ki_Tu)
                {
                    count++;
                }
            }

            return count;
    }
    }
}
