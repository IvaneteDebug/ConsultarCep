using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConsultarCep.API.Handlers
{
    public class ConsultaCepHandlerException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = HandleException(context.Exception, out int statusCode);

            context.Result = new ObjectResult(response) { StatusCode = statusCode };
            context.ExceptionHandled = true;
        }

        private object HandleException(Exception exception, out int statusCode)
        {
            statusCode = exception switch
            {
                ConsultaCepException.CepNotFoundException => 404,
                ConsultaCepException.InvalidCepException => 400,
                ConsultaCepException.CepAlreadyExistsException => 409,
                _ => 500
            };

            return new
            {
                error = exception.GetType().Name,
                message = exception.Message
            };
        }
    }
}
