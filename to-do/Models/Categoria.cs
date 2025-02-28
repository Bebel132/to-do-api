using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace to_do.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}
