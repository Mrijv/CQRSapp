using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Contracts.Services;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Services
{
    public class CalculateGoal : ICalculateGoal
    {
        //when add debt rise an EVENT which is creating/updating/deleting the goal titled: "Debt Repayment"
        public async Task<Decimal> CalculateGoalDebtRepayment(IDebtRepository debtRepository, Guid userId)
        {
            var allDebts = await debtRepository.ListAllByUserAsync(userId);
            Decimal sumDebtOfTotal = 0;

            foreach (var debt in allDebts)
            {
                sumDebtOfTotal += debt.Total;
            }

            return sumDebtOfTotal;
        }
    }
}
