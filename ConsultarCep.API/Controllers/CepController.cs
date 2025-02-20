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

            return Ok(new { message = "CEP consultado com sucesso.", data = cepExistente });
        }
    }
}

