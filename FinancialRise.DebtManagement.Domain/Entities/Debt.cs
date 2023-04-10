using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class Debt : AuditableEntity
    {
        public Guid DebtId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public Decimal Instalment { get; set; }
        public Guid FrequencyId { get; set; }
        public Frequency InstalmentFrequency { get; set; }
        public Decimal Total { get; set; }
        public Decimal LoanAmount { get; set; }
        public DateTime FirstInstalment { get; set; }
        public DateTime LastInstalment { get; set; }
        public double InterestRate { get; set; }
        public bool FlatInstalment { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
