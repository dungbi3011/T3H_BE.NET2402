using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN2
{
    public class Yeu_cau_chuong_trinh
    {
        List<Product> khoHang = new List<Product> { };
        List<Product> gioHang = new List<Product> { };
        public void nhapHangDienTu() // Nhap 2 san pham Hang Dien Tu.
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Nhap thong tin Hang Dien Tu thu " + (i + 1) + ":");

                Console.Write("Ma hang: ");
                string maHang = Console.ReadLine();

                Console.Write("Ten hang: ");
                string TenHang = Console.ReadLine();

                Console.Write("Gia tien: ");
                string giaTien = Console.ReadLine();

                Console.Write("Ngay san xuat (mm-dd-yy): ");
                string ngaySanXuat = Console.ReadLine();

                Console.Write("Ngay het han (mm-dd-yy): ");
                string ngayHetHan = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(maHang) == true && ValidationData.KiemTraInputChu(TenHang) == true && ValidationData.KiemTraInputChu(giaTien) == true && ValidationData.KiemTraInputChu(ngaySanXuat) == true && ValidationData.KiemTraInputChu(ngayHetHan) == true && ValidationData.KiemTraInputSo(maHang) == true && ValidationData.KiemTraInputDateQuaKhu(ngaySanXuat) == true && ValidationData.KiemTraInputDateTuongLai(ngayHetHan) == true) //Kiem tra thong tin
                {
                    int MaHang = Convert.ToInt32(maHang);
                    double GiaTien = Convert.ToDouble(giaTien);
                    DateTime NgaySanXuat = DateTime.Parse(ngaySanXuat);
                    DateTime NgayHetHan = DateTime.Parse(ngayHetHan);
                    HangDienTu hangDienTu = new HangDienTu(MaHang, TenHang, GiaTien, NgaySanXuat, NgayHetHan);
                    khoHang.Add(hangDienTu);
                    Console.WriteLine($"Nhap san pham Hang Dien Tu thu {i + 1} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin cua Hang Dien Tu thu {i + 1}.");
                }
            }
        }

        public void nhapHangThucPham() // Nhap 2 san pham Hang Dien Tu.
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Nhap thong tin Hang Thuc Pham thu " + (i + 1) + ":");

                Console.Write("Ma hang: ");
                string maHang = Console.ReadLine();

                Console.Write("Ten hang: ");
                string TenHang = Console.ReadLine();

                Console.Write("Gia tien: ");
                string giaTien = Console.ReadLine();

                Console.Write("Ngay san xuat (mm-dd-yy): ");
                string ngaySanXuat = Console.ReadLine();

                Console.Write("Ngay het han (mm-dd-yy): ");
                string ngayHetHan = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(maHang) == true && ValidationData.KiemTraInputChu(TenHang) == true && ValidationData.KiemTraInputChu(giaTien) == true && ValidationData.KiemTraInputChu(ngaySanXuat) == true && ValidationData.KiemTraInputChu(ngayHetHan) == true && ValidationData.KiemTraInputSo(maHang) == true && ValidationData.KiemTraInputDateQuaKhu(ngaySanXuat) == true && ValidationData.KiemTraInputDateTuongLai(ngayHetHan) == true) //Kiem tra thong tin
                { 
                    int MaHang = Convert.ToInt32(maHang);
                    double GiaTien = Convert.ToDouble(giaTien);
                    DateTime NgaySanXuat = DateTime.Parse(ngaySanXuat);
                    DateTime NgayHetHan = DateTime.Parse(ngayHetHan);
                    HangDienTu hangDienTu = new HangDienTu(MaHang, TenHang, GiaTien, NgaySanXuat, NgayHetHan);
                    khoHang.Add(hangDienTu);
                    Console.WriteLine($"Nhap san pham Hang Thuc Pham thu {i + 1} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin cua Hang Thuc Pham thu {i + 1}.");
                }
            }
        }

        public void nhapHangQuanAo() // Nhap 2 san pham Hang Dien Tu.
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Nhap thong tin Hang Quan Ao thu " + (i + 1) + ":");

                Console.Write("Ma hang: ");
                string maHang = Console.ReadLine();

                Console.Write("Ten hang: ");
                string TenHang = Console.ReadLine();

                Console.Write("Gia tien: ");
                string giaTien = Console.ReadLine();

                Console.Write("Ngay san xuat (mm-dd-yy): ");
                string ngaySanXuat = Console.ReadLine();

                Console.Write("Ngay het han (mm-dd-yy): ");
                string ngayHetHan = Console.ReadLine();

                if (ValidationData.KiemTraInputSo(maHang) == true && ValidationData.KiemTraInputChu(TenHang) == true && ValidationData.KiemTraInputSo(giaTien) == true && ValidationData.KiemTraInputDateQuaKhu(ngaySanXuat) == true && ValidationData.KiemTraInputDateTuongLai(ngayHetHan) == true) //Kiem tra thong tin
                {
                    int MaHang = Convert.ToInt32(maHang);
                    double GiaTien = Convert.ToDouble(giaTien);
                    DateTime NgaySanXuat = DateTime.Parse(ngaySanXuat);
                    DateTime NgayHetHan = DateTime.Parse(ngayHetHan);
                    HangDienTu hangDienTu = new HangDienTu(MaHang, TenHang, GiaTien, NgaySanXuat, NgayHetHan);
                    khoHang.Add(hangDienTu);
                    Console.WriteLine($"Nhap san pham Hang Quan Ao thu {i + 1} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin cua Hang Quan Ao thu {i + 1}.");
                }
            }
        }

        public void muaHang(int maHang)
        {
            Product sanPhamMua = khoHang.Find(s => s.maHang == maHang);
            if (sanPhamMua != null )
            { 
                gioHang.Add(sanPhamMua);
                khoHang.Remove(sanPhamMua);
                Console.WriteLine($"Mua san pham {sanPhamMua.tenHang} thanh cong!");
            } else
            {
                Console.WriteLine("Khong tim thay san pham tuong ung.");
            }
        }

        public void hienThiConLai()
        {
            Console.WriteLine($"So luong san pham con lai trong kho hang: {khoHang.Count()}");
        }

        public void hienThiGanHetHan()
        {
            DateTime HienTai = DateTime.Now;
            foreach (Product matHang in khoHang)
            {
                if (matHang.ngayHetHan.Subtract(HienTai).TotalDays < 30)
                {
                    Console.WriteLine(matHang);
                }
            }
        }
    }
}
