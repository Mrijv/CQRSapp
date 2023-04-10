using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.CreateDailyOperation;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.DeleteDailyOperation;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.UpdateDailyOperation;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByDay;
using FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByType;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DailyOperationController :ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyOperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allDailyOperationsByDay", Name = "GetUserDailyOperationsByDay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DailyOperationVm>>> GetUserDailyOperationsByDay(DateTime dateTime)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetDailyOperationsByDayQuery() { UserId = userId , PickedDay = dateTime}));
        }

        [HttpGet("allDailyOperationsByType", Name = "GetUserDailyOperationsByType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DailyOperationVm>>> GetUserDailyOperationsByType(TypeOfOperation typeOfOperation)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetDailyOperationsByTypeQuery() { UserId = userId, Operation = typeOfOperation}));
        }

        [HttpPost(Name = "AddDailyOperation")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDailyOperationCommand createDailyOperationCommand)
        {
            createDailyOperationCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createDailyOperationCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateDailyOperation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateDailyOperationCommand updateDailyOperationCommand)
        {
            updateDailyOperationCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var response = await _mediator.Send(updateDailyOperationCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteDailyOperation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteDailyOperationCommand() { DailyOperationId = id, UserId = userId });
            return NoContent();
        }
    }
}
