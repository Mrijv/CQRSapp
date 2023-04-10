using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Domain.Entities
{
    public class Frequency
    {
        public Guid FrequencyId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Number { get; set; } = 0;
        public UnitOfFrequency Unit { get; set; }
        public List<Outcome> Outcomes { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Debt> Debts { get; set; }
    }
}
