using ConsultarCep.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultarCep.API.Persistence
{
    public class ConsultaCepDbContext : DbContext
    {
        public ConsultaCepDbContext(DbContextOptions<ConsultaCepDbContext> options) : base(options) { }

        public DbSet<ConsultaCep> CepsConsultados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConsultaCep>(e =>
            {
                e.HasKey(e => e.Id);
            });
        }
    }
}

