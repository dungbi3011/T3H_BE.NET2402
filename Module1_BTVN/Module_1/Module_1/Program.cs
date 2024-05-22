using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{
    public class Program : HotelManagementSystem
    {
        HotelManagementSystem ChuongTrinh = new HotelManagementSystem();
        public void Implement()
        {
            Console.WriteLine("-------------------HE THONG QUAN LY KHACH SAN-------------------");
            Console.WriteLine("Cac lua chon cua chuong trinh:");
            Console.WriteLine("1. Quan ly danh sach phong cua khach san (Them, Xoa, Cap nhat).");
            Console.WriteLine("2. Dat phong khach san.");
            Console.WriteLine("3. Cap nhat thong tin dat phong cua khach hang (Xoa, Sua thong tin).");
            Console.WriteLine("4. Hien thi lich su dat phong.");
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
                        Console.WriteLine("Bat dau chuong trinh nhap du lieu cho danh sach phong.");
                        Console.Write("Nhap vao lua chon cap nhat danh sach phong (1 - Them, 2 - Xoa, 3 - Cap nhat): ");
                        string quanLyDanhSachPhong = Console.ReadLine();
                        if (quanLyDanhSachPhong == "1")
                        {
                            Console.Write("Nhap vao so luong phong can nhap: ");
                            string N = Console.ReadLine();
                            while (!int.TryParse(N, out int soPhong))
                            {
                                Console.Write("Vui long nhap lai so luong phong can nhap: ");
                                N = Console.ReadLine();
                            }
                            ChuongTrinh.AddRoom(Convert.ToInt32(N));
                        }
                        else if (quanLyDanhSachPhong == "2")
                        {
                            Console.Write("Nhap vao so cua phong can xoa: ");
                            string PhongBiXoa = Console.ReadLine();
                            if (SearchRoom(PhongBiXoa) != null)
                            {
                                RemoveRoom(SearchRoom(PhongBiXoa));
                                Console.WriteLine("Xoa phong khach san thanh cong!");
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay phong tuong ung.");
                            }
                        }
                        else if (quanLyDanhSachPhong == "3")
                        {
                            Console.Write("Nhap vao so phong can cap nhat: ");
                            string soPhongCanCapNhat = Console.ReadLine();
                            while (!ValidationData.KiemTraInputSoPhong(soPhongCanCapNhat))
                            {
                                Console.Write("Vui long nhap lai so phong can cap nhat: ");
                                soPhongCanCapNhat = Console.ReadLine();
                            }
                            UpdateRoom(soPhongCanCapNhat);
                        }
                        else
                        {
                            Console.WriteLine("Lua chon khong hop le.");
                        }
                        Console.WriteLine("Hoan thanh chuong trinh nhap lieu phong khach san.");
                        break;
                    case 2:
                        Console.WriteLine("Bat dau chuong trinh dat phong khach san.");
                        AddBooking();
                        Console.WriteLine("Hoan thanh chuong trinh dat phong khach san.");
                        break;
                    case 3:
                        Console.WriteLine("Bat dau chuong trinh cap nhat thong tin dat phong.");
                        Console.Write("Nhap vao lua chon cap nhat danh sach dat phong cua khach hang (1 - Xoa, 2 - Sua thong tin): ");
                        string quanLyDanhSachBooking = Console.ReadLine();
                        switch (quanLyDanhSachBooking)
                        {
                            case "1":
                                Console.Write("Nhap vao BookingID dat phong can xoa:");
                                Booking BookingBiXoa = SearchBooking(Console.ReadLine());
                                if (BookingBiXoa != null) {
                                    RemoveBooking(BookingBiXoa);
                                    Console.WriteLine("Xoa Booking thanh cong!");
                                } else {
                                    Console.WriteLine("Khong tim thay Booking tuong ung.");
                                }
                                break;
                            case "2":
                                UpdateBooking();
                                break;
                            default:
                                Console.WriteLine("Lua chon khong hop le.");
                                break;
                        }
                        Console.WriteLine("Hoan thanh chuong trinh cap nhat quan ly dat phong cua khach hang.");
                        break;
                    case 4:
                        Console.WriteLine("Bat dau chuong trinh hien thi lich su dat phong.");
                        DisplayBooking();
                        Console.WriteLine("Hoan thanh chuong trinh hien thi lich su dat phong.");
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
