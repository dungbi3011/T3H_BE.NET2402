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
    public class OrderServices : IOrderServices
    {
        SanPhamDBContext sanPhamDBContext = new SanPhamDBContext();
        public async Task<OrderReturnData> Order_Create(OrdersCreateRequestData requestData)
        {
            var returnData = new OrderReturnData();
            try
            {
                // kiểm tra 

                var req = new Orders
                {
                    ThoiDiem = DateTime.Now,
                    KhachHangID = requestData.KhachHangID == 0 ? 1 : 0,// fake data
                    DiaChiGiaoHang = requestData.DiaChiGiaoHang,
                    Gia = requestData.Gia,
                };
                sanPhamDBContext.Add(req);
                var ketqua = sanPhamDBContext.SaveChangesAsync();

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Mua san pham thanh cong!";
                return returnData;
            }
            catch (Exception EX)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = EX.Message;
                return returnData;
            }
        }
    }
}
