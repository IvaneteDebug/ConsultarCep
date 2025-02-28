using ConsultarCep.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultarCep.API.Controllers
{
    [Route("api/cep")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;
        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        // GET api/cep/1 Consultar CEP
        [HttpGet("{cep}")]
        public async Task<IActionResult> ConsultarCep(string cep)
        {
            var cepExistente = await _cepService.ConsultarCep(cep);

            if (cepExistente != null && cepExistente.Fonte == "Banco de Dados")
            {
                return Ok(new
                {
                    message = "CEP já cadastrado.",
                    data = cepExistente
                });
            }

            return Ok(new
            {
                message = "CEP cadastrado com sucesso.",
                data = cepExistente
            });
        }
    }
}


