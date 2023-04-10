using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class DailyOperation :AuditableEntity
    {
        public Guid DailyOperationId { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public TypeOfOperation Operation { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
