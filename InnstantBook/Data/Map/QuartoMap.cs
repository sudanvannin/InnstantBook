using InnstantBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnstantBook.Data.Map
{
    public class QuartoMap : IEntityTypeConfiguration<QuartoModel>
    {
        public void Configure(EntityTypeBuilder<QuartoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.HotelId).IsRequired();

        }
    }
}
