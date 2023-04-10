using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Application.Features.Common;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtWithContacts
{
    public class DebtWithContactsVm
    {
        public Guid DebtId { get; set; }
        public string Name { get; set; }
        public Decimal Instalment { get; set; }
        public FrequencyDto InstalmentFrequency { get; set; }
        public Decimal Total { get; set; }
        public DateTime FirstInstalment { get; set; }
        public DateTime LastInstalment { get; set; }
        public double InterestRate { get; set; }
        public Decimal LoanAmount { get; set; }
        public bool FlatInstalment { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
    }
}
