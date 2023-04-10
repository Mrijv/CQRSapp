using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal
{
    public class CreateGoalCommand : IRequest<CreateGoalCommandResponse>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
