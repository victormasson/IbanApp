using IbanApp.Domain.UseCases.InformationBancaires.Commands;
using IbanApp.Domain.UseCases.InformationBancaires.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IbanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationBancairesController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformationBancaireDto>>> GetInformationBancaireFromSalarie([FromQuery] GetInformationBancaireQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost(nameof(CreateInformationBancaire))]
        public async Task<ActionResult<IEnumerable<InformationBancaireDto>>> CreateInformationBancaire([FromBody] CreateInformationBancaireCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(nameof(CreateInformationBancaires))]
        public async Task<ActionResult<IEnumerable<InformationBancaireDto>>> CreateInformationBancaires([FromBody] CreateInformationBancairesCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
