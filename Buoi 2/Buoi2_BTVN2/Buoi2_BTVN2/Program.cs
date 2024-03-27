using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_BTVN2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao 1 chuoi bat ki, roi output la dao nguoc cua chuoi do\n");

            Console.Write("Nhap vao 1 chuoi: ");
            string chuoi = Console.ReadLine();

            char[] KiTuChuoi = chuoi.ToCharArray();
            Array.Reverse(KiTuChuoi); //đảo ngược chuỗi kí tự
            string chuoi_dao_nguoc = new string(KiTuChuoi);

            Console.WriteLine("\nChuoi sau khi dao nguoc: " + chuoi_dao_nguoc);
            Console.ReadKey();
        }
    }
}
