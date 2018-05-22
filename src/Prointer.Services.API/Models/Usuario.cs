
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prointer.Services.API.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool Active { get; set; }

        public bool TipoProfessor { get; set; }

        [JsonIgnore]
        public ICollection<Aluno> Alunos { get; set; } = new HashSet<Aluno>();

        [JsonIgnore]
        public ICollection<Professor> Professores { get; set; } = new HashSet<Professor>();
    }
}
