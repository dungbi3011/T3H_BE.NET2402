using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.DBContext
{
    public class SanPhamDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ZUNGBII-LAPTOP\\SQLEXPRESS;Initial Catalog=BE.NET2402;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True;");
        }
        public virtual DbSet<DTO.SanPham> sanPham { get; set; }
        public virtual DbSet<DTO.BienTheSanPham> productAttribute { get; set; }
    }
}
