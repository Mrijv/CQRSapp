using System;
using System.Collections.Generic;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtsList
{
    public class GetDebtsListQuery : IRequest<List<DebtListVm>>
    {
        public Guid UserId { get; set; }
    }
}
