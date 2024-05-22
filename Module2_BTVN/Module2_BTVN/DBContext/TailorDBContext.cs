using Microsoft.EntityFrameworkCore;
using Module2_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module2_BTVN.DBContext
{
    public class TailorDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ZUNGBII-LAPTOP\\SQLEXPRESS;Initial Catalog=BE.NET2402;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True;");
        }

        public virtual DbSet<Tailors> tailors { get; set; }
    }
}
