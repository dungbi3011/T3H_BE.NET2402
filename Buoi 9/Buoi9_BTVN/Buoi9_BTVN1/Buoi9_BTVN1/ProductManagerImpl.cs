using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN1
{
    public class ProductManagerImpl : ProductManager
    {
        List<Product> khoHang = new List<Product>();

        // Phương thức nhập thông tin sản phẩm và tính toán giá sau chiết khấu
        public override void NhapThongTinSanPham(int n) 
        {
            Console.WriteLine("Bat dau chuong trinh them san pham vao kho hang.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin san pham thu " + (i + 1) + ":");

                Console.Write("Ten san pham: ");
                string ten = Console.ReadLine();

                Console.Write("Gia goc cua san pham: ");
                string Gia = Console.ReadLine();

                Console.Write("Loai chiet khau cua san pham (1 - Theo tien; 2 - Theo phan tram): ");
                string loaiChietKhau = Console.ReadLine();
                
                if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputGia(Gia) && ValidationData.KiemTraInputLoaiChietKhau(loaiChietKhau)) // Neu khong co loi thi add sach vao thuVien
                {
                    decimal gia = Convert.ToDecimal(Gia);
                    if (Convert.ToInt32(loaiChietKhau) == 1) { // Loai chiet khau Theo Tien 
                        Product sanPhamThem = new Product();
                        sanPhamThem.Ten = ten;
                        sanPhamThem.Gia = gia;
                        sanPhamThem.LoaiChietKhau = LoaiChietKhau.TheoTien;
                        khoHang.Add(sanPhamThem);
                        Console.WriteLine($"Them san pham {ten} vao kho hang thanh cong!");
                    } else if (Convert.ToInt32(loaiChietKhau) == 2) { // Loai chiet khau Theo Phan Tram
                        Product sanPhamThem = new Product();
                        sanPhamThem.Ten = ten;
                        sanPhamThem.Gia = gia;
                        sanPhamThem.LoaiChietKhau = LoaiChietKhau.TheoPhanTram;
                        khoHang.Add(sanPhamThem);
                    } 
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin san pham thu {i + 1}.");
                }
            }
        }

        //Phuong thuc hien thi san pham theo loai chiet khau
        public override void HienThiTheoLoaiChietKhau(int n)
        {
            if (n == 1) {
                foreach (var SanPham in khoHang)
                {
                    if (SanPham.LoaiChietKhau == LoaiChietKhau.TheoTien)
                    {
                        Console.WriteLine(SanPham);
                    }
                }
            } else if (n == 2) {
                foreach (var SanPham in khoHang)
                {
                    if (SanPham.LoaiChietKhau == LoaiChietKhau.TheoPhanTram)
                    {
                        Console.WriteLine(SanPham);
                    }
                }
            }
        }

        //Phuong thuc hien thi san pham theo gia tri chiet khau giam dan
        public override void HienThiTheoGiaChietKhauGiamDan()
        {
            var KhoHangMoi = khoHang.OrderByDescending(p => (p.Gia - p.calculatorDiscount()));

            foreach (var SanPham in KhoHangMoi)
            {
                Console.WriteLine(SanPham);
            }
        }

        //Phuong thuc tim kiem san pham theo ten
        public override void TimKiemTheoTen(string ten)
        {
            foreach (var SanPham in khoHang)
            {
                if (SanPham.Ten == ten)
                {
                    Console.WriteLine(SanPham);
                }
            }
        }
    }
}
