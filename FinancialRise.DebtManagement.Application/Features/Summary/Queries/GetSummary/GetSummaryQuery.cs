using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Queries.GetSummary
{
    public class GetSummaryQuery: IRequest<SummaryVm>
    {
        public Guid UserId { get; set; }
        public Guid GoalId { get; set; }
        //by default per month but in the future can be set by user
    }
}
