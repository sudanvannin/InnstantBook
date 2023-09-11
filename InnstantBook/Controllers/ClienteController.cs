using InnstantBook.Models;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnstantBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()
        {
            List<ClienteModel> cliente = await _clienteRepositorio.BuscarTodosClientes();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ClienteModel cliente = await _clienteRepositorio.Adicionar(clienteModel);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Atualizar([FromBody] ClienteModel clienteModel, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            clienteModel.CPF = id;
            ClienteModel cliente = await _clienteRepositorio.Atualizar(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> Apagar(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool apagado = await _clienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
