using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.UpdateDebt
{
    public class UpdateDebtCommand : IRequest<UpdateDebtCommandResponse>
    {
        public Guid DebtId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Decimal Instalment { get; set; }
        public Guid FrequencyId { get; set; }
        public Decimal Total { get; set; }
        public DateTime FirstInstalment { get; set; }
        public DateTime LastInstalment { get; set; }
        public Decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public bool FlatInstalment { get; set; }
    }
}
