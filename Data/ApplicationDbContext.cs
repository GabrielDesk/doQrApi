using doQrApi.Entites;
using doQrApi.Entities;
using doQrApi.Objects;
using Microsoft.EntityFrameworkCore;

namespace doQrApi.Data
{
#pragma warning disable CS1591
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> TB_Employees {  get; set; }
        public DbSet<ContractType> TB_contracttypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
#pragma warning restore CS1591

}
