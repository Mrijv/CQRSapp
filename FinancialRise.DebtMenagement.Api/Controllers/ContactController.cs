using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Contacts.Commands.CreateContact;
using FinancialRise.DebtManagement.Application.Features.Contacts.Commands.DeleteContact;
using FinancialRise.DebtManagement.Application.Features.Contacts.Commands.UpdateContact;
using FinancialRise.DebtManagement.Application.Features.Contacts.Queries.GetContactsList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRise.DebtMenagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allContacts", Name = "GetAllUserContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ContactListVm>>> GetAllUserContacts(Guid debtId)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetContactsListQuery() { UserId = userId , DebtId = debtId}));
        }

        [HttpPost(Name = "AddContact")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContactCommand createContactCommand)
        {
            createContactCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createContactCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateContactCommand updateContactCommand)
        {
            updateContactCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(updateContactCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteContactCommand() { ContactId = id, UserId = userId });
            return NoContent();
        }
    }
}
