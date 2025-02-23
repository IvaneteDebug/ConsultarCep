using ConsultarCep.API.DTOs;

namespace ConsultarCep.API.Https
{
    public interface IViaCepIntegrationService
    {
        Task<CepResponseDTO?> GetAddressByCepAsync(string cep);
    }
}
