using InnstantBook.Models;

namespace InnstantBook.Repositorios.Interfaces
{
    public interface IHotelRepositorio
    {
        Task<List<HotelModel>> BuscarTodosHoteis();
        Task<HotelModel> BuscarPorId(int id);
        Task<HotelModel> Adicionar(HotelModel hotel);
        Task<HotelModel> Atualizar(HotelModel hotel, int id);
        Task<bool> Apagar(int id);
    }
}
