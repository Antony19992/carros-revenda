using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Respository.Interfaces;

namespace WebApplication2.Respository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PessoaDBContext _dbContext;
        public ProdutoRepository(PessoaDBContext pessoaDBContext)
        {
            _dbContext = pessoaDBContext;
        }
        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produto = await BuscarPorId(id);
            if(produto == null)
            {
                return false;
            }
            produto.Ativo = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel usuario, int id)
        {
            ProdutoModel produto = await BuscarPorId(id);
            if(produto != null)
            {
                produto.Descricao = usuario.Descricao;
                produto.Preco = usuario.Preco;
                produto.Ativo = usuario.Ativo;
                await _dbContext.SaveChangesAsync();
                return produto;
            }
            throw new Exception("Produto não encontrado");
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }
}
