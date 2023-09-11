using InnstantBook.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnstantBook.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<ReservaModel>
    {
        public void Configure(EntityTypeBuilder<ReservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataInicio).IsRequired();
            builder.Property(x => x.DataFim).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.QuartoId).IsRequired();
            builder.Property(x => x.ClienteCPF).IsRequired();

        }
    }

}
