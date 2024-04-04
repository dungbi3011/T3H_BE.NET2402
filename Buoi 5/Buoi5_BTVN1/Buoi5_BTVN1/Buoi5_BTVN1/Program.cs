using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buoi5_BTVN1
{
    public class NhanVien
    {
        public string id { get; set; }
        public string hoDem { get; set; }
        public string ten { get; set; }
        public DateTime ngaySinh { get; set; }
        public DateTime ngayVaoLam { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> danhSach = nhapDanhSach(); //buoc 1
            Console.WriteLine();
            danhSach = sapXep(danhSach); //buoc 3
            Console.WriteLine();
            hienThiDanhSach(danhSach); //buoc 2
            Console.WriteLine();
            hienThiHon5Nam(danhSach); //buoc 4
            Console.ReadKey();
        }

        static List<NhanVien> nhapDanhSach()
        {
            List<NhanVien> danhSach = new List<NhanVien>();
            Console.Write("Nhap so luong nhan vien: ");
            //Check so luong nhan vien
            int number;
            bool isNumeric = int.TryParse(Console.ReadLine(), out number);
            while (isNumeric == false)
            {
                Console.Write("Vui long nhap lai so luong nhan vien: ");
                isNumeric = int.TryParse(Console.ReadLine(), out number);
            }

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("\nNhap vao danh sach nhan vien thu " + (i+1) + ":");
                NhanVien nv = new NhanVien();
                //Ma nhan vien
                Console.Write("Nhap ma nhan vien: ");
                nv.id = Console.ReadLine();
                
                //Check ho dem
                Console.Write("Nhap ho dem: ");
                nv.hoDem = Console.ReadLine();
                bool isString1 = Regex.IsMatch(nv.hoDem, @"^[A-Za-z\s]*$"); //chi chua chu cai va dau cach
                while (isString1 == false)
                {
                    Console.Write("Vui long nhap lai Ho Dem cua nhan vien: ");
                    nv.hoDem = Console.ReadLine();
                    isString1 = Regex.IsMatch(nv.hoDem, @"^[A-Za-z\s]*$");
                }

                //Check ten
                Console.Write("Nhap ten: ");
                nv.ten = Console.ReadLine();
                bool isString2 = Regex.IsMatch(nv.ten, @"^[A-Za-z\s]*$"); //chi chua chu cai va dau cach
                while (isString2 == false)
                {
                    Console.Write("Vui long nhap lai ten cua nhan vien: ");
                    nv.ten = Console.ReadLine();
                    isString2 = Regex.IsMatch(nv.ten, @"^[A-Za-z\s]*$");
                }

                //Ngay sinh nhan vien
                Console.Write("Nhap ngay sinh (MM/dd/yyyy): ");
                DateTime temp1;
                bool isDateTime1 = DateTime.TryParse(Console.ReadLine(), out temp1);
                while (isDateTime1 == false)
                {
                    Console.Write("Vui long nhap lai Ngay sinh cua nhan vien: ");
                    isDateTime1 = DateTime.TryParse(Console.ReadLine(), out temp1);
                }
                nv.ngaySinh = temp1;

                //Ngay vao lam cua nhan vien
                Console.Write("Nhap ngay vao lam (MM/dd/yyyy): ");
                DateTime temp2;
                bool isDateTime2 = DateTime.TryParse(Console.ReadLine(), out temp2);
                while (isDateTime2 == false)
                {
                    Console.Write("Vui long nhap lai Ngay vao lam cua nhan vien: ");
                    isDateTime2 = DateTime.TryParse(Console.ReadLine(), out temp2);
                }
                nv.ngayVaoLam = temp2;

                //Them nhan vien vao danh sach
                danhSach.Add(nv);
            }

            return danhSach;
        }

        static void hienThiDanhSach(List<NhanVien> danhSach)
        {
            Console.WriteLine("Danh sach nhan vien (thu tu giam dan):");
            foreach (NhanVien nv in danhSach)
            {
                Console.WriteLine($"{nv.id} - {nv.hoDem} {nv.ten} - {nv.ngaySinh:dd/MM/yyyy} - {nv.ngayVaoLam:dd/MM/yyyy}");
            }
        }

        static List<NhanVien> sapXep(List<NhanVien> danhSach)
        {
            return danhSach.OrderByDescending(nv => nv.ngaySinh).ToList();
        }

        static void hienThiHon5Nam(List<NhanVien> danhSach)
        {
            Console.WriteLine("Danh sach nhan vien lam viec >= 5 nam:");
            foreach (NhanVien nv in danhSach)
            {
                if ((DateTime.Now.Year - nv.ngayVaoLam.Year) >= 5)
                {
                    Console.WriteLine($"{nv.id} - {nv.hoDem} {nv.ten} - {nv.ngaySinh:dd/MM/yyyy} - {nv.ngayVaoLam:dd/MM/yyyy}");
                }
            }
        }
    }
}
