using InnstantBook.Data.Map;
using InnstantBook.Models;
using Microsoft.EntityFrameworkCore;

namespace InnstantBook.Data
{
    public class SistemaDeReservasDBContext : DbContext
    {
        public SistemaDeReservasDBContext(DbContextOptions<SistemaDeReservasDBContext> options) : base(options) { }

        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<HotelModel> Hoteis { get; set; }
        public DbSet<QuartoModel> Quartos { get; set; }
        public DbSet<ReservaModel> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new HotelMap());
            modelBuilder.ApplyConfiguration(new QuartoMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
