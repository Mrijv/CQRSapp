using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Debts.Commands.CreateDebt;
using FinancialRise.DebtManagement.Application.Features.Debts.Commands.DeleteDebt;
using FinancialRise.DebtManagement.Application.Features.Debts.Commands.UpdateDebt;
using FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtsList;
using FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtWithContacts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DebtController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DebtController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddDebt")]
        public async Task<ActionResult<CreateDebtCommnadResponse>> Create([FromBody] CreateDebtCommand createDebtCommand)
        {
            createDebtCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createDebtCommand);
            return Ok(id);
        }

        [HttpGet("allDebts", Name="GetAllUserDebts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DebtListVm>>> GetAllUserDebts()
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetDebtsListQuery() {UserId = userId }));
        }
        
        [HttpGet("singleDetailedDebt", Name = "GetUserDebtWithContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DebtWithContactsVm>> GetUserDebtWithContacts(Guid debtId)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            //var userId = Guid.Parse((ReadOnlySpan<char>)User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await _mediator.Send(new GetDebtWithContactsQuery() { DebtId = debtId, UserId = userId }));
        }

        [HttpPut(Name = "UpdateDebt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateDebtCommandResponse>> Update([FromBody] UpdateDebtCommand updateDebtCommand)
        {
            updateDebtCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var response = await _mediator.Send(updateDebtCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}",Name = "DeleteDebt")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteDebtCommand() { DebtId = id, UserId = userId});
            return NoContent();
        }
    }
}
