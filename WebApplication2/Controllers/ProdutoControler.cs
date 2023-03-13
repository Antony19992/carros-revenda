using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Respository.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoControler : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoControler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> BuscarTodos()
        {
            List<ProdutoModel> produtos = await _produtoRepository.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepository.Adicionar(produtoModel);
            return Ok(produto);
        }
    }
}
