using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Savings.Queries.GetSaving
{
    public class GetSavingQuery : IRequest<SavingVm>
    {
        public Guid UserId { get; set; }
    }
}
