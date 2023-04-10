using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Notes.Commands.CreateNote;
using FinancialRise.DebtManagement.Application.Features.Notes.Commands.DeleteNote;
using FinancialRise.DebtManagement.Application.Features.Notes.Commands.UpdateNote;
using FinancialRise.DebtManagement.Application.Features.Notes.Queries;
using FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNote;
using FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNotes;
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
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allNotes", Name = "GetAllUserNotesByType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<NoteVm>>> GetAllUserNotes(int typeOfNote)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetNotesByTypeQuery() { UserId = userId, TypeOfNote = (TypeOfNote)typeOfNote}));
        }

        [HttpGet("singleDetailedNote", Name = "GetUserNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NoteVm>> GetUserNote(Guid noteId)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            return Ok(await _mediator.Send(new GetNoteQuery() {NoteId = noteId, UserId = userId}));
        }

        [HttpPost(Name = "AddNote")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteCommand createNoteCommand)
        {
            createNoteCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            var id = await _mediator.Send(createNoteCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateNote")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNoteCommand updateNoteCommand)
        {
            updateNoteCommand.UserId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(updateNoteCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteNote")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse((ReadOnlySpan<char>)User.Claims.First(i => i.Type == "uid").Value);
            await _mediator.Send(new DeleteNoteCommand() { NoteId = id, UserId = userId });
            return NoContent();
        }
    }
}
