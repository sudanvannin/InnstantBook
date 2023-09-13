using InnstantBook.Models;

namespace InnstantBook.Repositorios.Interfaces
{
    public interface ICorreiosRepositorio
    {
        Task<EnderecoModel> BuscarEndereco(string cep);
    }
}
