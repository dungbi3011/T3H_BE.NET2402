using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.DTO
{
    public class Orders
    {
        [Key] public int OrderID { get; set; }
        public DateTime NgayDatHang { get; set; }
        public int KhachHangID { get; set; }
        public string? DiaChiGiaoHang { get; set; }
        public long TongTien { get; set; }
        public Orders (DateTime ngayDatHang, int khachHangID, string diaChiGiaoHang, long tongTien)
        {
            NgayDatHang = ngayDatHang;
            KhachHangID = khachHangID;
            DiaChiGiaoHang = diaChiGiaoHang;
            TongTien = tongTien;
        }
    }
}
