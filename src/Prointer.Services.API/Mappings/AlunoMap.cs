using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prointer.Services.API.Models;

namespace Prointer.Infra.Data.Mappings.Blog
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {

            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(b => b.Alunos)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
                       
            builder.HasOne(p => p.Grupo)
                .WithMany(b => b.Alunos)
                .HasForeignKey(p => p.GrupoId);

            builder.ToTable("Alunos", schema: "data").HasKey(m => m.Id);
        }
    }
}