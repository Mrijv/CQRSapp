using System;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Queries.GetSummary
{
    public class SummaryVm
    {
        public Decimal Difference { get; set; } //total(income - outcome - debt)
        public string Description { get; set; } //to coś opisujace Difference
        public Decimal TotalDebt { get; set; } //to goal.amount o name == DebtRepayment
        public Decimal TotalIncome { get; set; }
        public Decimal AverageMonthIncome { get; set; }
        public Decimal TotalOutcome { get; set; } //skorzystaj z dto do return obu
        public Decimal AverageMonthOutcome { get; set; } 
        public Decimal Saving { get; set; } //to po prostu get saving query co mam
        public Decimal LeftDebtIfResetSaving { get; set; } //symulacja command stworz
        public Decimal DiffIfResetSaving { get; set; } // symulacja command zwraca te dwie wartosci jako dto
    }
}
