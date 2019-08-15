using EFCore.Domain;
using Microsoft.EntityFrameworkCore;


namespace EFCore.Data
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(Local);database=EFCore_1;Integrated Security=True");
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
