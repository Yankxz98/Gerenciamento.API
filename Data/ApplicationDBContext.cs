using GerenciamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<Contato> Contatos { get; set; }


    }
}
