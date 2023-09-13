using InnstantBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnstantBook.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.HasKey(x => x.Cep);
            builder.Property(x => x.Rua);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Bairro);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Estado);
            builder.Property(x => x.IdHotel);
        }
    }
}
