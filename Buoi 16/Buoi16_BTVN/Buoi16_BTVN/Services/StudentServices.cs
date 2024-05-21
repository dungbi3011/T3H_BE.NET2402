using Buoi16_BTVN.CommonLib;
using Buoi16_BTVN.DBContext;
using Buoi16_BTVN.Models;
using Microsoft.EntityFrameworkCore;

namespace Buoi16_BTVN.Services
{
    public class StudentServices
    {
        StudentDBContext _studentDBContext = new StudentDBContext();
        ReturnData returnData = new ReturnData();
        public async Task<List<Student>> GetStudent() 
        {
            var studentList = await _studentDBContext.students.ToListAsync();
            return studentList;
        }
        public async Task<ReturnData> Student_Insert(Student student) 
        {
            var list = _studentDBContext.students.ToList();
            list.Add(student);
            _studentDBContext.SaveChanges();
            returnData.ReturnCode = ReturnCodeType.Success;
            returnData.ReturnMsg = "Them hoc sinh thanh cong!";
            return returnData;
        }
        public async Task<ReturnData> Student_Find(string ten) 
        {
            if (ValidationData.KiemTraInputChu(ten))
            {
                var list = _studentDBContext.students.ToList();
                foreach (var student in list)
                {
                    if (student.Ten == ten)
                    {
                        returnData.ReturnCode = ReturnCodeType.Success;
                        returnData.Student = student;
                        return returnData;
                    }
                }
                returnData.ReturnCode = ReturnCodeType.DuplicatedData;
                returnData.ReturnMsg = "Khong tim thay hoc sinh tuong ung.";
                return returnData;
            }
            else
            {
                returnData.ReturnCode = ReturnCodeType.DataInvalid;
                returnData.ReturnMsg = "Ten hoc sinh khong hop le.";
                return returnData;
            }
        }
        public async Task<ReturnData> Student_Delete(Student student) 
        {
            if (student != null) {
                var list = _studentDBContext.students.ToList();
                list.Remove(student);
                _studentDBContext.SaveChanges();
                returnData.ReturnCode = ReturnCodeType.Success;
                returnData.ReturnMsg = "Cap nhat hoc sinh thanh cong!";
                return returnData;
            } else
            {
                returnData.ReturnCode = ReturnCodeType.Fail;
                returnData.ReturnMsg = "Khong tim thay hoc sinh tuong ung.";
                return returnData;
            }
        }
        public async Task<ReturnData> Student_Update(string ten, Student student) 
        {
            var list = _studentDBContext.students.ToList();
            int index = list.FindIndex(a => a.Ten == ten);
            if (index != -1)
            {
                list[index] = student;
                _studentDBContext.SaveChanges();
                returnData.ReturnCode = ReturnCodeType.Success;
                returnData.ReturnMsg = "Cap nhat hoc sinh thanh cong!";
                return returnData;
            } else
            {
                _studentDBContext.SaveChanges();
                returnData.ReturnCode = ReturnCodeType.Fail;
                returnData.ReturnMsg = "Khong cap nhat duoc hoc sinh.";
                return returnData;
            }
        }
    }
}
