using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class Contact: AuditableEntity
    {
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DebtId { get; set; }
        public Debt Debt { get; set; }
    }
}
