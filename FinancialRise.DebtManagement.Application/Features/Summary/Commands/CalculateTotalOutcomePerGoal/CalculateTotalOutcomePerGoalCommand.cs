using System;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateTotalOutcomePerGoal
{
    public class CalculateTotalOutcomePerGoalCommand :IRequest<decimal>
    {
        public Guid UserId { get;  }
        public Goal Goal { get; }

        public CalculateTotalOutcomePerGoalCommand(Guid userId, Goal goal)
        {
            UserId = userId;
            Goal = goal;
        }
    }
}
