using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Application.Features.Debts.Services;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Services
{
    public class TurnoverCalculationHelper : ITurnoverCalculationHelper
    {
        public async Task<decimal> IncreaseTotalForDays(DateTime date, Decimal amount, Decimal totalAmount)
        {
            return await Task.Run(() =>
            {
                var days = (decimal)Math.Ceiling((date - DateTime.Now).TotalDays);
                return totalAmount += days * amount;
            });
        }

        public async Task<decimal> IncreaseTotalForWeeks(DateTime date, Decimal amount, Decimal totalAmount)
        {
            return await Task.Run(() =>
            {
                var weeks = (decimal)(date - DateTime.Now).Days / 7;
                return totalAmount += weeks * amount;
            });
        }

        public async Task<decimal> IncreaseTotalForMonths(DateTime date, Decimal amount, Decimal totalAmount)
        {
            return await Task.Run(() =>
            {
                var diff = DateTimeSpan.CompareDates(date, DateTime.Now);
                var months = diff.Years * 12 + diff.Months + (decimal)diff.Days / 30;
                return totalAmount += months * amount;
            });
        }

        public async Task<decimal> IncreaseTotalForYears(DateTime date, Decimal amount, Decimal totalAmount)
        {
            return await Task.Run(() =>
            {
                var diff = DateTimeSpan.CompareDates(date, DateTime.Now);
                var years = diff.Years + (decimal)diff.Months / 12 + diff.Days / 365.25m;
                return totalAmount += years * amount;
            });
        }
    }
}
