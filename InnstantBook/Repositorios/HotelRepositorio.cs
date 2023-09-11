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

        public async Task<HotelModel> BuscarPorId(string id)
        {
            return await _dbContext.Hoteis.FirstOrDefaultAsync(x => x.CNPJ == id);
        }

        public async Task<List<HotelModel>> BuscarTodosHoteis()
        {
            return await _dbContext.Hoteis.FromSqlRaw(@"WITH QuartosAgregados AS (SELECT HotelCNPJ, STRING_AGG(Quartos.Id, ', ') AS IdsQuartos FROM DB_SistemaDeReservasAPI.dbo.Quartos GROUP BY HotelCNPJ), AvaliacoesAgregadas AS (SELECT HotelCNPJ, STRING_AGG(Avaliacoes.Id, ', ') AS IdsAvaliacoes FROM DB_SistemaDeReservasAPI.dbo.Avaliacoes GROUP BY HotelCNPJ) SELECT Hoteis.CNPJ, NULLIF(ISNULL(QuartosAgregados.IdsQuartos, ''), '') AS IdsQuartos, NULLIF(ISNULL(AvaliacoesAgregadas.IdsAvaliacoes, ''), '') AS IdsAvaliacoes, Hoteis.Nome, Hoteis.Endereco FROM DB_SistemaDeReservasAPI.dbo.Hoteis LEFT JOIN QuartosAgregados ON Hoteis.CNPJ = QuartosAgregados.HotelCNPJ LEFT JOIN AvaliacoesAgregadas ON Hoteis.CNPJ = AvaliacoesAgregadas.HotelCNPJ ORDER BY Hoteis.CNPJ;").ToListAsync();
        }

        public async Task<HotelModel> Adicionar(HotelModel hotel)
        {
            await _dbContext.Hoteis.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();

            return hotel;
        }

        public async Task<HotelModel> Atualizar(HotelModel hotel, string id)
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

        public async Task<bool> Apagar(string id)
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
