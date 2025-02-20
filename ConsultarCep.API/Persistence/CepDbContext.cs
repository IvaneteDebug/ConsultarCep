using ConsultarCep.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultarCep.API.Persistence
{
    public class CepDbContext : DbContext
    {
        public CepDbContext(DbContextOptions<CepDbContext> options) : base(options) { }

        public DbSet<ConsultaCep> CepsConsultados { get; set; }
    }
}

