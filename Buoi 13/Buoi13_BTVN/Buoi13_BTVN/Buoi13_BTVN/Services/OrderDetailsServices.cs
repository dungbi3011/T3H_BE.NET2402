using Buoi13_BTVN.DBContext;
using Buoi13_BTVN.DTO;
using Buoi13_BTVN.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.Services
{
    public class OrderDetailsServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();
        public async Task<List<OrderDetails>> GetOrderDetails()
        {
            return _eBookDBContext.orderDetails.ToList();
        }

        public async Task<int> OrderDetails_Insert()
        {
            Console.WriteLine("Nhap thong tin chi tiet don hang moi: ");
            Console.Write("Nhap ID cua don hang: ");
            string DonHangID = Console.ReadLine();
            Console.Write("Nhap ID cua sach: ");
            string SachID = Console.ReadLine();
            if (ValidationData.KiemTraInputSo(DonHangID) && ValidationData.KiemTraInputSo(SachID))
            {
                int donHangID = Convert.ToInt32(DonHangID);
                int sachID = Convert.ToInt32(SachID);
                if (_eBookDBContext.orders.ToList().FindIndex(o => o.OrderID == donHangID) >= 0 && _eBookDBContext.books.ToList().FindIndex(b => b.BookID == sachID) >= 0) {
                    int indexSach = _eBookDBContext.books.ToList().FindIndex(b => b.BookID == sachID);
                    OrderDetails orderDetail = new OrderDetails(donHangID, sachID, 1, _eBookDBContext.books.ToList()[indexSach].Gia);
                    _eBookDBContext.orderDetails.ToList().Add(orderDetail);
                    Console.WriteLine("Them chi tiet don hang thanh cong!");
                    return _eBookDBContext.SaveChanges();
                }
                return _eBookDBContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Xay ra loi khi nhap thong tin tac gia. Vui long thu lai.");
                return _eBookDBContext.SaveChanges();
            }
        }

        public async Task<OrderDetails> OrderDetails_Find(string id)
        {
            if (ValidationData.KiemTraInputSo(id))
            {
                var list = _eBookDBContext.orderDetails.ToList();
                foreach (var orderDetail in list)
                {
                    if (orderDetail.OrderDetailsID == Convert.ToInt32(id))
                    {
                        return orderDetail;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task OrderDetails_HienThiTimKiem(string id)
        {
            var list = _eBookDBContext.orderDetails.ToList();
            foreach (var orderDetail in list)
            {
                if (orderDetail.OrderDetailsID == Convert.ToInt32(id))
                {
                    Console.WriteLine("OrderDetailID: " + orderDetail.OrderDetailsID);
                    Console.WriteLine("ID Don hang: " + orderDetail.OrderID);
                    Console.WriteLine("ID Sach: " + orderDetail.BookID);
                    Console.WriteLine("So luong san pham: " + orderDetail.SoLuongSanPham);
                    Console.WriteLine("Gia ban tai thoi diem: " + orderDetail.GiaBanTaiThoiDiem);
                }
            }
        }


    }
}
