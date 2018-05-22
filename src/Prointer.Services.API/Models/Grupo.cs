using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prointer.Services.API.Models
{
    public class Grupo
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public List<Tarefa> Tarefas { get; set; }

        [Required]
        public Guid ProfessorId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Professor Professor { get; set; }

        [JsonIgnore]
        public ICollection<Aluno> Alunos { get; set; } = new HashSet<Aluno>();

        [JsonIgnore]
        public ICollection<Tarefa> Tarefas { get; set; } = new HashSet<Tarefa>();

        public DateTime DateAdded { get; set; }
    }
}
