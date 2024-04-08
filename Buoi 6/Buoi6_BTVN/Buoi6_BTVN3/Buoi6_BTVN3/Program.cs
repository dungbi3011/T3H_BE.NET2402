using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6_BTVN3
{
    internal class Program
    {
        // Generic Method ten Swap de hoan doi 2 gia tri
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void Main()
        {
            // Doi cho 2 so nguyen a va b
            int a = 69, b = 96;
            Console.WriteLine($"Truoc khi doi cho 2 gia tri thi a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"Sau khi doi cho 2 gia tri thi a = {a}, b = {b}");

            // Doi cho 2 chuoi string
            string s1 = "Hoan", s2 = "Doi";
            Console.WriteLine($"Truoc khi doi cho 2 gia tri thi s1 = {s1}, s2 = {s2}");
            Swap(ref s1, ref s2);
            Console.WriteLine($"Sau khi doi cho 2 gia tri thi a = {s1}, b = {s2}");

            Console.ReadKey();
        }
    }
}
