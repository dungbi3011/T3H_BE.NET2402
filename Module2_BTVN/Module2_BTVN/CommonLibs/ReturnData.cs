using Module2_BTVN.CommonLibs.Buoi16_BTVN.CommonLib;
using Module2_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_BTVN.CommonLibs
{
    public class ReturnData
    {
        public ReturnCodeType ReturnCode { get; set; }
        public string? ReturnMsg { get; set; }

        public Tailors? tailor { get; set; }

        public override string ToString()
        {
            return $"{ReturnMsg}";
        }
    }
}
