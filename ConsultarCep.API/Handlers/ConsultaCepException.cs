namespace ConsultarCep.API.Handlers
{
    public class ConsultaCepException : Exception
    {
        public string? Cep { get; }

        public ConsultaCepException(string message, string? cep = null) : base(message)
        {
            Cep = cep;
        }

        public class CepNotFoundException : ConsultaCepException
        {
            public CepNotFoundException(string message, string cep)
                : base($"CEP não encontrado: {message}", cep) { }
        }

        public class InvalidCepException : ConsultaCepException
        {
            public InvalidCepException(string message, string cep)
                : base($"Formato inválido para o CEP: {message}", cep) { }
        }

        public class CepAlreadyExistsException : ConsultaCepException
        {
            public CepAlreadyExistsException(string message, string cep)
                : base($"Erro: {message} - CEP: {cep}", cep) { }
        }
    }
}

