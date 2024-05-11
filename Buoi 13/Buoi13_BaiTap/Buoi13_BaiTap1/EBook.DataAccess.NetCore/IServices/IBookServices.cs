using EBook.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DAL
{
    internal interface IBookServices
    {
        Task<List<Book>> GetBooks();
        Task<int> Book_Insert(Book book);

    }
}
