using InnstantBook.Models;

namespace InnstantBook.Repositorios.Interfaces
{
    public interface IHotelRepositorio
    {
        Task<List<HotelModel>> BuscarTodosHoteis();
        Task<HotelModel> BuscarPorId(string id);
        Task<HotelModel> Adicionar(HotelModel hotel);
        Task<HotelModel> Atualizar(HotelModel hotel, string id);
        Task<bool> Apagar(string id);
    }
}
