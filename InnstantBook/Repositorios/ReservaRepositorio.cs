using Microsoft.EntityFrameworkCore;
using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;

namespace InnstantBook.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly SistemaDeReservasDBContext _dbContext;

        public ReservaRepositorio(SistemaDeReservasDBContext sistemaDeReservasDBContext)
        {
            _dbContext = sistemaDeReservasDBContext;
        }

        public async Task<ReservaModel> BuscarPorId(int id)
        {
            return await _dbContext.Reservas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReservaModel>> BuscarTodasReservas()
        {
            return await _dbContext.Reservas.ToListAsync();
        }

        public async Task<ReservaModel> Adicionar(ReservaModel reserva)
        {
            await _dbContext.Reservas.AddAsync(reserva);
            await _dbContext.SaveChangesAsync();

            return reserva;
        }

        public async Task<ReservaModel> Atualizar(ReservaModel reserva, int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);

            if (reservaPorId == null)
            {
                throw new Exception($"Avaliacao para o ID: {id} não foi encontrada no banco de dados");
            }

            reservaPorId.DataInicio = reserva.DataInicio;
            reservaPorId.DataFim = reserva.DataFim;
            reservaPorId.QuartoId = reserva.QuartoId;
            reservaPorId.ClienteId = reserva.ClienteId;

            _dbContext.Reservas.Update(reservaPorId);
            await _dbContext.SaveChangesAsync();

            return reservaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);

            if (reservaPorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontradao no banco de dados");
            }

            _dbContext.Reservas.Remove(reservaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
