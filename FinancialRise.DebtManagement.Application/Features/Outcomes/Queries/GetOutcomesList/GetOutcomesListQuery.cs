using System;
using System.Collections.Generic;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Queries.GetOutcomesList
{
    public class GetOutcomesListQuery : IRequest<List<OutcomesListVm>>
    {
        public Guid UserId { get; set; }
    }
}
