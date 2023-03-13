using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.Map;

namespace WebApplication2.Data
{
    public class PessoaDBContext : DbContext
    {
        public PessoaDBContext(DbContextOptions<PessoaDBContext> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
