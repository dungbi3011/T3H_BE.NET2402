using EBook.DataAccess.NetCore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DBContext
{
    public class EBookDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EBookDBContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Book> book {  get; set; }
    }
}
