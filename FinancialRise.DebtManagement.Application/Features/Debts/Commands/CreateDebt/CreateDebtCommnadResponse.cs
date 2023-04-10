using System;
using FinancialRise.DebtManagement.Application.Responses;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.CreateDebt
{
    public class CreateDebtCommnadResponse :BaseResponse
    {
        public Guid Id { get; set; }
    }
}
