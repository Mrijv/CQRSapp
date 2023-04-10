using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.DeleteDebt
{
    public class DeleteDebtCommand: IRequest
    {
        public Guid DebtId { get; set; }
        public Guid UserId { get; set; }
    }
}
