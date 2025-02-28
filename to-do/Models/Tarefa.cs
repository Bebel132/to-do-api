using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace to_do.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Titulo { get; set; }

        public string Desc { get; set; }

        [Required]
        public required bool Status { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Categoria? Categoria { get; set; }
    }
}
