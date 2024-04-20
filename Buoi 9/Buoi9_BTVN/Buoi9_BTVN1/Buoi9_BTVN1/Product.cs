using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN1
{
    public class Product
    {
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public LoaiChietKhau LoaiChietKhau { get; set; }

        // Phuong thuc tinh toan gia tien sau khi chiet khau
        public decimal calculatorDiscount()
        {
            //Tinh toan gia chiet khau tuy thuoc vao Gia && Loai chiet khau
            decimal giaChietKhau = 0;
            if (LoaiChietKhau == LoaiChietKhau.TheoTien)
            {
                if (Gia > 0 && Gia < 10000) {
                    giaChietKhau = 0; //khong chiet khau voi mat hang duoi 10k VND
                } else if (Gia >= 10000 && Gia < 100000) {
                    giaChietKhau = 1000; //chiet khau 1k VND voi mat hang hon 10k VND
                } else if (Gia >= 100000) {
                    giaChietKhau = 5000; //chiet khau 5k VND voi mat hang hon 100k VND
                }
            } else if (LoaiChietKhau == LoaiChietKhau.TheoPhanTram) {
                if (Gia > 0 && Gia < 10000) {
                    giaChietKhau = 0; //khong chiet khau voi mat hang duoi 10k VND
                } else if (Gia >= 10000 && Gia < 100000) {
                    giaChietKhau = Gia * 10 / 100; //chiet khau 10% voi mat hang hon 10k VND
                } else if (Gia >= 100000) {
                    giaChietKhau = Gia * 5 / 100; //chiet khau 5% voi mat hang hon 100k VND
                }
            }
            decimal giaSauChietKhau = Gia - giaChietKhau;
            return giaSauChietKhau;
        }
        //Phuong thuc in ra thong tin san pham
        public override string ToString()
        {
            return $"Ten san pham: {Ten} - Gia sau chiet khau: {calculatorDiscount()} VND";
        }
    }

}
