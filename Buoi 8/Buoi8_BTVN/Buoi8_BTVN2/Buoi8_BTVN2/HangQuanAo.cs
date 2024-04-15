using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN2
{
    public class HangQuanAo : Product
    {
        public HangQuanAo(int MaHang, string TenHang, double GiaTien, DateTime NgaySanXuat, DateTime NgayHetHan) : base(MaHang, TenHang, GiaTien, NgaySanXuat, NgayHetHan) { }
    }
}
