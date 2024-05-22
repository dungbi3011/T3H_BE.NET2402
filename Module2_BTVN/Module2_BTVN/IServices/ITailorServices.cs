using Module2_BTVN.CommonLibs;
using Module2_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_BTVN.IServices
{
    public interface ITailorServices
    {
        Task<List<Tailors>> GetTailors();
        Task<ReturnData> Tailor_Insert(Tailors tailor);
        Task<Tailors> Tailor_Find(string ten);
        Task<ReturnData> Tailor_Delete(string ten);
        Task<ReturnData> Tailor_Update(string ten, Tailors tailor);
    }
}
