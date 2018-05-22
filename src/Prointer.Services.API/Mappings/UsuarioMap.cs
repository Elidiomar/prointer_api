using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prointer.Services.API.Models;

namespace Prointer.Infra.Data.Mappings.Blog
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.ToTable("Usuarios", schema: "data").HasKey(m => m.Id);
        }
    }
}