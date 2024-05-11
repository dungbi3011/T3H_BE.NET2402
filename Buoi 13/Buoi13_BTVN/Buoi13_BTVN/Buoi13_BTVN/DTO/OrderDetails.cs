using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.DTO
{
    public class OrderDetails
    {
        [Key] public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public int SoLuongSanPham { get; set; }
        public long GiaBanTaiThoiDiem { get; set; }
        public OrderDetails(int orderID, int bookID, int soLuongSanPham, long giaBanTaiThoiDiem) {
            OrderID = orderID;
            BookID = bookID;    
            SoLuongSanPham = soLuongSanPham;
            GiaBanTaiThoiDiem = giaBanTaiThoiDiem;
        }
    }
}
