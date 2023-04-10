using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtWithContacts
{
    public class GetDebtWithContactsQuery : IRequest<DebtWithContactsVm>
    {
        public Guid DebtId { get; set; }
        public Guid UserId { get; set; }
    }
}
