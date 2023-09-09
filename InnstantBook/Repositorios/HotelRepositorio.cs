using Microsoft.EntityFrameworkCore;
using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;

namespace InnstantBook.Repositorios
{
    public class HotelRepositorio : IHotelRepositorio
    {
        private readonly SistemaDeReservasDBContext _dbContext;

        public HotelRepositorio(SistemaDeReservasDBContext sistemaDeReservasDBContext)
        {
            _dbContext = sistemaDeReservasDBContext;
        }

        public async Task<HotelModel> BuscarPorId(int id)
        {
            return await _dbContext.Hoteis.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<HotelModel>> BuscarTodosHoteis()
        {
            var r = await _dbContext.Hoteis.FromSqlRaw("SELECT Hoteis.Id, STRING_AGG(Quartos.Id, ', ') AS IdsQuartos, Hoteis.Nome, Hoteis.Endereco FROM DB_SistemaDeReservasAPI.dbo.Hoteis JOIN DB_SistemaDeReservasAPI.dbo.Quartos ON Hoteis.Id = Quartos.HotelId GROUP BY Hoteis.Id, Hoteis.Nome, Hoteis.Endereco ORDER BY Hoteis.Id;\r\n").ToListAsync();
            return (r);
        }

        public async Task<HotelModel> Adicionar(HotelModel hotel)
        {
            await _dbContext.Hoteis.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();

            return hotel;
        }

        public async Task<HotelModel> Atualizar(HotelModel hotel, int id)
        {
            HotelModel hotelPorId = await BuscarPorId(id);

            if (hotelPorId == null)
            {
                throw new Exception($"Hotel para o ID: {id} não foi encontrada no banco de dados");
            }

            hotelPorId.Nome = hotel.Nome;
            hotelPorId.Endereco = hotel.Endereco;

            _dbContext.Hoteis.Update(hotelPorId);
            await _dbContext.SaveChangesAsync();

            return hotelPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            HotelModel hotelPorId = await BuscarPorId(id);

            if (hotelPorId == null)
            {
                throw new Exception($"Hotel para o ID: {id} não foi encontradao no banco de dados");
            }

            _dbContext.Hoteis.Remove(hotelPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
