using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prointer.Services.API.Models
{
    public class Aluno
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        [Required]
        public Guid GrupoId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Grupo Grupo { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
