using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_BTVN.DTO
{
    public class Category
    {
        [Key] public int CategoryID { get; set; }
        public string? DanhMuc { get; set; }

        public Category(string? danhMuc)
        {
            DanhMuc = danhMuc;
        }
    }
}
