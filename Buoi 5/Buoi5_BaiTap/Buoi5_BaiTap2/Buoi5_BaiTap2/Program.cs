using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_BaiTap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Nhap va check ngay sinh hop le
            Console.Write("Nhap ngay sinh cua ban: ");
            int ngay_sinh;
            bool isNumeric1 = int.TryParse(Console.ReadLine(), out ngay_sinh);
            while (isNumeric1 == false || ngay_sinh < 1 || ngay_sinh > 31)
            {
                Console.Write("Vui long nhap lai ngay sinh: ");
                isNumeric1 = int.TryParse(Console.ReadLine(), out ngay_sinh);
            }

            //Nhap va check thang sinh hop le
            Console.Write("Nhap thang sinh cua ban: ");
            int thang_sinh;
            bool isNumeric2 = int.TryParse(Console.ReadLine(), out thang_sinh);

            while (isNumeric2 == false || thang_sinh < 1 || thang_sinh > 12)
            {
                Console.Write("Vui long nhap lai ngay sinh: ");
                isNumeric2 = int.TryParse(Console.ReadLine(), out thang_sinh);
            }

            //Nhap va check nam sinh hop le
            Console.Write("Nhap nam sinh cua ban: ");
            int nam_sinh;
            bool isNumeric3 = int.TryParse(Console.ReadLine(), out nam_sinh);

            while (isNumeric3 == false || nam_sinh < 1900 || nam_sinh > 2024)
            {
                Console.Write("Vui long nhap lai ngay sinh: ");
                isNumeric3 = int.TryParse(Console.ReadLine(), out nam_sinh);
            }

            //ngay thang nam sinh cua ban
            DateTime ngay_thang_nam_sinh = new DateTime(nam_sinh, thang_sinh, ngay_sinh);
            //Khoang thoi gian toi hien tai
            TimeSpan interval = (DateTime.Now) - ngay_thang_nam_sinh;
            Console.WriteLine("\n");
            Console.WriteLine("Ban da song duoc: " + Convert.ToInt32((DateTime.Now).Year - ngay_thang_nam_sinh.Year) + " nam.");
            Console.WriteLine("Ban da song duoc: " + Convert.ToInt32(interval.TotalHours) + " gio.");
            Console.WriteLine("Ban da song duoc: " + Convert.ToInt32(interval.TotalMinutes) + " phut.");
            Console.WriteLine("Ban da song duoc: " + Convert.ToInt32(interval.TotalSeconds) + " giay.");
            Console.ReadKey();
        }
    }
}
