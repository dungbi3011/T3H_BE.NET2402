using Buoi8_BTVN1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public class Yeu_cau_chuong_trinh
    {
        List<NhanVien> luc_luong = new List<NhanVien> { };
        public void nhapThongTinFullTime(int n) // Tham so n. Nhap thong tin cua n nhan vien full-time
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin nhan vien full-time thu " + (i + 1) + ":");

                Console.Write("Ten nhan vien full-time: ");
                string hoTen = Console.ReadLine();

                Console.Write("Tuoi nhan vien full-time: ");
                string Tuoi = Console.ReadLine();

                Console.Write("Luong thang nhan vien full-time: ");
                string LuongThang = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(hoTen) == true && ValidationData.KiemTraInputSo(Tuoi) == true && ValidationData.KiemTraInputSo(LuongThang) == true) //Kiem tra thong tin
                {
                    int tuoi = Convert.ToInt32(Tuoi);
                    long luongThang = Convert.ToInt64(LuongThang);
                    FullTime full_time = new FullTime { HoTen = hoTen, Tuoi = tuoi, LuongThang = luongThang };
                    luc_luong.Add(full_time);
                    Console.WriteLine($"Nhap thong tin nhan vien full-time thu {i + 1} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin. Chuong trinh xin bo qua thong tin nhan vien full-time thu {i + 1}.");
                }
            }
        }

        public void nhapThongTinPartTime(int n) // Tham so n. Nhap thong tin cua n nhan vien part-time
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin nhan vien part-time thu " + (i + 1) + ":");

                Console.Write("Ten nhan vien part-time: ");
                string hoTen = Console.ReadLine();

                Console.Write("Tuoi nhan vien part-time: ");
                string Tuoi = Console.ReadLine();

                Console.Write("Luong theo gio cua nhan vien part-time: ");
                string LuongTheoGio = Console.ReadLine();

                Console.Write("So gio lam viec trong thang cua nhan vien part-time: ");
                string GioLamViec = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(hoTen) == true && ValidationData.KiemTraInputSo(Tuoi) == true && ValidationData.KiemTraInputSo(GioLamViec) == true) //Kiem tra thong tin
                {
                    int tuoi = Convert.ToInt32(Tuoi);
                    long luongTheoGio = Convert.ToInt64(LuongTheoGio);
                    int gioLamViec = Convert.ToInt32(GioLamViec);
                    PartTime part_time = new PartTime { HoTen = hoTen, Tuoi = tuoi, LuongTheoGio = luongTheoGio, GioLamViec = gioLamViec};
                    luc_luong.Add(part_time);
                    Console.WriteLine($"Nhap thong tin nhan vien part-time thu {i + 1} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin. Chuong trinh xin bo qua thong tin nhan vien part-time thu {i + 1}.");
                }
            }
        }

        public void nhapThongTinIntern(int n) // Tham so n. Nhap thong tin cua n thuc tap sinh
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin thuc tap sinh (TTS) thu " + (i + 1) + ":");

                Console.Write("Ten cua TTS: ");
                string hoTen = Console.ReadLine();

                Console.Write("Tuoi cua TTS: ");
                string Tuoi = Console.ReadLine();

                Console.Write("Luong ho tro theo thang cua TTS: ");
                string LuongHoTro = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(hoTen) == true && ValidationData.KiemTraInputSo(Tuoi) == true && ValidationData.KiemTraInputSo(LuongHoTro) == true) //Kiem tra thong tin
                {
                    int tuoi = Convert.ToInt32(Tuoi);
                    long luongHoTro = Convert.ToInt64(LuongHoTro);
                    Intern intern = new Intern { HoTen = hoTen, Tuoi = tuoi, LuongHoTro = luongHoTro };
                    luc_luong.Add(intern);
                    Console.WriteLine($"Nhap thong tin TTS thu {i + 1} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin. Chuong trinh xin bo qua thong tin TTS thu {i + 1}.");
                }
            }
        }

        public void hienThiNhanVien(string hoTen)
        {
            NhanVien nhan_vien = luc_luong.Find(n => n.HoTen == hoTen);
            if (nhan_vien != null)
            {
                nhan_vien.ThongTin();
            }
            else
            {
                Console.WriteLine("Khong tim thay nhan vien tuong ung.");
            }
        }

        public void xoaNhanVien(string hoTen)
        {
            NhanVien nhan_vien = luc_luong.Find(n => n.HoTen == hoTen);
            if (nhan_vien != null)
            {
                luc_luong.Remove(nhan_vien);
                Console.WriteLine($"Xoa nhan vien {nhan_vien.HoTen} thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay nhan vien tuong ung.");
            }
        }
    }
}
