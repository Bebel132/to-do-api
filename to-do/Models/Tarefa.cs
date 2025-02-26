using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
    }
}
