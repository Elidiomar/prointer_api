using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prointer.Services.API.Models
{
    public class LogTarefa
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
