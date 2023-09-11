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

        public async Task<ClienteModel> BuscarPorId(string id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.CPF == id);
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.FromSqlRaw("SELECT Clientes.CPF, STRING_AGG(Reservas.Id, ', ') AS IdsReservas, Clientes.Nome, Clientes.Email FROM DB_SistemaDeReservasAPI.dbo.Clientes LEFT JOIN DB_SistemaDeReservasAPI.dbo.Reservas ON Clientes.CPF = Reservas.ClienteCPF GROUP BY Clientes.CPF, Clientes.Nome, Clientes.Email ORDER BY Clientes.CPF;").ToListAsync();
        }

        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {

            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ClienteModel> Atualizar(ClienteModel cliente, string id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrada no banco de dados");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Email = cliente.Email;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Apagar(string id)
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
