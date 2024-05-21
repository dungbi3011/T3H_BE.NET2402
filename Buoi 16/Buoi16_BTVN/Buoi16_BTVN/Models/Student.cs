using System.ComponentModel.DataAnnotations;

namespace Buoi16_BTVN.Models
{
    public class Student
    {
        [Key] public int StudentID { get; set; }
        public string? Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public Student (string ten, DateTime ngaySinh, string diaChi)
        {
            Ten = ten;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
        }
        public override string ToString()
        {
            return $"StudentID: {StudentID} - Ten: {Ten} - Ngay sinh: {NgaySinh} - Dia chi: {DiaChi}";
        }
    }
}
