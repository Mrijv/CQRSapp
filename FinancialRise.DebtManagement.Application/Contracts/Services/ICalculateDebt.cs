using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Services
{
    public interface ICalculateDebt
    {
        Task<(Decimal, Decimal)> CalculateDebtFixedInstalmentAndTotal(Debt debt);
    }
}