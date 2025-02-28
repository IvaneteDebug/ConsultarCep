using ConsultarCep.API.Handlers;
using ConsultarCep.API.Models;
using ConsultarCep.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ConsultarCep.API.Repositories
{
    public class ConsultarCepRepository : IConsultarCepRepository
    {
        private readonly ConsultaCepDbContext _context;

        public ConsultarCepRepository(ConsultaCepDbContext context)
        {
            _context = context;
        }

        public async Task<ConsultaCep?> ObterCepAsync(string cep)
        {
            return await _context.CepsConsultados.FirstOrDefaultAsync(c => c.Cep == cep);
        }

        public async Task SalvarCepAsync(ConsultaCep cep)
        {
            var cepExistente = await ObterCepAsync(cep.Cep!);
            if (cepExistente != null)
            {
                throw new ConsultaCepException.CepAlreadyExistsException("CEP já cadastrado.");
            }

            _context.CepsConsultados.Add(cep);
            await _context.SaveChangesAsync();
        }
    }
}
