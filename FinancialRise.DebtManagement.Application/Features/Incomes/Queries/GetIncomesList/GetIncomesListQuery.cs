using System;
using System.Collections.Generic;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Queries.GetIncomesList
{
    public class GetIncomesListQuery : IRequest<List<IncomesListVm>>
    {
        public Guid UserId { get; set; }
    }
}
