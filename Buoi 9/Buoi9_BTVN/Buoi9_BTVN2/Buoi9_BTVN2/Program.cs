using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN2
{
    public class Program : StudentRegister
    {
        StudentRegister ChuongTrinh = new StudentRegister();
        public void Implement()
        {
            Console.WriteLine("---------HE THONG DANG KI KHOA HOC---------");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Nhap lieu cho N khoa hoc.");
            Console.WriteLine("2. Dang ki hoc cho tung hoc vien; Tinh chiet khau hoc phi dua vao thoi gian dang ki.");
            Console.WriteLine("3. Hien thi danh sach hoc vien dang ki (muc giam gia tu cao -> thap).");
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
                        Console.WriteLine("Bat dau chuong trinh nhap N du lieu cho khoa hoc.");
                        Console.Write("Nhap vao so khoa hoc can nhap: ");
                        string N = Console.ReadLine();
                        while (!int.TryParse(N, out int soKhoaHoc))
                        {
                            Console.Write("Vui long nhap lai so san pham can nhap: ");
                            N = Console.ReadLine();
                        }
                        ChuongTrinh.NhapThongTinKhoaHoc(Convert.ToInt32(N));
                        Console.WriteLine("Hoan thanh chuong trinh nhap lieu khoa hoc.");
                        break;
                    case 2:
                        Console.WriteLine("Bat dau chuong trinh Dang ki khoa hoc.");
                        Console.Write("Nhap ten khoa hoc muon dang ki: ");
                        string tenKhoaHoc = Console.ReadLine();
                        while (!ValidationData.KiemTraInputChu(tenKhoaHoc))
                        {
                            Console.Write("Vui long nhap lai ten khoa hoc: ");
                            tenKhoaHoc = Console.ReadLine();
                        }
                        Course khoaHoc = ChuongTrinh.TimKhoaHoc(tenKhoaHoc);
                        if (khoaHoc != null) {
                            ChuongTrinh.DangKiKhoaHoc(khoaHoc);
                        } else {
                            Console.WriteLine("Khong tim thay khoa hoc tuong ung de dang ki.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Bat dau chuong trinh hien thi danh sach hoc vien dang ki (muc giam gia cao -> thap).");
                        ChuongTrinh.HienThiHocSinhDangKiKhoaHoc();
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
