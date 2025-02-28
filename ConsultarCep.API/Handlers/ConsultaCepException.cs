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
            public CepNotFoundException(string cep)
                : base($"O CEP informado ({cep}) não foi encontrado.", cep) { }
        }

        public class InvalidCepException : ConsultaCepException
        {
            public InvalidCepException(string cep)
                : base($"O CEP informado ({cep}) está em um formato inválido.", cep) { }
        }

        public class CepAlreadyExistsException : ConsultaCepException
        {
            public CepAlreadyExistsException(string cep)
                : base($"O CEP informado ({cep}) já está cadastrado no sistema.", cep) { }
        }
    }
}
