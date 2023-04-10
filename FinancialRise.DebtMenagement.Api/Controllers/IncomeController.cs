using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Incomes.Commands.CreateIncome;
using FinancialRise.DebtManagement.Application.Features.Incomes.Commands.DeleteIncome;
using FinancialRise.DebtManagement.Application.Features.Incomes.Commands.UpdateIncome;
using FinancialRise.DebtManagement.Application.Features.Incomes.Queries.GetIncomesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allIncomes", Name = "GetAllUserIncomes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<IncomesListVm>>> GetAllUserIncomes()
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetIncomesListQuery() { UserId = userId }));
        }

        [HttpPost(Name = "AddIncome")]
        public async Task<ActionResult<CreateIncomeCommandResponse>> Create([FromBody] CreateIncomeCommand createIncomeCommand)
        {
            createIncomeCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createIncomeCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateIncome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateIncomeCommandResponse>> Update([FromBody] UpdateIncomeCommand updateIncomeCommand)
        {
            updateIncomeCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var response = await _mediator.Send(updateIncomeCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteIncome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteIncomeCommand() { IncomeId = id, UserId = userId });
            return NoContent();
        }
    }
}
