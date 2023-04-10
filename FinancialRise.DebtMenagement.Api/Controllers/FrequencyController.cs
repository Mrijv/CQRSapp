using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.CreateFrequency;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.DeleteFrequency;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.UpdateFrequency;
using FinancialRise.DebtManagement.Application.Features.Frequencies.Queries.GetFrequency;
using FinancialRise.DebtManagement.Application.Features.Incomes.Commands.CreateIncome;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FrequencyController :ControllerBase
    {
        private readonly IMediator _mediator;

        public FrequencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("singleDetailedFrequency", Name = "GetUserFrequency")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<FrequencyVm>> GetUserFrequency(Guid frequencyId)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetFrequencyQuery() { FrequencyId = frequencyId, UserId = userId }));
        }

        [HttpPost(Name = "AddFrequency")]
        public async Task<ActionResult<CreateIncomeCommandResponse>> Create([FromBody] CreateFrequencyCommand createFrequencyCommand)
        {
            createFrequencyCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createFrequencyCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateFrequency")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateFrequencyCommand updateFrequencyCommand)
        {
            updateFrequencyCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(updateFrequencyCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteFrequency")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteFrequencyCommand() { FrequencyId = id, UserId = userId });
            return NoContent();
        }
    }
}
