using System.Threading.Tasks;
using Modelo.Ubs.Dominio.Contratos;
using Modelo.Ubs.Dominio.Excecoes;
using Modelo.Ubs.Dominio.Mediador.Mediadores.Requisicoes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Modelo.Ubs.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UnidadeSaudeController : ControllerBase
    {
        private readonly IMediator mediator;

        public UnidadeSaudeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(RetornoUnidadeSaudeContrato), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Obter([FromQuery] UnidadeSaudeContrato contrato)
        {
            try
            {
                var requisicao = new UnidadeSaudeRequisicao(contrato);
                var retorno = await mediator.Send(requisicao).ConfigureAwait(false);

                if (retorno == null)
                    return NotFound();

                return Ok(retorno);
            }
            catch (UnidadeSaudeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}