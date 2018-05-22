using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prointer.Services.API.Models;

namespace Prointer.Infra.Data.Mappings.Blog
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Professor)
                .WithMany(b => b.Grupos)
                .HasForeignKey(p => p.ProfessorId);

            builder.ToTable("Grupos", schema: "data").HasKey(m => m.Id);
        }
    }
}