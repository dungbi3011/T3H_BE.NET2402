using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_BTVN.DTO
{
    public class SanPham
    {
        [Key] public int MaSanPhamID { get; set; }
        public string? TenSanPham { get; set; }
        public int CategoryID { get; set; }
        public DateTime NgayHetHan  { get; set; }
        public int SoLuongTonKho { get; set; }

        public SanPham(string? tenSanPham, int categoryID, DateTime ngayHetHan, int soLuongTonKho)
        {
            TenSanPham = tenSanPham;
            CategoryID = categoryID;
            NgayHetHan = ngayHetHan;
            SoLuongTonKho = soLuongTonKho;
        }
    }
}
