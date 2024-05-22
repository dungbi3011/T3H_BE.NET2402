using Module2_BTVN.CommonLibs;
using Module2_BTVN.CommonLibs.Buoi16_BTVN.CommonLib;
using Module2_BTVN.DBContext;
using Module2_BTVN.DTO;
using Module2_BTVN.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_BTVN.Services
{
    public class TailorServices : ITailorServices
    {
        TailorDBContext _eTailorDBContext = new TailorDBContext();
        ReturnData returnData = new ReturnData();
        public async Task<List<Tailors>> GetTailors()
        {
            return _eTailorDBContext.tailors.ToList();
        }
        public async Task<ReturnData> Tailor_Insert(Tailors tailor)
        {
            if (tailor != null)
            {
                _eTailorDBContext.tailors.Add(tailor);
                _eTailorDBContext.SaveChanges();
                returnData.ReturnCode = ReturnCodeType.Success;
                returnData.ReturnMsg = "Them cong nhan thanh cong!";
                return returnData;
            } else
            {
                returnData.ReturnCode = ReturnCodeType.Fail;
                returnData.ReturnMsg = "Them cong nhan that bai.";
                return returnData;
            }
        }

        public async Task<Tailors> Tailor_Find(string ten)
        {
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = _eTailorDBContext.tailors.ToList();
                foreach (var tailor in list)
                {
                    if (tailor.Ten == ten)
                    {
                        return tailor;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<ReturnData> Tailor_Delete(string ten)
        {
            if (Tailor_Find(ten) != null)
            {
                _eTailorDBContext.tailors.Remove(await Tailor_Find(ten));
                _eTailorDBContext.SaveChanges();
                returnData.ReturnCode = ReturnCodeType.Success;
                returnData.ReturnMsg = "Xoa cong nhan thanh cong!";
                return returnData;
            } else
            {
                returnData.ReturnCode = ReturnCodeType.Fail;
                returnData.ReturnMsg = "Khong tim thay cong nhan tuong ung.";
                return returnData;
            }
        }

        public async Task<ReturnData> Tailor_Update(string ten, Tailors tailor)
        {
            var list = _eTailorDBContext.tailors.ToList();
            if (Tailor_Find(ten) != null)
            {
                int index = list.FindIndex(t => t.Ten == ten);
                list[index] = tailor;
                _eTailorDBContext.SaveChanges();
                returnData.ReturnCode = ReturnCodeType.Success;
                returnData.ReturnMsg = "Cap nhat cong nhan thanh cong!";
                return returnData;
            } else
            {
                returnData.ReturnCode = ReturnCodeType.Fail;
                returnData.ReturnMsg = "Khong tim thay cong nhan tuong ung.";
                return returnData;
            }
        }
    }
}
