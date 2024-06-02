using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.DTO
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int KhachHangID { get; set; }
        public DateTime ThoiDiem { get; set; }
        public string? DiaChiGiaoHang { get; set; }
        public int Gia { get; set; }
    }

    public class OrdersCreateRequestData
    {

        public int OrderID { get; set; }
        public int KhachHangID { get; set; }
        public DateTime ThoiDiem { get; set; }
        public string? DiaChiGiaoHang { get; set; }

        public int Gia { get; set; }
    }
}
