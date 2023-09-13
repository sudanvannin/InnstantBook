using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InnstantBook.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly SistemaDeReservasDBContext _dbContext;

        public EnderecoRepositorio(SistemaDeReservasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EnderecoModel> Adicionar(EnderecoModel endereco)
        {
            await _dbContext.Enderecos.AddAsync(endereco);
            await _dbContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<EnderecoModel> BuscarEnderecoPorHotelId(string hotelId)
        {
            return await _dbContext.Enderecos.FirstOrDefaultAsync(e => e.IdHotel == hotelId);
        }

    }
}
