using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN3
{
    public class ProductManager : IProductManager
    {
        public List<Product> khoHang = new List<Product>();
        public List<Product> orders = new List<Product>();

        public void NhapThongTinSanPham(int n)
        {
            Console.WriteLine("Bat dau chuong trinh them san pham vao kho hang.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin san pham thu " + (i + 1) + ":");

                Console.Write("Ten san pham: ");
                string ten = Console.ReadLine();

                Console.Write("Gia cua san pham: ");
                string Gia = Console.ReadLine();

                Console.Write("So luong san pham: ");
                string SoLuong = Console.ReadLine();

                Console.Write("Don gia cua san pham: ");
                string DonGia = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputGia(Gia) && ValidationData.KiemTraInputSoLuong(SoLuong) && ValidationData.KiemTraInputGia(DonGia)) // Neu khong co loi thi add sach vao thuVien
                {
                    if (Convert.ToDecimal(Gia) > Convert.ToDecimal(DonGia)) { 
                        decimal gia = Convert.ToDecimal(Gia);
                        int soLuong = Convert.ToInt32(SoLuong);
                        decimal donGia = Convert.ToDecimal(DonGia);
                        Product sanPham = new Product(ten, gia, soLuong, donGia);
                        khoHang.Add(sanPham);
                        Console.WriteLine($"Them san pham {ten} vao kho hang thanh cong!");
                    } else {
                        Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin san pham thu {i + 1}.");
                    }
                } else {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin san pham thu {i + 1}.");
                }
            }
        }

        public void BuyProducts(Product product)
        {
            orders.Add(product);
        }

        public Product SearchProduct(string ten)
        {
            foreach (Product sanPham in khoHang) {
                if (sanPham.Ten == ten) {
                    return sanPham;
                } 
            }
            return null;
        }

        public void DisplayOrders() {
            foreach (Product product in orders)
            {
                decimal thanhTien = product.DonGia * product.SoLuong;
                decimal chietKhau = product.SoLuong > 5 ? 0.05m * thanhTien : 0;
                Console.WriteLine($"Ten: {product.Ten} | Gia: {product.Gia} | So luong: {product.SoLuong} | Don gia: {product.DonGia} | Thanh tien: {thanhTien} | Chiet khau: {chietKhau}");
            }
        }
    }
}
