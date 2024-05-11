using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.DTO
{
    public class Books
    {
        [Key] public int BookID {  get; set; } 
        public string? Ten {  get; set; }
        public int TacGiaID {  get; set; }
        public string? TheLoai {  get; set; }
        public long Gia {  get; set; }
        public int SoLuong { get; set; }

        public Books(string? ten, int tacGiaID, string? theLoai, long gia, int soLuong)
        {
            Ten = ten;
            TacGiaID = tacGiaID;
            TheLoai = theLoai;
            Gia = gia;
            SoLuong = soLuong;
        }
    }
}
