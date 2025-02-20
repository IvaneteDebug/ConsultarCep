namespace ConsultarCep.API.DTOs
{
    public class CepResponseDTO
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? Fonte { get; set; }
        public bool Erro { get; set; }

        public CepResponseDTO() { }
    }
}

