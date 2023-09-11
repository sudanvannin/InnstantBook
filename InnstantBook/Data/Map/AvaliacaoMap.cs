using InnstantBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnstantBook.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nota).IsRequired();
            builder.Property(x => x.Comentario).HasMaxLength(500);
            builder.Property(x => x.HotelCNPJ).IsRequired();
        }
    }
}
