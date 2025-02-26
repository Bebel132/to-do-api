using Microsoft.EntityFrameworkCore;
using to_do.Context;
using to_do.Models;

namespace to_do.Services
{
    public class TarefasService : ITarefasService
    {
        private readonly AppDbContext _context;

        public TarefasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateTarefa(Tarefa Tarefa)
        {
            try
            {
                _context.Tarefas.Add(Tarefa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao criar tarefa", ex);
            }
        }

        public async Task DeleteTarefa(Tarefa Tarefa)
        {
            try
            {
                _context.Tarefas.Remove(Tarefa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao deletar tarefa", ex);
            }
        }

        public async Task<Tarefa> GetTarefa(int id)
        {
            try
            {
                var Tarefa = await _context.Tarefas.FindAsync(id);
                return Tarefa;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao obter tarefa", ex);
            }
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            try
            {
                return await _context.Tarefas.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao obter tarefas", ex);
            }
        }

        public async Task UpdateTarefa(Tarefa Tarefa)
        {
            try { 
                _context.Entry(Tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao atualizar tarefa", ex);
            }
        }

        public async Task AlterarStatusTarefa(Tarefa Tarefa)
        {
            try
            {
                Tarefa.Status = !Tarefa.Status;
                _context.Entry(Tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao atualizar tarefa", ex);
            }
        }

    }
}
