using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Boat> Boat { get; set; }
        public DbSet<Bus> Bus { get; set; }
    }
}
