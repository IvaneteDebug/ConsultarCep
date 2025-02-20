namespace ConsultarCep.API.Models
{
    public class ConsultaCep
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; } 
        public string? Bairro { get; set; } 
        public string? Cidade { get; set; } 
        public string? Estado { get; set; } 
        public string? Fonte { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}