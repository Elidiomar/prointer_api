using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prointer.Infra.Data.Mappings.Blog;

namespace Prointer.Services.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Prointer.Services.API.Models.Aluno> Alunos { get; set; }
        public DbSet<Prointer.Services.API.Models.Professor> Professores { get; set; }
        public DbSet<Prointer.Services.API.Models.Grupo> Grupos { get; set; }
        public DbSet<Prointer.Services.API.Models.Tarefa> Tarefas { get; set; }
        public DbSet<Prointer.Services.API.Models.Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new AlunoMap());
            builder.ApplyConfiguration(new ProfessorMap());
            builder.ApplyConfiguration(new GrupoMap());
            builder.ApplyConfiguration(new TarefaMap());
            builder.ApplyConfiguration(new UsuarioMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

         
            //optionsBuilder.UseSqlServer(config.GetSection("ConnectionString")["DefaultConnection"]);
        }
    }
}
