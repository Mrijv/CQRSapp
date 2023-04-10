using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.DeleteGoal
{
    public class DeleteGoalCommand : IRequest
    {
        public Guid GoalId { get; set; }
        public Guid UserId { get; set; }
    }
}
