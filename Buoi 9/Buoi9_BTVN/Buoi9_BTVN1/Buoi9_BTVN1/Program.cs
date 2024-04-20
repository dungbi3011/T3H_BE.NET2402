using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN1
{
    public class Program : ProductManagerImpl
    {
        ProductManagerImpl ChuongTrinh = new ProductManagerImpl();
        public void Implement()
        {
            Console.WriteLine("---------CHUONG TRINH QUAN LY SAN PHAM---------");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Nhap lieu cho N san pham.");
            Console.WriteLine("2. Hien thi san pham theo Loai chiet khau (1 - Theo tien; 2 - Theo phan tram).");
            Console.WriteLine("3. Sap xep & Hien thi san pham theo Gia tri chiet khau giam dan.");
            Console.WriteLine("4. Tim kiem san pham theo ten.");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            // Viết menu chương trình 
            while (true)
            {
                Console.Write("\nChon mot chuc nang (nhap so tu 0-4): ");
                int luachon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                while (isNumeric == false || luachon < 0 || luachon > 4)
                {
                    Console.Write("Vui long nhap lai lua chon chuc nang (0-4): ");
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
                        Console.WriteLine("Bat dau chuong trinh hien thi san pham theo Loai chiet khau tuong ung.");
                        Console.Write("Nhap Loai chiet khau can hien thi (1 - Theo tien; 2 - Theo phan tram): ");
                        string loaiChietKhau = Console.ReadLine();
                        while (!ValidationData.KiemTraInputLoaiChietKhau(loaiChietKhau))
                        {
                            Console.Write("Vui long nhap lai loai chiet khau (1 - Theo tien; 2 - Theo phan tram): ");
                            loaiChietKhau = Console.ReadLine();
                        }
                        ChuongTrinh.HienThiTheoLoaiChietKhau(Convert.ToInt32(loaiChietKhau));
                        break;
                    case 3:
                        Console.WriteLine("Bat dau chuong trinh hien thi san pham theo thu tu Gia chiet khau giam dan.");
                        ChuongTrinh.HienThiTheoGiaChietKhauGiamDan();
                        break;
                    case 4:
                        Console.WriteLine("Bat dau chuong trinh tim kiem san pham theo ten.");
                        Console.Write("Nhap vao ten san pham can tim: ");
                        string ten = Console.ReadLine();
                        while (!ValidationData.KiemTraInputChu(ten))
                        {
                            Console.Write("Vui long nhap lai ten san pham can tim: ");
                            ten = Console.ReadLine();
                        }
                        ChuongTrinh.TimKiemTheoTen(ten);
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
