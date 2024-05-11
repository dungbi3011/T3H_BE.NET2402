using EBook.DataAccess.NetCore.DAL;
using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.DTO;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.Services
{
    public class BookServices : IBookServices
    {
        private EBookDBContext _eBookDBContext;
        public async Task<List<Book>> GetBooks()
        {
            return _eBookDBContext.book.ToList();
        }
        public BookServices(EBookDBContext eBookDBContext)
        {

        }
        public async Task<int> Book_Insert(Book book)
    }
}
