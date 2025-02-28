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
		public DbSet<Categoria> Categorias { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Tarefas)
                .WithOne(t => t.Categoria)
                .HasForeignKey(t => t.CategoriaId);

            modelBuilder.Entity<Categoria>().HasData(
				new Categoria { Id = 1, Nome = "Estudos" },
				new Categoria { Id = 2, Nome = "Trabalho" }
			);

			modelBuilder.Entity<Tarefa>().HasData(
                    new Tarefa { 
                        Id = 1, 
                        Titulo = "trabalhar", 
                        Desc = "", 
                        Status = true,
                        CategoriaId = 1
                    }, 
                    new Tarefa
                    {
                        Id = 2,
                        Titulo = "tarefa - ismd",
                        Desc = "tarefa aleatória n 10",
                        Status = true,
                        CategoriaId = 2
                    }
                );
        }
    }
}
