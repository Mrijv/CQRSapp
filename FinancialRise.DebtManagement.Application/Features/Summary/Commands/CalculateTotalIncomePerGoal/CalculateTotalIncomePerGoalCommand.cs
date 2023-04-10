using System;
using System.Threading;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateTotalIncomePerGoal
{
    public class CalculateTotalIncomePerGoalCommand :IRequest<decimal>
    {
        public Guid UserId { get; }
        public Goal Goal { get; }

        public CalculateTotalIncomePerGoalCommand(Guid userId, Goal goal, CancellationToken cancellationToken)
        {
            UserId = userId;
            Goal = goal;
        }
    }
}
