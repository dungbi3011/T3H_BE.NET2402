using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public class NhanVien
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public virtual void ThongTin()
        {
            Console.WriteLine($"Ho ten nhan vien: {HoTen}");
            Console.WriteLine($"Tuoi: {Tuoi}");
        }
    }
}
