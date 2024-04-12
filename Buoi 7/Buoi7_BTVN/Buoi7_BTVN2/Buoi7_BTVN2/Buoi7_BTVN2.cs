using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi7_BTVN2
{
    // Abstract class NhanVien de duoc ke thua
    abstract class NhanVien
    {
        public string ten { get; set; }
        public abstract long tinhToanLuong(); // Phuong thuc tinh toan tien luong

        public NhanVien (string Ten)
        {
            ten = Ten;
        }
    }

    // Class con - nhan vien toan thoi gian
    class NhanVienFullTime : NhanVien
    {
        public long luongThang { get; set; }

        public NhanVienFullTime(string Ten, long LuongThang) : base(Ten)
        {
            luongThang = LuongThang;
        }

        public override long tinhToanLuong()
        {
            return luongThang;
        }
    }

    // Class con - nhan vien ban thoi gian
    class NhanVienPartTime : NhanVien
    {
        public long luongTheoGio { get; set; }
        public int soGioLamViec { get; set; }

        public NhanVienPartTime(string Ten, long LuongTheoGio, int SoGioLamViec) : base(Ten)
        {
            luongTheoGio = LuongTheoGio;
            soGioLamViec = SoGioLamViec;
        }

        public override long tinhToanLuong()
        {
            return luongTheoGio * soGioLamViec;
        }
    }

    // Class con - thuc tap sinh
    class ThucTapSinh : NhanVien
    {
        public long luongThucTap { get; set; }
        public int soThangThucTap { get; set; }

        public ThucTapSinh(string Ten, long LuongThucTap, int SoThangThucTap) : base(Ten)
        {
            soThangThucTap = SoThangThucTap;
            luongThucTap = LuongThucTap;
        }

        public override long tinhToanLuong()
        {
            return luongThucTap * soThangThucTap;
        }
    }
    internal class Buoi7_BTVN2
    {
        public bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool KiemTraInputSoNhanVien(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("So nhan vien/tts phai la so tu nhien > 0 va < 100.");
                return false;
            }
            if (int.TryParse(input, out number))
            {
                if (number <= 0 || number >= 100)
                {
                    Console.WriteLine("So nhan vien/tts phai la so tu nhien > 0 va < 100.");
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraInputChu (string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ten nhan vien khong duoc de trong.");
                return false;
            }
            if (input.Any(char.IsDigit))
            {
                Console.WriteLine("Ten nhan vien khong duoc chua so.");
                return false;
            }
            if (CheckXSSInput(input) == false)
            {
                Console.WriteLine("Ten nhan vien KHONG DUOC PHEP CHUA MA DOC.");
                return false;
            }
            return true;
        }
        public bool KiemTraInputSoGio(string input)
        {
            int number ;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("So gio phai la so tu nhien > 0 va < 720.");
                return false;
            }
            if (int.TryParse(input, out number))
            {
                if (number < 0 || number > 720)
                {
                    Console.WriteLine("So gio phai la so tu nhien >= 0 va <= 720.");
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraInputSoThang(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("So thang phai la so tu nhien >= 0 va <= 12.");
                return false;
            }
            if (int.TryParse(input, out number))
            {
                if (number < 0 || number > 12)
                {
                    Console.WriteLine("So thang phai la so tu nhien >= 0 va <= 12.");
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraInputLuong(string input)
        {
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Luong phai la so tu nhien.");
                return false;
            }
            return true;
        }
        public void ThongTinFullTime(int n) // Tham so n. So luong nhan vien full-time la n.
        {
            Console.WriteLine("Bat dau chuong trinh hien thi thong tin nhan vien full-time.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin nhan vien full-time thu " + (i + 1) + ":");

                Console.Write("Ten nhan vien: ");
                string TenFullTime = Console.ReadLine();

                Console.Write("Luong thang cua nhan vien full-time: ");
                string luongFullTime = Console.ReadLine();

                if (KiemTraInputChu(TenFullTime) && KiemTraInputLuong(luongFullTime)) // Neu khong co loi thi tinh toan luong cho nhan vien
                {
                    long LuongFullTime = Convert.ToInt64(luongFullTime);
                    NhanVienFullTime fullTime = new NhanVienFullTime(TenFullTime, LuongFullTime);
                    Console.WriteLine($"Luong thang cua nhan vien full-time {TenFullTime}: {fullTime.tinhToanLuong()} VND");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin nhan vien. Chuong trinh xin bo qua thong tin cua nhan vien thu {i + 1}.");
                }
            }
        }

        public void ThongTinPartTime(int n) // Tham so n. So luong nhan vien part-time la n.
        {
            Console.WriteLine("Bat dau chuong trinh hien thi thong tin nhan vien part-time.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin nhan vien part-time thu " + (i + 1) + ":");

                Console.Write("Ten nhan vien: ");
                string TenPartTime = Console.ReadLine();

                Console.Write("Luong theo gio cua nhan vien part-time: ");
                string luongTheoGio = Console.ReadLine();

                Console.Write("So gio lam viec trong thang cua nhan vien part-time: ");
                string soGioLamViec = Console.ReadLine();

                if (KiemTraInputChu(TenPartTime) && KiemTraInputLuong(luongTheoGio) && KiemTraInputSoGio(soGioLamViec)) // Neu khong co loi thi tinh toan luong cho nhan vien
                {
                    long LuongTheoGio = Convert.ToInt64(luongTheoGio);
                    int SoGioLamViec = Convert.ToInt32(soGioLamViec);
                    NhanVienPartTime partTime = new NhanVienPartTime(TenPartTime, LuongTheoGio, SoGioLamViec);
                    Console.WriteLine($"Luong thang cua nhan vien part-time {TenPartTime}: {partTime.tinhToanLuong()} VND");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin nhan vien. Chuong trinh xin bo qua thong tin cua nhan vien thu {i + 1}.");
                }
            }
        }

        public void ThongTinThucTap(int n) // Tham so n. So luong thuc tap sinh la n.
        {
            Console.WriteLine("Bat dau chuong trinh hien thi thong tin thuc tap sinh.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin thuc tap sinh thu " + (i + 1) + ":");

                Console.Write("Ten thuc tap sinh: ");
                string TenThucTap = Console.ReadLine();

                Console.Write("Luong ho tro/thang cua thuc tap sinh: ");
                string luongThucTap = Console.ReadLine();

                Console.Write("So thang thuc tap cua thuc tap sinh: ");
                string soThangThucTap = Console.ReadLine();

                if (KiemTraInputChu(TenThucTap) && KiemTraInputLuong(luongThucTap) && KiemTraInputSoThang(soThangThucTap)) // Neu khong co loi thi tinh toan luong cho TTS
                {
                    long LuongThucTap = Convert.ToInt64(luongThucTap);
                    int SoThangThucTap = Convert.ToInt32(soThangThucTap);
                    ThucTapSinh tts = new ThucTapSinh(TenThucTap, LuongThucTap, SoThangThucTap);
                    Console.WriteLine($"Luong ho tro cho thuc tap sinh {TenThucTap}: {tts.tinhToanLuong()} VND");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin thuc tap sinh. Chuong trinh xin bo qua thong tin cua thuc tap sinh thu {i + 1}.");
                }
            }
        }
        public void BTVN2()
        {
            Console.WriteLine("---------CHUONG TRINH TINH TOAN LUONG CUA NV FULL-TIME, PART-TIME, TTS---------");
            Console.WriteLine("                         Luu y:");
            Console.WriteLine("     - Luong full-time = Luong FullTime/thang");
            Console.WriteLine("     - Luong part-time = Luong theo gio * so gio lam viec");
            Console.WriteLine("     - Luong TTS = Luong ho tro * so thang thuc tap");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Tinh toan luong cua nhan vien full-time.");
            Console.WriteLine("2. Tinh toan luong cua nhan vien part-time.");
            Console.WriteLine("3. Tinh toan luong cua thuc tap sinh.");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            // Viết menu chương trình 
            while (true)
            {
                Console.Write("\nChon mot chuc nang (nhap so tu 0-3): ");
                int luachon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                while (isNumeric == false || luachon < 0 || luachon > 3)
                {
                    Console.Write("Vui long nhap lai lua chon chuc nang (0-3): ");
                    isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                }

                switch (luachon)
                {
                    case 1:
                        Console.Write("Nhap so luong Nhan vien full-time: ");
                        string n1 = Console.ReadLine();
                        while (!KiemTraInputSoNhanVien(n1))
                        {
                            Console.Write("Vui long nhap lai so nhan vien/tts: ");
                            n1 = Console.ReadLine();
                        }
                        int N1 = Convert.ToInt32(n1);
                        ThongTinFullTime(N1);
                        break;
                    case 2:
                        Console.Write("Nhap so luong Nhan vien part-time: ");
                        string n2 = Console.ReadLine();
                        while (!KiemTraInputSoNhanVien(n2))
                        {
                            Console.Write("Vui long nhap lai so nhan vien/tts: ");
                            n2 = Console.ReadLine();
                        }
                        int N2 = Convert.ToInt32(n2);
                        ThongTinPartTime(N2);
                        break;
                    case 3:
                        Console.Write("Nhap so luong Thuc tap sinh: ");
                        string n3 = Console.ReadLine();
                        while (!KiemTraInputSoNhanVien(n3))
                        {
                            Console.Write("Vui long nhap lai so nhan vien/tts: ");
                            n3 = Console.ReadLine();
                        }
                        int N3 = Convert.ToInt32(n3);
                        ThongTinThucTap(N3);
                        break;
                    case 0:
                        Console.WriteLine("Moi ban ra khoi chuong trinh.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }

        }
    }
}
