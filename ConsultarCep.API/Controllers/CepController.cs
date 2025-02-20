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

        [HttpGet("{cep}")]
        public async Task<IActionResult> ConsultarCep(string cep)
        {
            var result = await _cepService.ConsultarCep(cep);
            return Ok(result);
        }
    }
}

