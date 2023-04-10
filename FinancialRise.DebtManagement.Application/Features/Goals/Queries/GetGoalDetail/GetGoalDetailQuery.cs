using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalDetail
{
    public class GetGoalDetailQuery : IRequest<GoalDetailVm>
    {
        public Guid GoalId { get; set; }
        public Guid UserId { get; set; }
    }
}
