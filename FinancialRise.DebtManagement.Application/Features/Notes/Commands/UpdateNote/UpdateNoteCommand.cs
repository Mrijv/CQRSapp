using System;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public Guid NoteId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public TypeOfNote TypeOfNote { get; set; }
    }
}
