using MEDIC3.Models;
using Microsoft.EntityFrameworkCore;

namespace MEDIC3.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=MEDICdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}