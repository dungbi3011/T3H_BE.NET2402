using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN3
{
    public class Product
    {
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public Product(string ten, decimal gia, int soLuong, decimal donGia)
        {
            Ten = ten;
            Gia = gia;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}
