using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.DTO
{
    public class Authors
    {
        [Key] public int AuthorID { get; set; }
        public string? Ten { get; set; }
        public string? QuocGia { get; set; }
        public Authors(string ten, string quocGia) {
            Ten = ten;
            QuocGia = quocGia;
        }
    }
}
