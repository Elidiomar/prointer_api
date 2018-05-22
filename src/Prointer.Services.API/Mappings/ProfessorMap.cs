using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prointer.Services.API.Models;

namespace Prointer.Infra.Data.Mappings.Blog
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany(b => b.Professores)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Professores", schema: "data").HasKey(m => m.Id);
        }
    }
}