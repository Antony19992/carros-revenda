using WebApplication2.Models;

namespace WebApplication2.Respository.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<PessoaModel>> BuscarTodosUsuarios();
        Task<PessoaModel> BuscarPorId(int id);
        Task<PessoaModel> Adicionar(PessoaModel usuario);
        Task<PessoaModel> Atualizar(PessoaModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
