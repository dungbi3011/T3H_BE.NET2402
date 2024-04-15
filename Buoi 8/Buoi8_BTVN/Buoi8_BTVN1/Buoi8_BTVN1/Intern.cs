using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public class Intern : NhanVien
    {
        public long LuongHoTro { get; set; }

        public override void ThongTin()
        {
            base.ThongTin();
            Console.WriteLine($"Luong ho tro theo thang: {LuongHoTro} VND\n");
        }
    }
}
