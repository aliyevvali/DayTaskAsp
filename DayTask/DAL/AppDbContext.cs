using DayTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DayTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
