using Buoi13_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.IServices
{
    public interface IAuthorServices
    {
        Task<List<Authors>> GetAuthors();
        Task<int> Author_Insert();
        Task<Authors> Author_Find(string ten);
        Task Author_Delete();
        Task Author_Update();
    }
}
