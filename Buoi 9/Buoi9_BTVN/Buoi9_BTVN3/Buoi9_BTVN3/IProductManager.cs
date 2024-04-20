using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN3
{
    public interface IProductManager
    {
        void NhapThongTinSanPham(int n);
        void BuyProducts(Product product);
        Product SearchProduct(string ten);
        void DisplayOrders();
    }
}
