using ConsultarCep.API.DTOs;

namespace ConsultarCep.API.Https
{
    public interface ICepHttpClient
    {
        Task<CepResponseDTO?> GetAddressByCepAsync(string cep);
    }
}
