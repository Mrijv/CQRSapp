using System;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtsList
{
    public class DebtListVm
    {
        public Guid DebtId { get; set; }
        public string Name { get; set; }
        public Decimal Instalment { get; set; }
        public DateTime FirstInstalment { get; set; }
        public Decimal Total { get; set; }
        public Decimal LoanAmount { get; set; }
        public bool FlatInstalment { get; set; }
    }
}
