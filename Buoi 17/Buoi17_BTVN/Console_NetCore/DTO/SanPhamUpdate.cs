using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.DTO
{
    public class SanPhamUpdate
    {
        public int SanPhamID { get; set; }
        public int LoaiSanPhamID { get; set; }
        public string? TenSanPham { get; set; }

        public string? ThongTinSanPham { get; set; } // 256 lit-den,10,10000,9000 ; 236 lit-den,15,12000,10000  
    }
    public class SanPhamXoa
    {
        public int SanPhamID { get; set; }
    }
}
