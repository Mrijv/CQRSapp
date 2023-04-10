using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNote
{
    public class GetNoteQuery : IRequest<NoteVm>
    {
        public Guid NoteId { get; set; }
        public Guid UserId { get; set; }
    }
}
