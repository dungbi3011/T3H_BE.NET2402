using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN1
{
    // Lop truu tuong ProductManager ke thua tu Product
    public abstract class ProductManager : Product
    {
        // Phương thức nhập thông tin sản phẩm và tính toán giá sau chiết khấu
        public abstract void NhapThongTinSanPham(int n);

        //Phuong thuc hien thi san pham theo loai chiet khau
        public abstract void HienThiTheoLoaiChietKhau(int n);
        //Phuong thuc hien thi san pham theo gia tri chiet khau giam dan
        public abstract void HienThiTheoGiaChietKhauGiamDan();

        //Phuong thuc tim kiem san pham theo ten
        public abstract void TimKiemTheoTen(string ten);
    }
}
