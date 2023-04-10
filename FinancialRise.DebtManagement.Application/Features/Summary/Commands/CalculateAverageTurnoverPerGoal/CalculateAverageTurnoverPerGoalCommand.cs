using System.Threading;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateAverageTurnoverPerGoal
{
    public class CalculateAverageTurnoverPerGoalCommand : IRequest<decimal>
    {
        public Goal Goal { get; }
        public decimal TotalTurnover { get; }

        public CalculateAverageTurnoverPerGoalCommand(Goal goal, decimal totalTurnover, CancellationToken cancellationToken)
        {
            Goal = goal;
            TotalTurnover = totalTurnover;
        }
    }
}
