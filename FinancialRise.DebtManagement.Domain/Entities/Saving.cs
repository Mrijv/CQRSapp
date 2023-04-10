using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class Saving : AuditableEntity
    {
        public Guid SavingId { get; set; }
        public Decimal TotalSaving { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
