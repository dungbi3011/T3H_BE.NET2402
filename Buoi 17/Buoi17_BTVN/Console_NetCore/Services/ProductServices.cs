using Console_NetCore.CommonLibs;
using Console_NetCore.DBContext;
using Console_NetCore.DTO;
using Console_NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.Services
{
    public class ProductServices : IProductServices
    {
        SanPhamDBContext sanPhamDBContext = new SanPhamDBContext();
        public async Task<List<SanPham>> GetList()
        {
            try
            {
                return sanPhamDBContext.sanPham.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SanPhamReturnData> Product_Insert(SanPhamUpdate sanPhamThem)
        {
            var returnData = new SanPhamReturnData();
            var errItem = string.Empty;
            try
            {
                //Kiem tra du lieu dau vao
                if (sanPhamThem == null || sanPhamThem.LoaiSanPhamID == 0 || !ValidationData.KiemTraInputChu(sanPhamThem.TenSanPham) || !ValidationData.KiemTraInputChu(sanPhamThem.ThongTinSanPham))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Du lieu khong hop le.";
                    return returnData;
                }

                //Kiem tra su trung hop
                var product = sanPhamDBContext.sanPham.Where(s => s.TenSanPham == sanPhamThem.TenSanPham).FirstOrDefault();
                if (product != null || product.SanPhamID > 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "San pham da ton tai.";
                    return returnData;
                }

                // thêm sản phẩm vào database 
                var sanPhamMoi = new SanPham
                {
                    LoaiSanPhamID = sanPhamThem.LoaiSanPhamID,
                    TenSanPham = sanPhamThem.TenSanPham
                };

                sanPhamDBContext.sanPham.Add(sanPhamMoi);

                // lưu thuộc tính 
                var soLuongThuocTinh_Attr = sanPhamThem.ThongTinSanPham.Split(';').Length;

                for (int i = 0; i < soLuongThuocTinh_Attr; i++)
                {
                    var item = sanPhamThem.ThongTinSanPham.Split(';')[i];

                    var attr_name = item.Split(',')[0];
                    var attr_quantity = item.Split(',')[1];

                    var attr_price = item.Split(',')[2];
                    var attr_priceSale = item.Split(',')[3];

                    // kiểm tra xem null 
                    if (ValidationData.KiemTraInputChu(attr_name))
                    {
                        errItem += "Ten thuoc tinh khong hop le.";
                        continue;
                    }

                    if (ValidationData.KiemTraInputSo(attr_quantity))
                    {
                        errItem += "Thuoc tinh so luong khong hop le.";
                        continue;
                    }

                    if (ValidationData.KiemTraInputGia(attr_price))
                    {
                        errItem += "Thuoc tinh gia khong hop le.";
                        continue;
                    }

                    if (ValidationData.KiemTraInputGia(attr_priceSale))
                    {
                        errItem += "Thuoc tinh gia sale khong hop le.";
                        continue;
                    }

                    var attr_Req = new BienTheSanPham
                    {
                        AttributeName = attr_name,
                        Quantity = Convert.ToInt32(attr_quantity),
                        Price = Convert.ToInt32(attr_price),
                        PriceSale = Convert.ToInt32(attr_priceSale),
                    };

                    sanPhamDBContext.Add(attr_Req);

                }

                sanPhamDBContext.SaveChanges();


                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Them san pham thanh cong!";
                return returnData;
            }
            catch (Exception ex)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = "He thong khong xu li duoc luc nay!";
                return returnData;
            }
        }

        public async Task<SanPhamReturnData> Product_Find(string ten)
        {
            var returnData = new SanPhamReturnData();
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = sanPhamDBContext.sanPham.ToList();
                foreach (var sanPham in list)
                {
                    if (sanPham.TenSanPham == ten)
                    {
                        returnData.ReturnCode = 1;
                        returnData.sanPham = sanPham;
                        return returnData;
                    }
                }
                returnData.ReturnCode = -1;
                returnData.ReturnMsg = "Khong tim thay san pham tuong ung.";
                return returnData;
            }
            else
            {
                returnData.ReturnCode = -1;
                returnData.ReturnMsg = "Ten san pham khong hop le.";
                return returnData;
            }
        }

        public async Task<Product_DeleteReturnData> Product_Remove(SanPhamXoa requestData)
        {
            var returnData = new Product_DeleteReturnData();
            try
            {
                // cần kiểm tra xem id muốn xóa có tồn tại không
                var product = sanPhamDBContext.sanPham.Where(s => s.SanPhamID == requestData.SanPhamID).FirstOrDefault();

                if (product == null || product?.SanPhamID <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Khong tim that san pham tuong ung.";
                    return returnData;
                }


                sanPhamDBContext.sanPham.Remove(product);
                sanPhamDBContext.SaveChangesAsync();

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Xoa san pham thanh cong!";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -969;
                returnData.ReturnMsg = "He thong ban!";
                return returnData;
            }
        }

        public async Task<SanPhamReturnData> Product_Update(string ten, SanPham sanPham)
        {
            var returnData = new SanPhamReturnData();
            var list = sanPhamDBContext.sanPham.ToList();
            int index = list.FindIndex(s => s.TenSanPham == ten);
            if (index != -1)
            {
                list[index] = sanPham;
                sanPhamDBContext.SaveChanges();
                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Cap nhat san pham thanh cong!";
                return returnData;
            }
            else
            {
                sanPhamDBContext.SaveChanges();
                returnData.ReturnCode = -1;
                returnData.ReturnMsg = "Khong cap nhat duoc san pham.";
                return returnData;
            }
        }
    }
}
