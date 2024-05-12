using Buoi13_BTVN.DBContext;
using Buoi13_BTVN.DTO;
using Buoi13_BTVN.Validation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.Services
{
    public class OrderServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();
        public async Task<Books> Book_Find(string ten)
        {
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = _eBookDBContext.books.ToList();
                foreach (var book in list)
                {
                    if (book.Ten == ten)
                    {
                        return book;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public async Task MuaHang()
        {
            Console.WriteLine("Nhap ten sach can mua: ");
            string tenSachCanMua = Console.ReadLine();
            Console.WriteLine("Nhap dia chi can giao hang: ");
            string diaChiGiaoHang = Console.ReadLine();
            if (Book_Find(tenSachCanMua) != null && ValidationData.KiemTraInputChu(tenSachCanMua) && ValidationData.KiemTraInputChu(diaChiGiaoHang))
            {
                var list = _eBookDBContext.books.ToList();
                //Check xem co sach can mua khong
                int index = list.FindIndex(b => b.Ten == tenSachCanMua);
                if (index != 1)
                {
                    DateTime ngayDatHang = DateTime.Now;
                    int khachHangID = 1;
                    long tongTien = list[index].Gia;
                    Orders order = new Orders(ngayDatHang, khachHangID, diaChiGiaoHang, tongTien);
                    _eBookDBContext.orders.ToList().Add(order);
                    Console.WriteLine("Mua hang thanh cong!");
                } else
                {
                    Console.WriteLine("Khong tim thay sach tuong ung.");
                }
            } else {
                Console.WriteLine("Khong tim thay sach tuong ung.");
            }
        }
    }
}
