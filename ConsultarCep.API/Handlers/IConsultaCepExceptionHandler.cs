using Microsoft.AspNetCore.Mvc.Filters;

namespace ConsultarCep.API.Handlers
{
    public interface IConsultaCepExceptionHandler
    {
        Task HandleExceptionAsync(ExceptionContext context);
    }
}
