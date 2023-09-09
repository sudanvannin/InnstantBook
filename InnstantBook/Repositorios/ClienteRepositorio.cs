using Microsoft.EntityFrameworkCore;
using InnstantBook.Data;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;

namespace InnstantBook.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly SistemaDeReservasDBContext _dbContext;

        public ClienteRepositorio(SistemaDeReservasDBContext sistemaDeReservasDBContext)
        {
            _dbContext = sistemaDeReservasDBContext;
        }

        public async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Avaliacao para o ID: {id} não foi encontrada no banco de dados");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Email = cliente.Email;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontradao no banco de dados");
            }

            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
