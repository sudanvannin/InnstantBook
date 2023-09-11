using Microsoft.EntityFrameworkCore;
using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;

namespace InnstantBook.Repositorios
{
    public class QuartoRepositorio : IQuartoRepositorio
    {
        private readonly SistemaDeReservasDBContext _dbContext;

        public QuartoRepositorio(SistemaDeReservasDBContext sistemaDeReservasDBContext)
        {
            _dbContext = sistemaDeReservasDBContext;
        }

        public async Task<QuartoModel> BuscarPorId(int id)
        {
            return await _dbContext.Quartos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<QuartoModel>> BuscarTodosQuartos()
        {
            return await _dbContext.Quartos.FromSqlRaw("SELECT Quartos.Id, NULLIF(STRING_AGG(Reservas.Id, ', '), '') AS IdsReservas, Quartos.Numero, Quartos.Preco, Quartos.Status, Quartos.HotelCNPJ FROM DB_SistemaDeReservasAPI.dbo.Quartos LEFT JOIN DB_SistemaDeReservasAPI.dbo.Reservas ON Quartos.Id = Reservas.QuartoId GROUP BY Quartos.Id, Quartos.Numero, Quartos.Preco, Quartos.Status, Quartos.HotelCNPJ ORDER BY Quartos.Id;").ToListAsync();
        }

        public async Task<QuartoModel> Adicionar(QuartoModel quarto)
        {
            await _dbContext.Quartos.AddAsync(quarto);
            await _dbContext.SaveChangesAsync();

            return quarto;
        }

        public async Task<QuartoModel> Atualizar(QuartoModel quarto, int id)
        {
            QuartoModel quartoPorId = await BuscarPorId(id);

            if (quartoPorId == null)
            {
                throw new Exception($"Quarto para o ID: {id} não foi encontrada no banco de dados");
            }

            quartoPorId.Numero = quarto.Numero;
            quartoPorId.Preco = quarto.Preco;
            quartoPorId.Status = quarto.Status;
            quartoPorId.HotelCNPJ = quarto.HotelCNPJ;

            _dbContext.Quartos.Update(quartoPorId);
            await _dbContext.SaveChangesAsync();

            return quartoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            QuartoModel quartoPorId = await BuscarPorId(id);

            if (quartoPorId == null)
            {
                throw new Exception($"Quarto para o ID: {id} não foi encontradao no banco de dados");
            }

            _dbContext.Quartos.Remove(quartoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
