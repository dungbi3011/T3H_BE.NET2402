using Buoi13_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.IServices
{
    public interface IBookServices
    {
        Task GetBooks();
        Task<int> Book_Insert();
        Task<Books> Book_Find(string ten);
        Task Book_Delete();
        Task Book_Update();
    }
}
