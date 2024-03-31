using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4_BTVN2
{
    public struct HocSinh
    {
        public string ten;
        public int tuoi;
        public float dtb;
        public HocSinh(string Ten, int Tuoi, float DTB)
        {
            ten = Ten;
            tuoi = Tuoi;
            dtb = DTB;
        }
    }
    internal class Program
    {
        static List<HocSinh> danhSach = new List<HocSinh>();
        static void Main(string[] args)
        {
            Console.WriteLine("DANH SACH HOC SINH");
            Console.WriteLine("1. Them hoc sinh moi vao danh sach");
            Console.WriteLine("2. Hien thi danh sach hoc sinh");
            Console.WriteLine("3. Tim kiem hoc sinh theo ten");
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
                        addHocSinh();
                        break;
                    case 2:
                        HienThiDanhSach();
                        break;
                    case 3:
                        timHocSinh();
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

        static void addHocSinh()
        {
            Console.Write("Nhap ten hoc sinh: ");
            string Ten = Console.ReadLine();
            Console.Write("Nhap tuoi hoc sinh: ");
            //check tuoi
            int Tuoi;
            bool isNumeric = int.TryParse(Console.ReadLine(), out Tuoi);
            while (isNumeric == false || Tuoi < 1)
            {
                Console.Write("Vui long nhap lai so tuoi hop le: ");
                isNumeric = int.TryParse(Console.ReadLine(), out Tuoi);
            }
            Console.Write("Nhap diem trung binh cua hoc sinh: ");
            //check diem trung binh
            float DTB;
            bool isFloat = float.TryParse(Console.ReadLine(), out DTB);
            while (isFloat == false || DTB < 0 || DTB > 10)
            {
                Console.Write("Vui long nhap lai diem trung binh hop le: ");
                isFloat = float.TryParse(Console.ReadLine(), out DTB);
            }
            HocSinh hocSinh = new HocSinh(Ten, Tuoi, DTB);
            danhSach.Add(hocSinh);

            Console.WriteLine("Them hoc sinh moi thanh cong!");
        }

        static void HienThiDanhSach()
        {
            Console.WriteLine("\nDanh sach hoc sinh:");
            foreach (var hocSinh in danhSach)
            {
                Console.WriteLine($"Ten: {hocSinh.ten}, Tuoi: {hocSinh.tuoi}, Diem trung binh: {hocSinh.dtb}");
            }
        }

        static void timHocSinh()
        {
            Console.Write("Nhap ten hoc sinh: ");
            string Ten = Console.ReadLine();
            List<HocSinh> timKiem = new List<HocSinh>();
            foreach (var hocSinh in danhSach)
            {
                if (hocSinh.ten == Ten)
                {
                    timKiem.Add(hocSinh);
                }
            }

            if (timKiem.Count > 0)
            {
                Console.WriteLine("\nKet qua tim kiem:");
                foreach (var hocSinh in timKiem)
                {
                    Console.WriteLine($"Ten: {hocSinh.ten}, Tuoi: {hocSinh.tuoi}, Diem trung binh: {hocSinh.dtb}");
                }
            }
            else
            {
                Console.WriteLine("Khong co hoc sinh hop le.");
            }
        }
    }
}
