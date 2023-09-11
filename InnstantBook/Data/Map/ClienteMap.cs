using InnstantBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnstantBook.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
        builder.HasKey(x => x.CPF);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        }
    }

}

