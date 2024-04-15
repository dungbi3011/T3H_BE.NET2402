using Buoi8_BTVN1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public class Program : Yeu_cau_chuong_trinh
    {
        Yeu_cau_chuong_trinh ChuongTrinh = new Yeu_cau_chuong_trinh();
        public void Implement()
        {
            Console.WriteLine("---------CHUONG TRINH QUAN LY NHAN VIEN (FULLTIME, PARTTIME, INTERN)---------");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Nhap thong tin nhan vien full-time.");
            Console.WriteLine("2. Nhap thong tin nhan vien part-time.");
            Console.WriteLine("3. Nhap thong tin thuc tap sinh (TTS).");
            Console.WriteLine("4. Tim kiem nhan vien.");
            Console.WriteLine("5. Sa thai nhan vien.");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            // Viết menu chương trình 
            while (true)
            {
                Console.Write("\nChon mot chuc nang (nhap so tu 0-5): ");
                int luachon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                while (isNumeric == false || luachon < 0 || luachon > 5)
                {
                    Console.Write("Vui long nhap lai lua chon chuc nang (0-5): ");
                    isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                }

                switch (luachon)
                {
                    case 1:
                        Console.WriteLine("Bat dau nhap thong tin cho NV Full-time.");
                        Console.Write("So NV full-time can nhap: ");
                        string nf = Console.ReadLine();
                        while (!ValidationData.KiemTraInputSo(nf))
                        {
                            Console.Write("Vui long nhap lai so NV full-time can nhap: ");
                            nf = Console.ReadLine();
                        }
                        ChuongTrinh.nhapThongTinFullTime(Convert.ToInt32(nf));
                        Console.WriteLine("Hoan thanh chuong trinh nhap thong tin NV full-time.");
                        break;
                    case 2:
                        Console.WriteLine("Bat dau nhap thong tin cho NV Part-time.");
                        Console.Write("So NV part-time can nhap: ");
                        string np = Console.ReadLine();
                        while (!ValidationData.KiemTraInputSo(np))
                        {
                            Console.Write("Vui long nhap lai so NV part-time can nhap: ");
                            np = Console.ReadLine();
                        }
                        ChuongTrinh.nhapThongTinPartTime(Convert.ToInt32(np));
                        Console.WriteLine("Hoan thanh chuong trinh nhap thong tin NV part-time.");
                        break;
                    case 3:
                        Console.WriteLine("Bat dau nhap thong tin cho TTS.");
                        Console.Write("So TTS can nhap: ");
                        string ni = Console.ReadLine();
                        while (!ValidationData.KiemTraInputSo(ni))
                        {
                            Console.Write("Vui long nhap lai so TTS can nhap: ");
                            ni = Console.ReadLine();
                        }
                        ChuongTrinh.nhapThongTinIntern(Convert.ToInt32(ni));
                        Console.WriteLine("Hoan thanh chuong trinh nhap thong tin TTS.");
                        break;
                    case 4:
                        Console.WriteLine("Bat dau tim kiem nhan vien.");
                        Console.Write("Ho ten nhan vien can tim: ");
                        string hoTenNhanVienTimKiem = Console.ReadLine();
                        while (!ValidationData.KiemTraInputChu(hoTenNhanVienTimKiem))
                        {
                            Console.Write("Vui long nhap lai ho ten cua NV can tim: ");
                            hoTenNhanVienTimKiem = Console.ReadLine();
                        }
                        hienThiNhanVien(hoTenNhanVienTimKiem);
                        Console.WriteLine("Hoan thanh chuong trinh tim kiem nhan vien.");
                        break;
                    case 5:
                        Console.WriteLine("Bat dau sa thai nhan vien.");
                        Console.Write("Ho ten nhan vien can sa thai: ");
                        string hoTenNhanVienSaThai = Console.ReadLine();
                        while (!ValidationData.KiemTraInputChu(hoTenNhanVienSaThai))
                        {
                            Console.Write("Vui long nhap lai ho ten cua NV can sa thai: ");
                            hoTenNhanVienSaThai = Console.ReadLine();
                        }
                        xoaNhanVien(hoTenNhanVienSaThai);
                        Console.WriteLine("Hoan thanh chuong trinh sa thai nhan vien.");
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
