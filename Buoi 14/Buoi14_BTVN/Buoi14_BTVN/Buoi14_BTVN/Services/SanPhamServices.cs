using Buoi14_BTVN.CommonLib;
using Buoi14_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_BTVN.Services
{
    public class SanPhamServices
    {
        public async Task<SanPhamInsertReturnData> ADO_SanPham_Insert(SanPham sanPhamInput) 
        {
            var returnData = new SanPhamInsertReturnData();
            try
            {
                //Kiem tra input
                if (!CommonLib.ValidationData.KiemTraInputChu(sanPhamInput.TenSanPham)) 
                {
                    returnData.ReturnCode = (int)CommonLib.ReturnCodeType.DataInvalid;
                    returnData.ReturnMsg = "Du lieu dau vao khong hop le.";
                    return returnData;
                }

                //Buoc 1: Mo connection den DB
                var connect = CommonLib.DbHelper.GetSqlConnection();

                //Buoc 2: Su dung SqlCommand de thao tac
                var cmd = new SqlCommand("SP_SanPhamInsert", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //var cmdText = new SqlCommand("SELECT * FROM SanPham whew MaSanPham=1=1", connect);
                //cmd.CommandType = System.Data.CommandType.Text;

                //KIEU COMMAND ma muon dung TEXT va STORE

                //Buoc 3: Them tham so 
                cmd.Parameters.AddWithValue("@TenSanPham", sanPhamInput.TenSanPham);
                cmd.Parameters.AddWithValue("@CategoryID", sanPhamInput.CategoryID);
                cmd.Parameters.AddWithValue("@NgayHetHan", sanPhamInput.NgayHetHan);
                cmd.Parameters.AddWithValue("@SoLuongTonKho", sanPhamInput.SoLuongTonKho);
                cmd.Parameters.AddWithValue("@ResponseCode", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                //Buoc 4: Nhan ket qua
                cmd.ExecuteNonQuery();

                var rs = cmd.Parameters["@ResponseCode"].Value != DBNull.Value ? 
                    Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value) : 0;
                if (rs < 0)
                {
                    returnData.ReturnCode = (int)CommonLib.ReturnCodeType.Fail;
                    returnData.ReturnMsg = "Them du lieu that bai";
                    return returnData;
                }
                returnData.ReturnCode = (int)CommonLib.ReturnCodeType.Success;
                returnData.ReturnMsg = "Them du lieu thanh cong!";
                returnData.sanPham = sanPhamInput;
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)CommonLib.ReturnCodeType.Exception;
                returnData.ReturnMsg = ex.Message;
                returnData.sanPham = sanPhamInput;
                return returnData;
            }
        }
    }
}
