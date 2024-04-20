using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN3
{
    public class Program : ProductManager
    {
        ProductManager ChuongTrinh = new ProductManager();
        public void Implement()
        {
            Console.WriteLine("---------CHUONG TRINH QUAN LY SAN PHAM---------");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Nhap lieu cho N san pham.");
            Console.WriteLine("2. Tim va Them san pham vao gio hang.");
            Console.WriteLine("3. Hien thi thong tin danh sach don hang (mua tren 5 san pham se duoc chiet khau 5%).");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            // Viết menu chương trình 
            while (true)
            {
                Console.Write("\nChon mot chuc nang (nhap so tu 0-3): ");
                int luachon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                while (isNumeric == false || luachon < 0 || luachon > 3)
                {
                    Console.Write("Vui long nhap lai lua chon chuc nang (0-3): ");
                    isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                }

                switch (luachon)
                {
                    case 1:
                        Console.WriteLine("Bat dau chuong trinh nhap du lieu cho san pham.");
                        Console.Write("Nhap vao so san pham can nhap: ");
                        string N = Console.ReadLine();
                        while (!int.TryParse(N, out int soSanPham))
                        {
                            Console.Write("Vui long nhap lai so san pham can nhap: ");
                            N = Console.ReadLine();
                        }
                        ChuongTrinh.NhapThongTinSanPham(Convert.ToInt32(N));
                        Console.WriteLine("Hoan thanh chuong trinh nhap lieu san pham.");
                        break;
                    case 2:
                        Console.WriteLine("Bat dau chuong trinh Tim va Them san pham vao gio hang.");
                        Console.Write("Nhap ten san pham can tim: ");
                        string tenSanPham = Console.ReadLine();
                        while (!ValidationData.KiemTraInputChu(tenSanPham))
                        {
                            Console.Write("Vui long nhap lai ten san pham: ");
                            tenSanPham = Console.ReadLine();
                        }
                        Product sanPhamTimKiem = ChuongTrinh.SearchProduct(tenSanPham);
                        if (sanPhamTimKiem != null) {
                            BuyProducts(sanPhamTimKiem);
                            Console.WriteLine("Them san pham vao gio hang thanh cong!");
                        } else {
                            Console.WriteLine("Khong tim thay san pham tuong ung.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Bat dau chuong trinh hien thi danh sach don hang.");
                        ChuongTrinh.DisplayOrders();
                        break;
                    case 0:
                        Console.WriteLine("Moi ban ra khoi chuong trinh.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Program program = new Program();
            program.Implement();

            Console.ReadKey();
        }
    }
}
