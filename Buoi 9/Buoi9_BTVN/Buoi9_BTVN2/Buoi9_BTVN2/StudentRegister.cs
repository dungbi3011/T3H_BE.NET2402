using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN2
{
    // Class StudentRegister thuc thi Interface IStudentRegister
    public class StudentRegister : IStudentRegister
    {
        List<Course> CacKhoaHoc = new List<Course>();
        List<DangKi> DanhSachDangKi = new List<DangKi>();

        public void NhapThongTinKhoaHoc(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin khoa hoc thu " + (i + 1) + ":");

                Console.Write("Ten khoa hoc: ");
                string ten = Console.ReadLine();

                Console.Write("Mo ta khoa hoc: ");
                string moTa = Console.ReadLine();

                Console.Write("Hoc phi: ");
                string HocPhi = Console.ReadLine();

                Console.Write("Ngay khai giang: ");
                string NgayKhaiGiang = Console.ReadLine();

                if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputChu(moTa) && ValidationData.KiemTraInputHocPhi(HocPhi) && ValidationData.KiemTraInputNgayKhaiGiang(NgayKhaiGiang)) // Neu khong co loi
                {
                    decimal hocPhi = Convert.ToDecimal(HocPhi);
                    Course KhoaHocThem = new Course();
                    KhoaHocThem.Ten = ten;
                    KhoaHocThem.MoTa = moTa;
                    KhoaHocThem.HocPhi = hocPhi;
                    KhoaHocThem.NgayKhaiGiang = Convert.ToDateTime(NgayKhaiGiang);
                    CacKhoaHoc.Add(KhoaHocThem);
                    Console.WriteLine($"Them khoa hoc {ten} thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin khoa hoc. Chuong trinh xin bo qua thong tin khoa hoc thu {i + 1}.");
                }
            }
        }

        public void DangKiKhoaHoc(Course KhoaHoc)
        {
            Console.WriteLine("Nhap thong tin hoc sinh:");

            Console.Write("Ten hoc sinh: ");
            string hoTen = Console.ReadLine();

            Console.Write("Ngay sinh (MM/dd/yyyy): ");
            string NgaySinh = Console.ReadLine();

            if (ValidationData.KiemTraInputChu(hoTen) && ValidationData.KiemTraInputNgaySinh(NgaySinh)) // Neu khong co loi
            {
                Student HocSinh = new Student();
                HocSinh.HoTen = hoTen;
                HocSinh.NgaySinh = Convert.ToDateTime(NgaySinh);
                DangKi dangKi = new DangKi(HocSinh, KhoaHoc, DateTime.Now);
                DanhSachDangKi.Add(dangKi);
                Console.WriteLine("Dang ki khoa hoc thanh cong!");
                Console.WriteLine($"Ho ten: {dangKi.Student.HoTen} - Ngay sinh: {dangKi.Student.NgaySinh} - Ngay dang ki: {dangKi.NgayDangKi} - Khoa hoc: {dangKi.Course.Ten} - Hoc phi: {dangKi.Course.HocPhi} - Hoc phi sau chiet khau: {GiamGia(dangKi)}");
            }
            else
            {
                Console.WriteLine($"Xay ra loi khi nhap thong tin. Chuong trinh xin bo qua thong tin dang ki.");
            }
        }
        public void HienThiHocSinhDangKiKhoaHoc()
        {
            var danhsach = DanhSachDangKi.OrderByDescending(d => (d.Course.HocPhi - GiamGia(d)) );

            Console.WriteLine("Danh sach hoc sinh dang ki khoa hoc:");
            foreach (var dangki in danhsach)
            {
                Console.WriteLine($"Ho ten: {dangki.Student.HoTen} - Ngay sinh: {dangki.Student.NgaySinh} - Ngay dang ki: {dangki.NgayDangKi} - Khoa hoc: {dangki.Course.Ten} - Hoc phi: {dangki.Course.HocPhi} - Hoc phi sau chiet khau: {GiamGia(dangki)}");
            }
        }

        public decimal GiamGia(DangKi dangki)
        {
            TimeSpan SoNgayDangKiTruocKhaiGiang = dangki.Course.NgayKhaiGiang - dangki.NgayDangKi;
            if (SoNgayDangKiTruocKhaiGiang.TotalDays >= 30) {
                //Giam gia 15% neu dang ki truoc 30 ngay
                return (dangki.Course.HocPhi * 85 / 100);
            } else if (SoNgayDangKiTruocKhaiGiang.TotalDays >= 10 && SoNgayDangKiTruocKhaiGiang.TotalDays < 30) {
                //Chuong trinh giam gia 10% thong thuong 
                return (dangki.Course.HocPhi * 90 / 100);
            } else {
                return dangki.Course.HocPhi;
            }
        }

        public Course TimKhoaHoc (string tenKhoaHoc)
        {
            foreach (Course KhoaHoc in CacKhoaHoc)
            {
                if (KhoaHoc.Ten == tenKhoaHoc)
                {
                    return KhoaHoc;
                }
            }
            return null;
        }
    }

}
