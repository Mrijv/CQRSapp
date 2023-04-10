using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.CreateOutcome;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.DeleteOutcome;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.UpdateOutcome;
using FinancialRise.DebtManagement.Application.Features.Outcomes.Queries.GetOutcomesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OutcomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OutcomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allOutcomes", Name = "GetAllUserIOutcomes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<OutcomesListVm>>> GetAllUserOutcomes()
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetOutcomesListQuery() { UserId = userId }));
        }

        [HttpPost(Name = "AddOutcome")]
        public async Task<ActionResult<CreateOutcomeCommandResponse>> Create([FromBody] CreateOutcomeCommand createOutcomeCommand)
        {
            createOutcomeCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createOutcomeCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateOutcome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateOutcomeCommandResponse>> Update([FromBody] UpdateOutcomeCommand updateOutcomeCommand)
        {
            updateOutcomeCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var response = await _mediator.Send(updateOutcomeCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteOutcome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteOutcomeCommand() { OutcomeId = id, UserId = userId });
            return NoContent();
        }
    }
}
