using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prointer.Services.API.Models
{
    public class Tarefa
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        //public Professor Professor { get; set; }
        //public Grupo Grupo { get; set; }

        [Required]
        public Guid GrupoId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Grupo Grupo { get; set; }        

        public DateTime DateAdded { get; set; }

    }
}
