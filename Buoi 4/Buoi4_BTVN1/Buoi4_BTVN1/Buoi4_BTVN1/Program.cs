using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4_BTVN1
{
    public struct Sach
    {
        public string tieu_de;
        public string tac_gia;
        public int nxb;
        public Sach(string tieuDe, string tacGia, int NXB)
        {
            tieu_de = tieuDe;
            tac_gia = tacGia;
            nxb = NXB;
        }
    }
    internal class Program
    {
        static List<Sach> thuVien = new List<Sach>();
        static void Main(string[] args)
        {
            Console.WriteLine("THU VIEN SACH");
            Console.WriteLine("1. Them sach moi vao thu vien");
            Console.WriteLine("2. Hien thi thu vien sach");
            Console.WriteLine("3. Tim kiem sach theo tieu de");
            Console.WriteLine("4. Thoat chuong trinh");
            bool chuong_trinh = true;
            while (chuong_trinh)
            {
                Console.Write("\nNhap lua chon cua ban (1-4): ");
                //Lua chon cua nguoi dung
                int lua_chon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out lua_chon);

                while (isNumeric == false || lua_chon < 1 || lua_chon > 4)
                {
                    Console.Write("Vui long nhap lai so tu nhien tu 1 den 4: ");
                    isNumeric = int.TryParse(Console.ReadLine(), out lua_chon);
                }

                switch (lua_chon)
                {
                    case 1:
                        addSach();
                        break;
                    case 2:
                        HienThiThuVien();
                        break;
                    case 3:
                        timSach();
                        break;
                    case 4:
                        chuong_trinh = false;
                        Console.WriteLine("Moi ban ra ngoai!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }

        static void addSach()
        {
            Console.Write("Nhap tieu de sach: ");
            string tieuDe = Console.ReadLine();
            Console.Write("Nhap ten tac gia: ");
            string tacGia = Console.ReadLine();
            Console.Write("Nhap nam xuat ban: ");
            //check nam xuat ban
            int NXB;
            bool isNumeric = int.TryParse(Console.ReadLine(), out NXB);
            while (isNumeric == false || NXB < 1 || NXB > 2024)
            {
                Console.Write("Vui long nhap lai nam xuat ban hop le: ");
                isNumeric = int.TryParse(Console.ReadLine(), out NXB);
            }
            Sach sachMoi = new Sach(tieuDe, tacGia, NXB);
            thuVien.Add(sachMoi);

            Console.WriteLine("Them sach moi thanh cong!");
        }

        static void HienThiThuVien()
        {
            Console.WriteLine("\nThu vien Sach:");
            foreach (var sach in thuVien)
            {
                Console.WriteLine($"Tieu de: {sach.tieu_de}, Tac gia: {sach.tac_gia}, Nam xuat ban: {sach.nxb}");
            }
        }

        static void timSach()
        {
            Console.Write("Nhap tieu de sach: ");
            string TieuDe = Console.ReadLine();
            List<Sach> timKiem = new List<Sach>();
            foreach (var sach in thuVien)
            {
                if (sach.tieu_de == TieuDe)
                {
                    timKiem.Add(sach);
                }
            }

            if (timKiem.Count > 0)
            {
                Console.WriteLine("\nKet qua tim kiem:");
                foreach (var sach in timKiem)
                {
                    Console.WriteLine($"Tieu de: {sach.tieu_de}, Tac gia: {sach.tac_gia}, Nam xuat ban: {sach.nxb}");
                }
            }
            else
            {
                Console.WriteLine("Khong co sach hop le.");
            }
        }
    }
}
