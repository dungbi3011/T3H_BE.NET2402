using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_BTVN2
{
    public struct Product
    {
        public string name;
        public float price;
        public DateTime expiredDate;

        // Kiem tra ExpiredDate
        public bool Expire()
        {
            return (expiredDate - DateTime.Now).TotalDays < 180;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.Write("Nhap so luong san pham: ");
            //Check so luong san pham
            int number;
            bool isNumeric = int.TryParse(Console.ReadLine(), out number);
            while (isNumeric == false)
            {
                Console.Write("Vui long nhap lai so luong san pham: ");
                isNumeric = int.TryParse(Console.ReadLine(), out number);
            }

            for (int i = 0; i < number; i++)
            {
                Product product = new Product();
                Console.WriteLine();
                //Ten san pham
                Console.Write("Nhap ten san pham: ");
                product.name = Console.ReadLine();

                //Check gia san pham
                Console.Write("Nhap gia san pham: "); 
                float price;
                bool isFloat = float.TryParse(Console.ReadLine(), out price);
                while (isFloat == false)
                {
                    Console.Write("Vui long nhap lai gia san pham: ");
                    isFloat = float.TryParse(Console.ReadLine(), out price);
                }
                product.price = price;

                //Check ngay het han
                Console.Write("Nhap ngay het han cua san pham (MM/dd/yyyy): ");
                DateTime temp;
                bool isDateTime = DateTime.TryParse(Console.ReadLine(), out temp);
                while (isDateTime == false)
                {
                    Console.Write("Vui long nhap lai Ngay het han (MM/dd/yyyy): ");
                    isDateTime = DateTime.TryParse(Console.ReadLine(), out temp);
                }
                product.expiredDate = temp;

                products.Add(product);
            }

            Console.WriteLine("\nSan pham co ngay het han <= 30 ngày: ");
            foreach (var product in products)
            {
                if (product.Expire())
                {
                    if ((product.expiredDate - DateTime.Now).TotalDays <= 30)
                    {
                        Console.WriteLine($"Ten san pham: {product.name} - Gia: {product.price} - Ngay het han: {product.expiredDate:dd/MM/yyyy}");
                    }
                }
            }

            Console.WriteLine("\nSan pham co ten dai hon 10 ky tu: ");
            foreach (var product in products)
            {
                if (product.name.Length > 10)
                {
                    Console.WriteLine($"Ten san pham: {product.name} - Gia: {product.price} - Ngay het han: {product.expiredDate:dd/MM/yyyy}");
                }
            }
            Console.ReadKey();
        }
    }
}
