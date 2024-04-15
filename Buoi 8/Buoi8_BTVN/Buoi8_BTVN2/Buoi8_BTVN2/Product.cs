using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN2
{
    public abstract class Product
    {
        public int maHang { get; set; }
        public string tenHang { get; set; }
        public double giaTien { get; set; }
        public DateTime ngaySanXuat { get; set; }
        public DateTime ngayHetHan { get; set; }
        public Product(int MaHang, string TenHang, double GiaTien, DateTime NgaySanXuat, DateTime NgayHetHan)
        {
            maHang = MaHang;
            tenHang = TenHang;
            giaTien = GiaTien;
            ngaySanXuat = NgaySanXuat;
            ngayHetHan = NgayHetHan;
        }

        public override string ToString()
        {
            return $"Ma hang: {maHang} - Ten mat hang: {tenHang} - Gia tien: {giaTien}VND - Ngay san xuat: {ngaySanXuat} - Ngay het han: {ngayHetHan}";
        }
    }
}
