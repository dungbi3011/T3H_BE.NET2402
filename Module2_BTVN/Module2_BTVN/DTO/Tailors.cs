using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_BTVN.DTO
{
    public class Tailors
    {
        [Key] public int TailorID { get; set; }
        public string? Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? QueQuan { get; set; }
        public Tailors (string ten, DateTime ngaySinh, string queQuan)
        {
            Ten = ten;
            NgaySinh = ngaySinh;
            QueQuan = queQuan;
        }
        public override string ToString()
        {
            return $"TailorID: {TailorID} - Ten: {Ten} - Ngay sinh: {NgaySinh} - Que quan: {QueQuan}.";
        }
    }
}
