using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Savings.Queries.GetSaving;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SavingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SavingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("singleSaving", Name = "GetUserSaving")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SavingVm>> GetUserSaving()
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetSavingQuery() { UserId = userId }));
        }
    }
}
