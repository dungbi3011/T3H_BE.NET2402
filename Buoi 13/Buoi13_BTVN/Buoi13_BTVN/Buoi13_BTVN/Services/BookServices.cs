using Buoi13_BTVN.DBContext;
using Buoi13_BTVN.DTO;
using Buoi13_BTVN.IServices;
using Buoi13_BTVN.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.Services
{
    public class BookServices : IBookServices       
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();

        public async Task<List<Books>> GetBooks()
        {
            return _eBookDBContext.books.ToList();
        }

        public async Task<int> Book_Insert ()
        {
            Console.WriteLine("Nhap thong tin sach moi: ");
            Console.Write("Nhap ten cuon sach: ");
            string ten = Console.ReadLine();
            Console.Write("Nhap ID tac gia: ");
            string TacGiaID = Console.ReadLine();
            Console.Write("Nhap the loai sach: ");
            string theLoai = Console.ReadLine();
            Console.Write("Nhap gia sach: ");
            string Gia = Console.ReadLine();
            Console.Write("Nhap so luong sach: ");
            string SoLuong = Console.ReadLine();
            if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputSo(TacGiaID) && ValidationData.KiemTraInputChu(theLoai) && ValidationData.KiemTraInputGia(Gia) && ValidationData.KiemTraInputSo(SoLuong) )
            {
                int tacGiaID = Convert.ToInt32(TacGiaID);
                long gia = Convert.ToInt64(Gia);
                int soLuong = Convert.ToInt32(SoLuong);
                Books book = new Books(ten, tacGiaID, theLoai, gia, soLuong);
                _eBookDBContext.books.Add(book);
                Console.WriteLine("Them sach thanh cong!");
                return _eBookDBContext.SaveChanges();
            } else
            {
                Console.WriteLine("Xay ra loi khi nhap thong tin sach. Vui long thu lai.");
                return _eBookDBContext.SaveChanges();
            }
        }

        public async Task<Books> Book_Find(string ten)
        {
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = _eBookDBContext.books.ToList();
                foreach (var book in list)
                {
                    if (book.Ten == ten)
                    {
                        return book;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public async Task Book_HienThiTimKiem (string ten)
        {
            var list = _eBookDBContext.books.ToList();
            foreach (var book in list)
            {
                if (book.Ten == ten)
                {
                    Console.WriteLine("BookID: " + book.BookID);
                    Console.WriteLine("Ten: " + book.Ten);
                    Console.WriteLine("ID Tac gia: " + book.TacGiaID);
                    Console.WriteLine("The loai: " + book.TheLoai);
                    Console.WriteLine("Gia: " + book.Gia);
                    Console.WriteLine("So luong: " + book.SoLuong);
                }
            }
        }

        public async Task Book_Delete()
        {
            Console.WriteLine("Nhap ten sach can xoa: ");
            string ten = Console.ReadLine();
            if (Book_Find(ten) != null)
            {
                var list = _eBookDBContext.books.ToList();
                foreach (var book in list) {
                    if (book.Ten == ten) {
                        _eBookDBContext.books.Remove(book);
                        Console.WriteLine("Xoa sach thanh cong.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay sach tuong ung.");
            }
        }

        public async Task Book_Update()
        {
            Console.WriteLine("Nhap ten sach can cap nhat: ");
            string tenCanCapNhat = Console.ReadLine();
            if (Book_Find(tenCanCapNhat) != null)
            {
                var list = _eBookDBContext.books.ToList();
                int index = list.FindIndex(b => b.Ten == tenCanCapNhat);
                if (index != 1)
                {
                    Console.WriteLine("Nhap thong tin sach moi: ");
                    Console.Write("Nhap ten cuon sach: ");
                    string ten = Console.ReadLine();
                    Console.Write("Nhap ID tac gia: ");
                    string TacGiaID = Console.ReadLine();
                    Console.Write("Nhap the loai sach: ");
                    string theLoai = Console.ReadLine();
                    Console.Write("Nhap gia sach: ");
                    string Gia = Console.ReadLine();
                    Console.Write("Nhap so luong sach: ");
                    string SoLuong = Console.ReadLine();
                    if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputSo(TacGiaID) && ValidationData.KiemTraInputChu(theLoai) && ValidationData.KiemTraInputGia(Gia) && ValidationData.KiemTraInputSo(SoLuong))
                    {
                        int tacGiaID = Convert.ToInt32(TacGiaID);
                        if (_eBookDBContext.authors.ToList().FindIndex(a => a.AuthorID == tacGiaID) >= 0) {
                            long gia = Convert.ToInt64(Gia);
                            int soLuong = Convert.ToInt32(SoLuong);
                            Books book = new Books(ten, tacGiaID, theLoai, gia, soLuong);
                            list[index] = book;
                            Console.WriteLine("Cap nhat sach thanh cong!");
                            _eBookDBContext.SaveChanges();
                        } else
                        {
                            Console.WriteLine("Khong tim thay ID tac gia tuong ung.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Xay ra loi khi nhap thong tin sach. Vui long thu lai.");
                        _eBookDBContext.SaveChanges();
                    }
                } else
                {
                    Console.WriteLine("Khong tim thay sach tuong ung.");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay sach tuong ung.");
            }
        }

    }
}
