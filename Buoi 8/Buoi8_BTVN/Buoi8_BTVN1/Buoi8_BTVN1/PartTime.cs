using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public class PartTime : NhanVien
    {
        public long LuongTheoGio { get; set; }
        public int GioLamViec { get; set; }

        public override void ThongTin()
        {
            base.ThongTin();
            Console.WriteLine($"Luong theo gio: {LuongTheoGio} VND");
            Console.WriteLine($"So gio lam viec/thang: {GioLamViec} gio\n");
        }
    }
}
