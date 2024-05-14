using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_BTVN.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }

    public class SanPhamInsertReturnData : ReturnData
    {
        public SanPham sanPham { get; set; }
    }
}

