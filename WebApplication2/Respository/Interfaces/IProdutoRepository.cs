using WebApplication2.Models;

namespace WebApplication2.Respository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoModel usuario);
        Task<ProdutoModel> Atualizar(ProdutoModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
