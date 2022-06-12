using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqeCodeGenerator.DataAccess.Entites;

namespace UniqeCodeGenerator.DataAccess
{
    public class UniqeCodeGeneratorContext : DbContext
    {
        public DbSet<UniqeCode> UniqeCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=.;database=CodeGeneratorDb;user id=sa;password=xx;multipleactiveresultsets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UniqeCode>()
                .ToTable("CodeTablosu");
        }
    }
}
