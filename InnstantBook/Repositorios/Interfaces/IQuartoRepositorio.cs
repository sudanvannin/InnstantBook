using InnstantBook.Models;

namespace InnstantBook.Repositorios.Interfaces
{
    public interface IQuartoRepositorio
    {
        Task<List<QuartoModel>> BuscarTodosQuartos();
        Task<QuartoModel> BuscarPorId(int id);
        Task<QuartoModel> Adicionar(QuartoModel quarto);
        Task<QuartoModel> Atualizar(QuartoModel quarto, int id);
        Task<bool> Apagar(int id);
    }
}
