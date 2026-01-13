using GestaoResidencialMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoResidencialMVC.Data
{
    public class ConexaoBanco : DbContext
    {
        public ConexaoBanco(DbContextOptions<ConexaoBanco> options) : base(options)
        {
            
        }
        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
