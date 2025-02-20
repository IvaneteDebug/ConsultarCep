using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConsultarCep.API.Handlers
{
    public class ConsultaCepHandlerException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = 500;
            object response;

            response = HandleException(context.Exception, out statusCode);

            context.Result = new ObjectResult(response) { StatusCode = statusCode };
            context.ExceptionHandled = true;
        }

        private object HandleException(Exception exception, out int statusCode)
        {
            statusCode = 500;

            switch (exception)
            {
                case ConsultaCepException.CepNotFoundException cepNotFoundException:
                    statusCode = 404;
                    return new { error = "CEP não encontrado.", detail = cepNotFoundException.Message };

                case ConsultaCepException.InvalidCepException invalidCepException:
                    statusCode = 400;
                    return new { error = "Formato do CEP inválido.", detail = invalidCepException.Message };

                case ConsultaCepException.CepAlreadyExistsException cepExistsException:
                    statusCode = 409;
                    return new { error = "CEP já cadastrado.", detail = cepExistsException.Message };

                default:
                    return new { error = "Ocorreu um erro inesperado.", detail = exception.Message };
            }
        }
    }
}

