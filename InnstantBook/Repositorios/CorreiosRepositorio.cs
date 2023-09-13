using Correios.NET;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;

namespace InnstantBook.Repositorios
{
    public class CorreiosRepositorio : ICorreiosRepositorio
    {
        public async Task<EnderecoModel> BuscarEndereco(string cep)
        {
            var enderecos = await new Correios.NET.CorreiosService().GetAddressesAsync(cep);
            return new EnderecoModel {

                Estado = enderecos.FirstOrDefault().State,
                Cidade = enderecos.FirstOrDefault().City,
                Bairro = enderecos.FirstOrDefault().District,
                Rua = enderecos.FirstOrDefault().Street,
            };
        }
    }
}
