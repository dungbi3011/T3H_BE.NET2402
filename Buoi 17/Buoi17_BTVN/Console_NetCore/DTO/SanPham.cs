using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.DTO
{
    public class SanPham
    {
        [Key] public int SanPhamID { get; set; }
        public int LoaiSanPhamID { get; set; }
        public string? TenSanPham { get; set; }
    }
}
