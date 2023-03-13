using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Respository.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _usuarioRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _usuarioRepository = pessoaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaModel>>> BuscarTodos()
        {
            List<PessoaModel> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PessoaModel>>> BuscarPorId(int id)
        {
            PessoaModel usuario = await _usuarioRepository.BuscarPorId(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody]PessoaModel pessoa)
        {
            PessoaModel usuario = await _usuarioRepository.Adicionar(pessoa);
            return Ok(usuario);
        }
    }
}
