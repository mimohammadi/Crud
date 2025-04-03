using Crud.Domain.Models.PersonalInfo;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class DataBaseContext : DbContext
    {
        public DbSet<PersonalInfo> PersonalInfos { get; set; }

        public DataBaseContext(DbContextOptions options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG

            optionsBuilder
               .UseSqlServer("Server=localhost\\SQLEXPRESS01;Initial Catalog=CrudDB;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=123;TrustServerCertificate=Yes");

#endif
            base.OnConfiguring(optionsBuilder);

        }
    }
}
