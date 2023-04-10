using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries
{
    public class DailyOperationVm
    {
        public Guid DailyOperationId { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public TypeOfOperation Operation { get; set; }
    }
}
