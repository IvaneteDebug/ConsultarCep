using ConsultarCep.API.Models;

namespace ConsultarCep.API.Repositories
{
    public interface IConsultarCepRepository
    {
        Task<ConsultaCep?> ObterCepAsync(string cep);
        Task SalvarCepAsync(ConsultaCep cep);
    }
}
