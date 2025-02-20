using ConsultarCep.API.DTOs;

namespace ConsultarCep.API.Services
{
    public interface ICepService
    {
        Task<CepResponseDTO?> ConsultarCep(string cep);
    }
}