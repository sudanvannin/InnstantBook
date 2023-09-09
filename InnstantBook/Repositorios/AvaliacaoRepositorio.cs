using Microsoft.EntityFrameworkCore;
using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;

namespace InnstantBook.Repositorios
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private readonly SistemaDeReservasDBContext _dbContext;

        public AvaliacaoRepositorio(SistemaDeReservasDBContext sistemaDeReservasDBContext)
        {
            _dbContext = sistemaDeReservasDBContext;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes()
        {
            return await _dbContext.Avaliacoes.ToListAsync();
        }

        public async Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao)
        {
            await _dbContext.Avaliacoes.AddAsync(avaliacao);
            await _dbContext.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);

            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliacao para o ID: {id} não foi encontrada no banco de dados");
            }

            avaliacaoPorId.Nota = avaliacao.Nota;
            avaliacaoPorId.Comentario = avaliacao.Comentario;
            avaliacaoPorId.HotelId = avaliacao.HotelId;

            _dbContext.Avaliacoes.Update(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();

            return avaliacaoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);

            if (avaliacaoPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados");
            }

            _dbContext.Avaliacoes.Remove(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
