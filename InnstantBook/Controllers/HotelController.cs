using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnstantBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepositorio _hotelRepositorio;

        public HotelController(IHotelRepositorio hotelRepositorio)
        {
            _hotelRepositorio = hotelRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<HotelModel>>> BuscarTodosHoteis()
        {
            List<HotelModel> hotel = await _hotelRepositorio.BuscarTodosHoteis();
            return Ok(hotel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelModel>> BuscarPorId(int id)
        {
            HotelModel hotel = await _hotelRepositorio.BuscarPorId(id);
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<HotelModel>> Cadastrar([FromBody] HotelModel hotelModel)
        {
            HotelModel hotel = await _hotelRepositorio.Adicionar(hotelModel);
            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HotelModel>> Atualizar([FromBody] HotelModel hotelModel, int id)
        {
            hotelModel.Id = id;
            HotelModel hotel = await _hotelRepositorio.Atualizar(hotelModel, id);
            return Ok(hotel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelModel>> Apagar(int id)
        {
            bool apagado = await _hotelRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
