using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Services
{
    public class CalculateDebt : ICalculateDebt
    {
        public Task<(Decimal,Decimal)> CalculateDebtFixedInstalmentAndTotal(Debt debt)
        {
            return Task.Run(() =>
            {
                var q = 1 + (debt.InterestRate / 12) / 100;
                var qDecimal = Convert.ToDecimal(q);
                var diffDates = DateTimeSpan.CompareDates(debt.LastInstalment, debt.FirstInstalment);

                if (diffDates == null)
                    throw new Exception("DateTimeSpan.CompareDates returned null");

                var months = diffDates.Years*12 + diffDates.Months;
                var pow = Convert.ToDecimal(Math.Pow(q, months));
                var instalment = debt.LoanAmount * pow * (qDecimal - 1) / (pow - 1);
                var total = instalment * months;

                return (instalment,total);
            });
        }

        //public Decimal CalculateDebtFallingInstalment(){}
    }
}
