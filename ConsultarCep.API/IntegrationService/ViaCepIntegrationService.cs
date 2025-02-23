using ConsultarCep.API.DTOs;
using System.Text.Json;

namespace ConsultarCep.API.Https
{
    public class ViaCepIntegrationService : IViaCepIntegrationService
    {
        private readonly HttpClient _httpClient;
        private const string ViaCepUrl = "https://viacep.com.br/ws/{0}/json/";

        public ViaCepIntegrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepResponseDTO?> GetAddressByCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync(string.Format(ViaCepUrl, cep));
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<CepResponseDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
