using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Respository.Interfaces;

namespace WebApplication2.Respository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaDBContext _dbContext;
        public PessoaRepository(PessoaDBContext pessoaDBContext)
        {
            _dbContext = pessoaDBContext;
        }
        public async Task<PessoaModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PessoaModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<PessoaModel> Adicionar(PessoaModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
        public async Task<PessoaModel> Atualizar(PessoaModel usuario, int id)
        {
            PessoaModel pessoa = await BuscarPorId(id);
            if(pessoa == null)
            {
                throw new ArgumentException("Usuário não encontrado");
            }
            pessoa.Nome = usuario.Nome;
            pessoa.Email = usuario.Email;

            _dbContext.Usuarios.Update(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> Apagar(int id)
        {
            PessoaModel pessoa = await BuscarPorId(id);
            if(pessoa == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            _dbContext.Usuarios.Remove(pessoa);
            await _dbContext.SaveChangesAsync();
            return true;

        }

    }
}
