using System;
using FinancialRise.DebtManagement.Application.Responses;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.CreateIncome
{
    public class CreateIncomeCommandResponse : BaseResponse
    {
        public Guid IncomeId { get; set; }
    }
}
