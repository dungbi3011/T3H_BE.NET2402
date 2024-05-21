using Buoi16_BTVN.Models;

namespace Buoi16_BTVN.CommonLib
{
    public class ReturnData
    {
        public ReturnCodeType ReturnCode { get; set; }
        public string? ReturnMsg { get; set; }

        public Student Student { get; set; }
    }
}
