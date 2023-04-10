using System;
using System.Collections.Generic;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalList
{
    public class GetGoalsListQuery : IRequest<List<GoalListVm>>
    {
        public Guid UserId { get; set; }
    }
}
