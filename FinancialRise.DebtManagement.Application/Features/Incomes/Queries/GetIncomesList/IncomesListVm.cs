using System;
using FinancialRise.DebtManagement.Application.Features.Common;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Queries.GetIncomesList
{
    public class IncomesListVm
    {
        public Guid IncomeId { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public FrequencyDto Frequency { get; set; }
        public DateTime FirstRemit { get; set; }
        public DateTime LastRemit { get; set; }
    }
}
