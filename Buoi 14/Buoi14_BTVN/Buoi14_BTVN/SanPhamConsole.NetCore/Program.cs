// See https://aka.ms/new-console-template for more information
using Buoi14_BTVN.CommonLib;
using Buoi14_BTVN.DTO;
using Buoi14_BTVN.Services;

Console.WriteLine("Hello, World!");

var sanPhamServices = new SanPhamServices();

Console.WriteLine("-------------CHAO MUNG TOI KHO HANG!---------------");
Console.WriteLine("Cac thao tac cua chuong trinh (0-2):");
Console.WriteLine("1. Them san pham vao kho hang tren database.");
Console.WriteLine("2. Hien thi thong tin san pham.");
Console.WriteLine("0. Thoat chuong trinh.");

// Viết menu chương trình 
while (true)
{
    Console.Write("\nChon mot chuc nang (nhap so tu 0-2): ");
    int luachon;
    bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
    while (isNumeric == false || luachon < 0 || luachon > 2)
    {
        Console.Write("Vui long nhap lai lua chon chuc nang (0-2): ");
        isNumeric = int.TryParse(Console.ReadLine(), out luachon);
    }

    switch (luachon)
    {
        case 1:
            Console.WriteLine("Bat dau chuong trinh them san pham.");
            //NHAP THONG TIN SAN PHAM
            Console.Write("Nhap ten san pham: ");
            string tenSanPham = Console.ReadLine();
            Console.Write("Nhap ma danh muc cua san pham: ");
            string categoryID = Console.ReadLine();
            Console.Write("Nhap ngay het han cua san pham: ");
            string ngayHetHan = Console.ReadLine();
            Console.Write("Nhap so luong ton kho cua san pham: ");
            string soLuongTonKho = Console.ReadLine();
            if (ValidationData.KiemTraInputChu(tenSanPham) && ValidationData.KiemTraInputSo(categoryID) && ValidationData.KiemTraInputNgayHetHan(ngayHetHan) && ValidationData.KiemTraInputSo(soLuongTonKho)) {
                var sanPham = new SanPham(tenSanPham, Convert.ToInt32(categoryID), Convert.ToDateTime(ngayHetHan), Convert.ToInt32(soLuongTonKho));
                var rs = await sanPhamServices.ADO_SanPham_Insert(sanPham);
                if (rs.ReturnCode < 0)
                {
                    Console.WriteLine("Them loi voi ly do " + rs.ReturnMsg);
                    return;
                }
                var sanPham_services_return = rs.sanPham;
                Console.WriteLine("-----------");
                Console.WriteLine("Ma san pham: " + sanPham_services_return.MaSanPhamID);
                Console.WriteLine("Ten san pham: " + sanPham_services_return.TenSanPham);
                Console.WriteLine("Ma danh muc: " + sanPham_services_return.CategoryID);
                Console.WriteLine("Ngay het han: " + sanPham_services_return.NgayHetHan);
                Console.WriteLine("So luong ton kho: " + sanPham_services_return.SoLuongTonKho);
            }
            break;
        case 2:
            Console.WriteLine("Bat dau chuong trinh hien thi thong tin san pham.");
            //NOT COMPLETED
            break;
        case 0:
            Console.WriteLine("Moi ban ra khoi chuong trinh.");
            return;
        default:
            Console.WriteLine("Lua chon khong hop le.");
            break;
    }
}



