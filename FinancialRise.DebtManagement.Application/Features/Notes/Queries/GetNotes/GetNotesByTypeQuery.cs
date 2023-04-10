using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNotes
{
    public class GetNotesByTypeQuery : IRequest<List<NoteVm>>
    {
        public Guid UserId { get; set; }
        public TypeOfNote TypeOfNote { get; set; }
    }
}
