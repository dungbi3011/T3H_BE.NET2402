using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_BTVN.CommonLib
{
    public enum ReturnCodeType
    {
        Success = 1,
        Fail = -3,
        DuplicatedData = -2,
        DataInvalid = -1,
        Exception = -99
    }
}
