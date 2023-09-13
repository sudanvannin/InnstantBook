using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnstantBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : ControllerBase
    {
        private readonly IQuartoRepositorio _quartoRepositorio;

        public QuartoController(IQuartoRepositorio quartoRepositorio)
        {
            _quartoRepositorio = quartoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<QuartoModel>>> BuscarTodosQuartos()
        {
            List<QuartoModel> quarto = await _quartoRepositorio.BuscarTodosQuartos();
            return Ok(quarto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuartoModel>> BuscarPorId(int id)
        {
            QuartoModel quarto = await _quartoRepositorio.BuscarPorId(id);
            return Ok(quarto);
        }

        [HttpPost]
        public async Task<ActionResult<QuartoModel>> Cadastrar([FromBody] QuartoModel quartoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            QuartoModel quarto = await _quartoRepositorio.Adicionar(quartoModel);
            return Ok(quarto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuartoModel>> Atualizar([FromBody] QuartoModel quartoModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            quartoModel.Id = id;
            QuartoModel quarto = await _quartoRepositorio.Atualizar(quartoModel, id);
            return Ok(quarto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<QuartoModel>> Apagar(int id)
        {
            await _quartoRepositorio.Apagar(id);
            return NoContent();
        }
    }
}
