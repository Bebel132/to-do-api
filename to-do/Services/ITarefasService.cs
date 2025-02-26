using to_do.Context;
using to_do.Models;

namespace to_do.Services
{
    public interface ITarefasService
    {
        Task<IEnumerable<Tarefa>> GetTarefas();

        Task<Tarefa> GetTarefa(int id);

        Task CreateTarefa(Tarefa Tarefa);

        Task UpdateTarefa(Tarefa Tarefa);

        Task DeleteTarefa(Tarefa Tarefa);

        Task AlterarStatusTarefa(Tarefa Tarefa);

    }
}
