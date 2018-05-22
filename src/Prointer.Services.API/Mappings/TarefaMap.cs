using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prointer.Services.API.Models;

namespace Prointer.Infra.Data.Mappings.Blog
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Grupo)
                .WithMany(b => b.Tarefas)
                .HasForeignKey(p => p.GrupoId);

            builder.ToTable("Tarefas", schema: "data").HasKey(m => m.Id);
        }
    }
}