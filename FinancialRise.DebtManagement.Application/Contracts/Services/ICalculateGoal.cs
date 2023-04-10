using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;

namespace FinancialRise.DebtManagement.Application.Contracts.Services
{
    public interface ICalculateGoal
    {
        Task<Decimal> CalculateGoalDebtRepayment(IDebtRepository debtRepository, Guid userId);
    }
}