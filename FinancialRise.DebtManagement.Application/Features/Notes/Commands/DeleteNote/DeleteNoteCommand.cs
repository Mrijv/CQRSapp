using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand :IRequest
    {
        public Guid NoteId { get; set; }
        public Guid UserId { get; set; }
    }
}
