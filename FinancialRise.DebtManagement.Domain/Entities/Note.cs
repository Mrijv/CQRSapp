using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class Note : AuditableEntity
    {
        public Guid NoteId { get; set; }
        public string Content { get; set; }
        public TypeOfNote TypeOfNote { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
