using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public class FullTime : NhanVien
    {
        public long LuongThang { get; set; }

        public override void ThongTin()
        {
            base.ThongTin();
            Console.WriteLine($"Luong theo thang: {LuongThang} VND\n");
        }
    }
}
