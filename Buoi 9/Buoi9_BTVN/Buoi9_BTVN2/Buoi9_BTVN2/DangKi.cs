using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN2
{
    public class DangKi
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DangKi(Student student, Course course, DateTime ngayDangKi)
        {
            Student = student;
            Course = course;
            NgayDangKi = ngayDangKi;
        }
    }
}
