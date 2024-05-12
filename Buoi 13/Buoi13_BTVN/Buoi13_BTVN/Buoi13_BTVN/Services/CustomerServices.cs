using Buoi13_BTVN.DBContext;
using Buoi13_BTVN.DTO;
using Buoi13_BTVN.IServices;
using Buoi13_BTVN.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.Services
{
    public class CustomerServices : ICustomerServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();

        public async Task GetCustomers()
        {
            var list = _eBookDBContext.customers.ToList();
            foreach (var customer in list)
            {
                Console.WriteLine("ID Khach hang: " + customer.CustomerID);
                Console.WriteLine("Ten khach hang: " + customer.TenKhachHang);
                Console.WriteLine("Ngay sinh: " + customer.NgaySinh);
                Console.WriteLine("Gioi tinh: " + customer.GioiTinh);
            }
        }

        public async Task<int> Customer_Insert()
        {
            Console.WriteLine("Nhap thong tin khach hang moi: ");
            Console.Write("Nhap ten khach hang: ");
            string tenKhachHang = Console.ReadLine();
            Console.Write("Nhap ngay sinh cua khach hang: ");
            string NgaySinh = Console.ReadLine();
            Console.Write("Nhap gioi tinh cua khach hang: ");
            string gioiTinh = Console.ReadLine();
            if (ValidationData.KiemTraInputChu(tenKhachHang) && ValidationData.KiemTraInputNgaySinh(NgaySinh) && ValidationData.KiemTraInputChu(gioiTinh))
            {
                DateTime ngaySinh = Convert.ToDateTime(NgaySinh);
                Customers customer = new Customers(tenKhachHang, ngaySinh, gioiTinh);
                _eBookDBContext.customers.Add(customer);
                Console.WriteLine("Them khach hang thanh cong!");
                return _eBookDBContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Xay ra loi khi nhap thong tin tac gia. Vui long thu lai.");
                return _eBookDBContext.SaveChanges();
            }
        }

        public async Task<Customers> Customer_Find(string ten)
        {
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = _eBookDBContext.customers.ToList();
                foreach (var customer in list)
                {
                    if (customer.TenKhachHang == ten)
                    {
                        return customer;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task Customer_HienThiTimKiem(string ten)
        {
            var list = _eBookDBContext.customers.ToList();
            foreach (var customer in list)
            {
                if (customer.TenKhachHang == ten)
                {
                    Console.WriteLine("ID Khach hang: " + customer.CustomerID);
                    Console.WriteLine("Ten khach hang: " + customer.TenKhachHang);
                    Console.WriteLine("Ngay sinh: " + customer.NgaySinh);
                    Console.WriteLine("Gioi tinh: " + customer.GioiTinh);
                }
            }
        }

        public async Task Customer_Delete()
        {
            Console.WriteLine("Nhap ten khach hang can xoa: ");
            string tenCanXoa = Console.ReadLine();
            if (Customer_Find(tenCanXoa) != null)
            {
                var list = _eBookDBContext.customers.ToList();
                foreach (var customer in list)
                {
                    if (customer.TenKhachHang == tenCanXoa)
                    {
                        _eBookDBContext.customers.Remove(customer);
                        Console.WriteLine("Xoa khach hang thanh cong.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay khach hang tuong ung.");
            }
        }

        public async Task Customer_Update()
        {
            Console.WriteLine("Nhap ten khach hang can cap nhat: ");
            string tenCanCapNhat = Console.ReadLine();
            if (Customer_Find(tenCanCapNhat) != null)
            {
                var list = _eBookDBContext.customers.ToList();
                int index = list.FindIndex(c => c.TenKhachHang == tenCanCapNhat);
                if (index != 1)
                {
                    Console.WriteLine("Nhap thong tin khach hang moi: ");
                    Console.Write("Nhap ten khach hang: ");
                    string tenKhachHang = Console.ReadLine();
                    Console.Write("Nhap ngay sinh cua khach hang: ");
                    string NgaySinh = Console.ReadLine();
                    Console.Write("Nhap gioi tinh cua khach hang: ");
                    string gioiTinh = Console.ReadLine();
                    if (ValidationData.KiemTraInputChu(tenKhachHang) && ValidationData.KiemTraInputNgaySinh(NgaySinh) && ValidationData.KiemTraInputChu(gioiTinh))
                    {
                        DateTime ngaySinh = Convert.ToDateTime(NgaySinh);
                        Customers customer = new Customers(tenKhachHang, ngaySinh, gioiTinh);
                        list[index] = customer;
                        Console.WriteLine("Cap nhat khach hang thanh cong!");
                        _eBookDBContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Xay ra loi khi nhap thong tin khach hang. Vui long thu lai.");
                        _eBookDBContext.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("Khong tim thay khach hang tuong ung.");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay khach hang tuong ung.");
            }
        }
    }
}
