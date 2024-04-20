using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN2
{
    // Interface IStudentRegister co phuong thuc de dang ki khoa hoc
    public interface IStudentRegister
    {
        void NhapThongTinKhoaHoc(int n);
        void DangKiKhoaHoc(Course KhoaHoc);
        void HienThiHocSinhDangKiKhoaHoc ();
    }
}
