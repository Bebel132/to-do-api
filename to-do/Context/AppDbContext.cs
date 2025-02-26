using Microsoft.EntityFrameworkCore;
using to_do.Models;

namespace to_do.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().HasData(
                    new Tarefa { 
                        Id = 1, 
                        Titulo = "estudar", 
                        Desc = "", 
                        Status = true
                    }, 
                    new Tarefa
                    {
                        Id = 2,
                        Titulo = "tarefa - ismd",
                        Desc = "tarefa aleatória n 10",
                        Status = true
                    }
                );
        }
    }
}
