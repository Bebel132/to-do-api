using to_do.Models;

namespace to_do.Services
{
    public interface ICategoriasService
    {
        Task<IEnumerable<Categoria>> GetCategorias();

        Task<Categoria> GetCategoria(int id);

        Task CreateCategoria(Categoria categoria);

        Task UpdateCategoria(Categoria categoria);

        Task DeleteCategoria(Categoria categoria);
    }
}
