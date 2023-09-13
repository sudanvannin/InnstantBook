using InnstantBook.Controllers.Dtos;
using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InnstantBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepositorio _hotelRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        private readonly ICorreiosRepositorio _correiosRepositorio;

        public HotelController(IHotelRepositorio hotelRepositorio, ICorreiosRepositorio correiosRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _hotelRepositorio = hotelRepositorio;
            _correiosRepositorio = correiosRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<HotelModel>>> BuscarTodosHoteis()
        {
            List<HotelModel> hotel = await _hotelRepositorio.BuscarTodosHoteis();
            return Ok(hotel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelModel>> BuscarPorId(string id)
        {
            id = WebUtility.UrlDecode(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            HotelModel hotel = await _hotelRepositorio.BuscarPorId(id);
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<HotelModel>> Cadastrar([FromBody] CadastrarHotelRequest hotelRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            EnderecoModel endereco = await _correiosRepositorio.BuscarEndereco(hotelRequest.Cep);
            await _enderecoRepositorio.Adicionar(new EnderecoModel
            {
                Cep = hotelRequest.Cep,
                IdHotel = hotelRequest.CNPJ,
                Rua = endereco.Rua,
                Numero = "20",
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado
            });
            HotelModel hotel = await _hotelRepositorio.Adicionar(new HotelModel {
                CNPJ = hotelRequest.CNPJ,
                Nome = hotelRequest.Nome,
                Endereco = hotelRequest.Cep,
                IdsAvaliacoes = hotelRequest.IdsAvaliacoes,
                IdsQuartos = hotelRequest.IdsQuartos
            });
            
            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HotelModel>> Atualizar([FromBody] HotelModel hotelModel, string id)
        {
            id = WebUtility.UrlDecode(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            hotelModel.CNPJ = id;
            HotelModel hotel = await _hotelRepositorio.Atualizar(hotelModel, id);
            return Ok(hotel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelModel>> Apagar(string id)
        {
            id = WebUtility.UrlDecode(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _hotelRepositorio.Apagar(id);
            return NoContent();
        }
    }
}
