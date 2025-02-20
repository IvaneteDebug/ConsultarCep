using ConsultarCep.API.DTOs;
using ConsultarCep.API.Handlers;
using ConsultarCep.API.Https;
using ConsultarCep.API.Models;
using ConsultarCep.API.Repositories;

namespace ConsultarCep.API.Services
{
    public class CepService : ICepService
    {
        private readonly ICepHttpClient _viaCepHttpClient;
        private readonly IConsultarCepRepository _repository;

        public CepService(ICepHttpClient viaCepHttpClient, IConsultarCepRepository repository)
        {
            _viaCepHttpClient = viaCepHttpClient;
            _repository = repository;
        }

        public async Task<CepResponseDTO?> ConsultarCep(string cep)
        {
            var cepExistente = await _repository.ObterCepAsync(cep);
            if (cepExistente != null)
            {
                throw new ConsultaCepException.CepAlreadyExistsException(
                    "CEP já cadastrado.",
                    cepExistente.Cep!
                );
            }

            var response = await _viaCepHttpClient.GetAddressByCepAsync(cep);
            if (response == null || response.Erro)
            {
                throw new ConsultaCepException.CepNotFoundException(
                    "CEP não encontrado ou erro na consulta.",
                    cep
                );
            }

            var cepConsulta = new ConsultaCep
            {
                Cep = response.Cep,
                Logradouro = response.Logradouro,
                Bairro = response.Bairro,
                Cidade = response.Localidade,
                Estado = response.Uf,
                Fonte = "ViaCep",
                DataConsulta = DateTime.Now
            };

            await _repository.SalvarCepAsync(cepConsulta);

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
