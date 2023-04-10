using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.DeleteGoal;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.UpdateGoal;
using FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalDetail;
using FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalController :ControllerBase
    { 
        private readonly IMediator _mediator;

        public GoalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allGoals", Name = "GetAllUserGoals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GoalListVm>>> GetAllUserGoals()
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetGoalsListQuery() { UserId = userId }));
        }

        [HttpGet("singleDetailedGoal", Name = "GetUserGoal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GoalDetailVm>> GetUserGoal(Guid goalId)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetGoalDetailQuery() { GoalId = goalId, UserId = userId }));
        }

        [HttpPost(Name = "AddGoal")]
        public async Task<ActionResult<CreateGoalCommandResponse>> Create([FromBody] CreateGoalCommand createGoalCommand)
        {
            createGoalCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createGoalCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateGoal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateGoalCommandResponse>> Update([FromBody] UpdateGoalCommand updateGoalCommand)
        {
            updateGoalCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var response = await _mediator.Send(updateGoalCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteGoal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteGoalCommand() { GoalId = id, UserId = userId });
            return NoContent();
        }
    }
}
