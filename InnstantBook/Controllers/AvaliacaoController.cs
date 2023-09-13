using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnstantBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _avaliacaoRepositorio;

        public AvaliacaoController(IAvaliacaoRepositorio avaliacaoRepositorio)
        {
            _avaliacaoRepositorio = avaliacaoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<AvaliacaoModel>>> BuscarTodasAvaliacoes()
        {
            List<AvaliacaoModel> avaliacao = await _avaliacaoRepositorio.BuscarTodasAvaliacoes();
            return Ok(avaliacao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoModel>> BuscarPorId(int id)
        {
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.BuscarPorId(id);
            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<ActionResult<AvaliacaoModel>> Cadastrar([FromBody] AvaliacaoModel avaliacaoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Adicionar(avaliacaoModel);
            return Ok(avaliacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AvaliacaoModel>> Atualizar([FromBody] AvaliacaoModel avaliacaoModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            avaliacaoModel.Id = id;
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Atualizar(avaliacaoModel, id);
            return Ok(avaliacao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AvaliacaoModel>> Apagar(int id)
        {
            await _avaliacaoRepositorio.Apagar(id);
            return NoContent();
        }
    }
}
