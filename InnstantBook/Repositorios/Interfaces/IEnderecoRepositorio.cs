using InnstantBook.Models;

namespace InnstantBook.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<EnderecoModel> Adicionar(EnderecoModel hotel);
        Task<EnderecoModel> BuscarEnderecoPorHotelId(string hotelId);

    }
}
