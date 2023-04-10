using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class Goal : AuditableEntity
    {
        public Guid GoalId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Title { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
