using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.DTO
{
    public class Customers
    {
        [Key] public int CustomerID { get; set; }
        public string? TenKhachHang { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public Customers (string tenKhachHang, DateTime ngaySinh, string gioiTinh)
        {
            TenKhachHang = tenKhachHang;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
        }
    }
}
