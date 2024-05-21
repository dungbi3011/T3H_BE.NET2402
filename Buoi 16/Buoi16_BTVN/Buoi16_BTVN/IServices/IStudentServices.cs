using Buoi16_BTVN.Models;

namespace Buoi16_BTVN.IServices
{
    public interface IStudentServices
    {
        Task GetAuthors();
        Task<int> Student_Insert();
        Task<Student> Student_Find(string ten);
        Task Student_Delete();
        Task Student_Update();
    }
}
