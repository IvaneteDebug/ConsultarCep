using ConsultarCep.API.DTOs;
using ConsultarCep.API.Handlers;
using ConsultarCep.API.Https;
using ConsultarCep.API.Models;
using ConsultarCep.API.Repositories;

namespace ConsultarCep.API.Services
{
    public class CepService : ICepService
    {
        private readonly IViaCepIntegrationService _viaCepHttpClient;
        private readonly IConsultarCepRepository _repository;

        public CepService(IViaCepIntegrationService viaCepHttpClient, IConsultarCepRepository repository)
        {
            _viaCepHttpClient = viaCepHttpClient;
            _repository = repository;
        }

        public async Task<CepResponseDTO?> ConsultarCep(string cep)
        {
            var cepExistente = await _repository.ObterCepAsync(cep);
            if (cepExistente != null)
            {
                return new CepResponseDTO
                {
                    Cep = cepExistente.Cep,
                    Logradouro = cepExistente.Logradouro,
                    Bairro = cepExistente.Bairro,
                    Localidade = cepExistente.Cidade,
                    Uf = cepExistente.Estado,
                    Fonte = "Banco de Dados"
                };
            }

            var response = await _viaCepHttpClient.GetAddressByCepAsync(cep);
            if (response == null || response.Erro)
            {
                throw new ConsultaCepException.CepNotFoundException(
                    "CEP não encontrado ou erro na consulta."
                    
                );
            }

            var consultaCep = new ConsultaCep
            {
                Cep = response.Cep,
                Logradouro = response.Logradouro,
                Bairro = response.Bairro,
                Cidade = response.Localidade,
                Estado = response.Uf,
                Fonte = "ViaCep",
                DataConsulta = DateTime.Now
            };

            await _repository.SalvarCepAsync(consultaCep);

            return new CepResponseDTO
            {
                Cep = response.Cep,
                Logradouro = response.Logradouro,
                Bairro = response.Bairro,
                Localidade = response.Localidade,
                Uf = response.Uf,
                Fonte = "ViaCep"
            };
        }
    }
}
