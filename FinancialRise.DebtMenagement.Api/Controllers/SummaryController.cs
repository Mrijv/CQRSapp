using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtWithContacts;
using FinancialRise.DebtManagement.Application.Features.Summary.Queries.GetSummary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SummaryController :ControllerBase
    {
        private readonly IMediator _mediator;

        public SummaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("singleSummaryPerMonth", Name = "GetUserSummaryPerMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DebtWithContactsVm>> GetUserSummaryPerMonth(Guid goalId)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetSummaryQuery() { GoalId = goalId, UserId = userId }));
        }
    }
}
