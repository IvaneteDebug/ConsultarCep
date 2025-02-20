﻿namespace ConsultarCep.API.Models
{
    public class ViaCepResponse
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public bool Erro { get; set; }
    }
}
