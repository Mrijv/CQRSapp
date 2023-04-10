using System;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public TypeOfNote TypeOfNote { get; set; }
        public Guid UserId { get; set; }
    }
}
