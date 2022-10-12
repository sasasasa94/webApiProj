using Microsoft.EntityFrameworkCore;
using taskWebApi.Models;

namespace taskWebApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>().HasData(
        //        new Models.Users()
        //        {
        //            username = "sasa",
        //            password = "pass"
        //        });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
