using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public abstract class Turnover : AuditableEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public Guid FrequencyId { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime FirstRemit { get; set; }
        public DateTime LastRemit { get; set; }
    }
}
