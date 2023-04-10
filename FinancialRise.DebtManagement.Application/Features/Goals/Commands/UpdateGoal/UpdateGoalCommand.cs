using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommand : IRequest<UpdateGoalCommandResponse>
    {
        public Guid GoalId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
