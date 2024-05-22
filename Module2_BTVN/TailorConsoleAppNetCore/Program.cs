using Module2_BTVN.DBContext;
using Module2_BTVN.Services;
using Module2_BTVN.CommonLibs;
using Microsoft.EntityFrameworkCore;
using Module2_BTVN.IServices;
using Module2_BTVN.DTO;

Console.WriteLine("-------------CHUONG TRINH QUAN LY CONG NHAN CUA CONG TY MAY---------------");
Console.WriteLine("Cac thao tac cua chuong trinh (0-3):");
Console.WriteLine("1. Them, sua, xoa thong tin nhan vien.");
Console.WriteLine("2. Tim kiem cong nhan, thong qua ten.");
Console.WriteLine("3. Su dung linq de tinh tong theo tung nguoi.");
Console.WriteLine("0. Thoat chuong trinh.");

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
    //Tao Service mới cho TailorServices
    TailorServices tailorServices = new TailorServices();

    switch (luachon)
    {
        case 1:
            Console.WriteLine("Bat dau chuong trinh cap nhat thong tin nhan vien.");
            Console.Write("Chon cach cap nhat tuong ung (1 - Hien thi; 2 - Them; 3 - Sua; 4 - Xoa): ");
            string luaChonSach = Console.ReadLine();
            if (luaChonSach == "1")
            {
                Console.WriteLine("Danh sach cac sach trong database:");
                var list = await tailorServices.GetTailors();
                foreach (var tailor in list)
                {
                    Console.WriteLine(tailor);
                }
            }
            else if (luaChonSach == "2")
            {
                Console.WriteLine("Bat dau chuong trinh them cong nhan vao database.");
                Console.Write("Nhap ten tho may: ");
                string tenThem = Console.ReadLine();
                Console.Write("Nhap ngay sinh tho may (MM/dd/yyyy): ");
                string NgaySinhThem = Console.ReadLine();
                Console.Write("Nhap que quan tho may: ");
                string queQuanThem = Console.ReadLine();
                if (ValidationData.KiemTraInputChu(tenThem) && ValidationData.KiemTraInputNgaySinh(NgaySinhThem) && ValidationData.KiemTraInputChu(queQuanThem))
                {
                    DateTime ngaySinhThem = Convert.ToDateTime(NgaySinhThem);
                    Tailors tailor = new Tailors(tenThem, ngaySinhThem, queQuanThem);
                    Console.WriteLine(tailorServices.Tailor_Insert(tailor));
                } else
                {
                    Console.WriteLine(tailorServices.Tailor_Insert(null));
                }
            }
            else if (luaChonSach == "3")
            {
                Console.WriteLine("Bat dau chuong trinh sua thong tin cong nhan trong database.");
                Console.Write("Nhap ten tho may can sua: ");
                string tenCanSua = Console.ReadLine();

                //Nhap thong tin moi cho cong nhan
                Console.Write("Nhap ten da sua cho tho may : ");
                string tenMoiSua = Console.ReadLine();
                Console.Write("Nhap ngay sinh da sua cho tho may (MM/dd/yyyy): ");
                string NgaySinhMoiSua = Console.ReadLine();
                Console.Write("Nhap que quan da sua tho may: ");
                string queQuanMoiSua = Console.ReadLine();
                if (ValidationData.KiemTraInputChu(tenMoiSua) && ValidationData.KiemTraInputNgaySinh(NgaySinhMoiSua) && ValidationData.KiemTraInputChu(queQuanMoiSua))
                {
                    DateTime ngaySinhMoiSua = Convert.ToDateTime(NgaySinhMoiSua);
                    Tailors tailor = new Tailors(tenMoiSua, ngaySinhMoiSua, queQuanMoiSua);
                    Console.WriteLine(tailorServices.Tailor_Insert(tailor));
                }
                else
                {
                    Console.WriteLine(await tailorServices.Tailor_Insert(null));
                }
            }
            else if (luaChonSach == "4")
            {
                Console.WriteLine("Bat dau chuong trinh xoa cong nhan khoi database.");
                Console.Write("Nhap ten tho may can xoa: ");
                string tenCanXoa = Console.ReadLine();
                if (ValidationData.KiemTraInputChu(tenCanXoa))
                {
                    await tailorServices.Tailor_Delete(tenCanXoa);
                }
            }
            else
            {
                Console.Write("Xay ra loi khi nhap lua chon cap nhat danh sach tho may.");
            }
            break;
        case 2:
            Console.WriteLine("Bat dau chuong trinh tim kiem tho may, thong qua ten.");
            string tenTimKiem = Console.ReadLine();
            Tailors searchedTailor = await tailorServices.Tailor_Find(tenTimKiem);
            if (searchedTailor != null)
            {
                Console.WriteLine($"Ket qua tim kiem: {searchedTailor}");
            } else
            {
                Console.WriteLine("Khong tim thay ket qua tuong ung.");
            }
            break;
        case 3:
            Console.WriteLine("Bat dau chuong trinh tinh tong theo tung nguoi.");
            break;
        case 0:
            Console.WriteLine("Moi ban ra khoi chuong trinh.");
            return;
        default:
            Console.WriteLine("Lua chon khong hop le.");
            break;
    }
}