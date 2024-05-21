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
    public class AuthorServices : IAuthorServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();

        public async Task GetAuthors()
        {
            

        }

        public async Task<int> Author_Insert()
        {
            Console.WriteLine("Nhap thong tin tac gia moi: ");
            Console.Write("Nhap ten tac gia: ");
            string ten = Console.ReadLine();
            Console.Write("Nhap quoc gia cua tac gia: ");
            string quocGia = Console.ReadLine();
            if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputChu(quocGia))
            {
                Authors author = new Authors(ten, quocGia);
                _eBookDBContext.authors.Add(author);
                Console.WriteLine("Them tac gia thanh cong!");
                return _eBookDBContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Xay ra loi khi nhap thong tin tac gia. Vui long thu lai.");
                return _eBookDBContext.SaveChanges();
            }
        }

        public async Task<Authors> Author_Find(string ten)
        {
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = _eBookDBContext.authors.ToList();
                foreach (var author in list)
                {
                    if (author.Ten == ten)
                    {
                        return author;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task Author_HienThiTimKiem(string ten)
        {
            var list = _eBookDBContext.authors.ToList();
            foreach (var author in list)
            {
                if (author.Ten == ten)
                {
                    Console.WriteLine("ID Tac gia: " + author.AuthorID);
                    Console.WriteLine("Ten: " + author.Ten);
                    Console.WriteLine("Quoc Gia: " + author.QuocGia);
                }
            }
        }

        public async Task Author_Delete()
        {
            Console.WriteLine("Nhap ten tac gia can xoa: ");
            string ten = Console.ReadLine();
            if (Author_Find(ten) != null)
            {
                var list = _eBookDBContext.authors.ToList();
                foreach (var author in list)
                {
                    if (author.Ten == ten)
                    {
                        _eBookDBContext.authors.Remove(author);
                        Console.WriteLine("Xoa tac gia thanh cong.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay tac gia tuong ung.");
            }
        }

        public async Task Author_Update()
        {
            Console.WriteLine("Nhap ten tac gia can cap nhat: ");
            string tenCanCapNhat = Console.ReadLine();
            if (Author_Find(tenCanCapNhat) != null)
            {
                var list = _eBookDBContext.authors.ToList();
                int index = list.FindIndex(a => a.Ten == tenCanCapNhat);
                if (index != 1)
                {
                    Console.WriteLine("Nhap thong tin tac gia moi: ");
                    Console.Write("Nhap ten tac gia: ");
                    string ten = Console.ReadLine();
                    Console.Write("Nhap quoc gia cua tac gia: ");
                    string quocGia = Console.ReadLine();
                    
                    if (ValidationData.KiemTraInputChu(ten) && ValidationData.KiemTraInputChu(quocGia))
                    {
                        Authors author = new Authors(ten, quocGia);
                        list[index] = author;
                        Console.WriteLine("Cap nhat tac gia thanh cong!");
                        _eBookDBContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Xay ra loi khi nhap thong tin tac gia. Vui long thu lai.");
                        _eBookDBContext.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("Khong tim thay tac gia tuong ung.");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay tac gia tuong ung.");
            }
        }

    }
}
