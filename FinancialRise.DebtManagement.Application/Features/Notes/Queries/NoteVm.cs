using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Queries
{
    public class NoteVm
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public TypeOfNote TypeOfNote { get; set; }
    }
}
