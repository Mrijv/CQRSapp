using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Services
{
    public interface ITurnoverCalculationHelper
    {
        Task<decimal> IncreaseTotalForDays(DateTime date, Decimal amount, Decimal totalAmount);
        Task<decimal> IncreaseTotalForWeeks(DateTime date, Decimal amount, Decimal totalAmount);
        Task<decimal> IncreaseTotalForMonths(DateTime date, Decimal amount, Decimal totalAmount);
        Task<decimal> IncreaseTotalForYears(DateTime date, Decimal amount, Decimal totalAmount);
    }
}