using InnstantBook.Models;

namespace InnstantBook.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorId(string id);
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, string id);
        Task<bool> Apagar(string id);
    }
}
