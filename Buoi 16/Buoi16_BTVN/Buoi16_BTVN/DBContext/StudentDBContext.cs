using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using Buoi16_BTVN.Models;
using Microsoft.EntityFrameworkCore;

namespace Buoi16_BTVN.DBContext
{
    public class StudentDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ZUNGBII-LAPTOP\\SQLEXPRESS;Initial Catalog=BE.NET2402;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True;");
        }

        public virtual DbSet<Student> students { get; set; }
    }
}
