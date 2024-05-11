using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi13_BTVN.DTO;
using Microsoft.Extensions.Options;

namespace Buoi13_BTVN.DBContext
{
    public class EBookDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ZUNGBII-LAPTOP\\SQLEXPRESS;Initial Catalog=BE.NET2402;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True;");
        }

        public virtual DbSet<Books> books { get; set; }
        public virtual DbSet<Authors> authors { get; set; }
        public virtual DbSet<Customers> customers { get; set; }
        public virtual DbSet<Orders> orders { get; set; }
        public virtual DbSet<OrderDetails> orderDetails { get; set; }
    }
}

