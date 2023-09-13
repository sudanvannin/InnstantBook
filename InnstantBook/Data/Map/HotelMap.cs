using InnstantBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnstantBook.Data.Map
{
    public class HotelMap : IEntityTypeConfiguration<HotelModel>
    {
        public void Configure(EntityTypeBuilder<HotelModel> builder)
        {
            builder.HasKey(x => x.CNPJ);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Endereco);
        }
    }
    }
