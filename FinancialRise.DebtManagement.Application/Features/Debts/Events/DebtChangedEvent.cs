using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Events
{
    public class DebtChangedEvent : INotification
    {
        public Debt CreatedDebt { get; }

        public DebtChangedEvent(Debt createdDebt)
        {
            CreatedDebt = createdDebt;
        }
    }
}
