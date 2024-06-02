using Console_NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.IServices
{
    public interface IProductServices
    {
        Task<List<SanPham>> GetList();
        Task<SanPhamReturnData> Product_Insert(SanPhamUpdate requestData);
        Task<Product_DeleteReturnData> Product_Remove(SanPhamXoa sanPham);
        Task<SanPhamReturnData> Product_Update(string ten, SanPham sanPham);
    }
}
