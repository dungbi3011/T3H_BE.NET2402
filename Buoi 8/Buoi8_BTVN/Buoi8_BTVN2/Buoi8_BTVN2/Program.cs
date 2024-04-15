using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN2
{
    public class Program : Yeu_cau_chuong_trinh
    {
        Yeu_cau_chuong_trinh ChuongTrinh = new Yeu_cau_chuong_trinh();
        public void Implement()
        {
            Console.WriteLine("---------CHUONG TRINH QUAN LY SAN PHAM---------");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Nhap lieu cho moi loai hang 2 san pham.");
            Console.WriteLine("2. Thuc hien mua hang va hien thi so luong con lai trong cua hang.");
            Console.WriteLine("3. Hien thi so luong mat hang con lai trong kho hang.");
            Console.WriteLine("4. Thong ke cac loai hang hoa sap het han (ngay het han - ngay hien tai < 30).");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            // Viết menu chương trình 
            while (true)
            {
                Console.Write("\nChon mot chuc nang (nhap so tu 0-4): ");
                int luachon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                while (isNumeric == false || luachon < 0 || luachon > 4)
                {
                    Console.Write("Vui long nhap lai lua chon chuc nang (0-4): ");
                    isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                }

                switch (luachon)
                {
                    case 1:
                        Console.WriteLine("Bat dau chuong trinh nhap du lieu cho 2 san pham moi loai.");
                        ChuongTrinh.nhapHangDienTu();
                        ChuongTrinh.nhapHangThucPham();
                        ChuongTrinh.nhapHangQuanAo();
                        Console.WriteLine("Hoan thanh chuong trinh nhap lieu san pham.");
                        break;
                    case 2:
                        Console.Write("Nhap ma hang cua san pham muon mua: ");
                        string id = Console.ReadLine();
                        while (!ValidationData.KiemTraInputSo(id))
                        {
                            Console.Write("Vui long nhap lai ma hang hop le: ");
                            id = Console.ReadLine();
                        }
                        int ID = Convert.ToInt32(id);
                        ChuongTrinh.muaHang(ID);
                        break;
                    case 3:
                        ChuongTrinh.hienThiConLai();
                        break;
                    case 4:
                        ChuongTrinh.hienThiGanHetHan();
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

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Program program = new Program();
            program.Implement();

            Console.ReadKey();
        }
    }
}
