using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.DTO
{
    public class BienTheSanPham
    {
        [Key] 
        public int AttributeID { get; set; }
        public string? AttributeName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int PriceSale { get; set; }
        public int ProductID { get; set; }
    }
}
