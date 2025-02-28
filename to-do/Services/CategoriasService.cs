using Microsoft.EntityFrameworkCore;
using to_do.Context;
using to_do.Models;

namespace to_do.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly AppDbContext _context;

        public CategoriasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategoria(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao criar categoria", ex);
            }
        }

        public async Task DeleteCategoria(Categoria categoria)
        {
            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao deletar categoria", ex);
            }
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                return categoria;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao obter categoria", ex);
            }
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao obter categorias", ex);
            }
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            try
            {
                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("erro ao obter categorias", ex);
            }
        }
    }
}
