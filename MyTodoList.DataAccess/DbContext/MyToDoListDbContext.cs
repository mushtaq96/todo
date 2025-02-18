using Microsoft.EntityFrameworkCore;
using MyTodoList.DataAccess.Entities;
using MyTodoList.DataAccess.EntitiyConfigurations;

namespace MyTodoList.DataAccess.DbContext
{
    public class MyToDoListDbContext : Microsoft.EntityFrameworkCore.DbContext, IDisposable
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryTodoTasksDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ToDoTasKConfiguration());
        }

        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
