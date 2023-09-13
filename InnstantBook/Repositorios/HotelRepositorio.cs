using Microsoft.EntityFrameworkCore;
using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Correios.NET.Models;

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
            return await _dbContext.Hoteis.FromSqlRaw(@"WITH QuartosAgregados AS (SELECT HotelCNPJ, STRING_AGG(Quartos.Id, ', ') AS IdsQuartos FROM DB_SistemaDeReservasAPI.dbo.Quartos GROUP BY HotelCNPJ), AvaliacoesAgregadas AS (SELECT HotelCNPJ, STRING_AGG(Avaliacoes.Id, ', ') AS IdsAvaliacoes FROM DB_SistemaDeReservasAPI.dbo.Avaliacoes GROUP BY HotelCNPJ) SELECT h.CNPJ, ISNULL(qa.IdsQuartos, '') AS IdsQuartos, ISNULL(aa.IdsAvaliacoes, '') AS IdsAvaliacoes, h.Nome, CONCAT(e.Rua, ', ', e.Numero, ', ', e.Bairro, ', ', e.Cidade, ', ', e.Estado, ', ', e.Cep) AS Endereco FROM DB_SistemaDeReservasAPI.dbo.Hoteis h LEFT JOIN QuartosAgregados qa ON h.CNPJ = qa.HotelCNPJ LEFT JOIN AvaliacoesAgregadas aa ON h.CNPJ = aa.HotelCNPJ LEFT JOIN DB_SistemaDeReservasAPI.dbo.Enderecos e ON h.CNPJ = e.IdHotel ORDER BY h.CNPJ;").ToListAsync();
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
