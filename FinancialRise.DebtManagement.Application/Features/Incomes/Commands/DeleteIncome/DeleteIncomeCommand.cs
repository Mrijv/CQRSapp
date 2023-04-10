using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.DeleteIncome
{
    public class DeleteIncomeCommand : IRequest
    {
        public Guid IncomeId { get; set; }
        public Guid UserId { get; set; }
    }
}
