// See https://aka.ms/new-console-template for more information
using Buoi13_BTVN.DBContext;
using Buoi13_BTVN.Services;
using Buoi13_BTVN.Validation;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("-------------CHAO MUNG TOI THU VIEN MUA SACH AO!---------------");
Console.WriteLine("Cac thao tac cua chuong trinh (0-5):");
Console.WriteLine("1. Them, sua, xoa, hien thi, tim kiem thong tin sach.");
Console.WriteLine("2. Them, sua, xoa, hien thi, tim kiem thong tin tac gia.");
Console.WriteLine("3. Them, sua, xoa, hien thi, tim kiem thong tin khach hang.");
Console.WriteLine("4. Thuc hien chuc nang mua hang.");
Console.WriteLine("5. Hien thi danh sach don hang, tim kiem va xem chi tiet don hang.");

// Viết menu chương trình 
while (true)
{
    Console.Write("\nChon mot chuc nang (nhap so tu 0-5): ");
    int luachon;
    bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
    while (isNumeric == false || luachon < 0 || luachon > 5)
    {
        Console.Write("Vui long nhap lai lua chon chuc nang (0-5): ");
        isNumeric = int.TryParse(Console.ReadLine(), out luachon);
    }

    switch (luachon)
    {
        case 1:
            Console.WriteLine("Bat dau chuong trinh cap nhat thong tin sach.");
            BookServices bookService = new BookServices();
            Console.Write("Chon cach cap nhat tuong ung (1 - Hien thi; 2 - Them; 3 - Xoa; 4 - Sua; 5 - Tim kiem): ");
            string luaChonSach = Console.ReadLine();
            if (luaChonSach == "1")
            {
                Console.WriteLine("Danh sach cac sach trong database:");
                bookService.GetBooks();
            } else if (luaChonSach == "2")
            {
                Console.WriteLine("Bat dau chuong trinh them sach vao database.");
                bookService.Book_Insert();
            } else if (luaChonSach == "3")
            {
                Console.WriteLine("Bat dau chuong trinh xoa sach khoi database.");
                bookService.Book_Delete();
            } else if (luaChonSach == "4")
            {
                Console.WriteLine("Bat dau chuong trinh cap nhat sach trong database.");
                bookService.Book_Update();
            } else if (luaChonSach == "5")
            {
                Console.WriteLine("Bat dau chuong trinh tim kiem sach trong database.");
                Console.Write("Nhap ten sach can tim kiem: ");
                string ten = Console.ReadLine();
                if (bookService.Book_Find(ten) != null)
                {
                    Console.WriteLine("Thong tin sach duoc tim kiem");
                    bookService.Book_HienThiTimKiem(ten);
                } else
                {
                    Console.WriteLine("Khong tim thay sach tuong ung.");
                }
            } else
            {
                Console.Write("Xay ra loi khi nhap lua chon cap nhat thu vien sach.");
            }
            break;
        case 2:
            Console.WriteLine("Bat dau chuong trinh cap nhat thong tin tac gia.");
            AuthorServices authorService = new AuthorServices();
            Console.Write("Chon cach cap nhat tuong ung (1 - Hien thi; 2 - Them; 3 - Xoa; 4 - Sua; 5 - Tim kiem): ");
            string luaChonTacGia = Console.ReadLine();
            if (luaChonTacGia == "1")
            {
                Console.WriteLine("Danh sach cac tac gia trong database:");
                authorService.GetAuthors();
            }
            else if (luaChonTacGia == "2")
            {
                Console.WriteLine("Bat dau chuong trinh them tac gia vao database.");
                authorService.Author_Insert();
            }
            else if (luaChonTacGia == "3")
            {
                Console.WriteLine("Bat dau chuong trinh xoa tac gia khoi database.");
                authorService.Author_Delete();
            }
            else if (luaChonTacGia == "4")
            {
                Console.WriteLine("Bat dau chuong trinh cap nhat tac gia trong database.");
                authorService.Author_Update();
            }
            else if (luaChonTacGia == "5")
            {
                Console.WriteLine("Bat dau chuong trinh tim kiem tac gia trong database.");
                Console.Write("Nhap ten tac gia can tim kiem: ");
                string ten = Console.ReadLine();
                if (authorService.Author_Find(ten) != null)
                {
                    Console.WriteLine("Thong tin tac gia duoc tim kiem");
                    authorService.Author_HienThiTimKiem(ten);
                }
                else
                {
                    Console.WriteLine("Khong tim thay tac gia tuong ung.");
                }
            }
            else
            {
                Console.Write("Xay ra loi khi nhap lua chon cap nhat danh sach tac gia.");
            }
            break;
        case 3:
            Console.WriteLine("Bat dau chuong trinh cap nhat thong tin khach hang.");
            CustomerServices customerService = new CustomerServices();
            Console.Write("Chon cach cap nhat tuong ung (1 - Hien thi; 2 - Them; 3 - Xoa; 4 - Sua; 5 - Tim kiem): ");
            string luaChonKhachHang = Console.ReadLine();
            if (luaChonKhachHang == "1")
            {
                Console.WriteLine("Danh sach cac khach hang trong database:");
                customerService.GetCustomers();
            }
            else if (luaChonKhachHang == "2")
            {
                Console.WriteLine("Bat dau chuong trinh them khach hang vao database.");
                customerService.Customer_Insert();
            }
            else if (luaChonKhachHang == "3")
            {
                Console.WriteLine("Bat dau chuong trinh xoa khach hang khoi database.");
                customerService.Customer_Delete();
            }
            else if (luaChonKhachHang == "4")
            {
                Console.WriteLine("Bat dau chuong trinh cap nhat khach hang trong database.");
                customerService.Customer_Update();
            }
            else if (luaChonKhachHang == "5")
            {
                Console.WriteLine("Bat dau chuong trinh tim kiem khach hang trong database.");
                Console.Write("Nhap ten khach hang can tim kiem: ");
                string ten = Console.ReadLine();
                if (customerService.Customer_Find(ten) != null)
                {
                    Console.WriteLine("Thong tin khach hang duoc tim kiem");
                    customerService.Customer_HienThiTimKiem(ten);
                }
                else
                {
                    Console.WriteLine("Khong tim thay khach hang tuong ung.");
                }
            }
            else
            {
                Console.Write("Xay ra loi khi nhap lua chon cap nhat danh sach khach hang.");
            }
            break;
        case 4:
            Console.WriteLine("Bat dau chuong trinh mua hang.");
            OrderServices orders = new OrderServices();
            orders.MuaHang();
            break;
        case 5:
            Console.WriteLine("Bat dau chuong tirnh hien thi danh sach don hang, tim kiem va xem chi tiet don hang.");
            OrderDetailsServices orderDetailService = new OrderDetailsServices();
            Console.Write("Chon cach cap nhat tuong ung (1 - Hien thi; 2 - Them; 3 - Tim kiem): ");
            string luaChonDonHang = Console.ReadLine();
            if (luaChonDonHang == "1")
            {
                Console.WriteLine("Danh sach cac chi tiet don hang trong database:");
                orderDetailService.GetOrderDetails();
            }
            else if (luaChonDonHang == "2")
            {
                Console.WriteLine("Bat dau chuong trinh them chi tiet don hang vao database.");
                orderDetailService.OrderDetails_Insert();
            }
            else if (luaChonDonHang == "3")
            {
                Console.WriteLine("Bat dau chuong trinh tim kiem chi tiet don hang trong database.");
                Console.Write("Nhap ID chi tiet don hang can tim kiem: ");
                string idDonHang = Console.ReadLine();
                if (orderDetailService.OrderDetails_Find(idDonHang) != null)
                {
                    Console.WriteLine("Thong tin chi tiet don hang duoc tim kiem");
                    orderDetailService.OrderDetails_HienThiTimKiem(idDonHang);
                }
                else
                {
                    Console.WriteLine("Khong tim thay khach hang tuong ung.");
                }
            }
            break;
        case 0:
            Console.WriteLine("Moi ban ra khoi chuong trinh.");
            return;
        default:
            Console.WriteLine("Lua chon khong hop le.");
            break;
    }
}

