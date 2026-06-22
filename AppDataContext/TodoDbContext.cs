using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.AppDataContext
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        // DbSet property to represent the Todo table
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(t => t.Id)
                .HasColumnType("binary(16)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine); // Logs to
        }

    }

}