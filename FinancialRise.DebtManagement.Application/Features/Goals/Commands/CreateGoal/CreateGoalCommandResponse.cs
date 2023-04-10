using System;
using FinancialRise.DebtManagement.Application.Responses;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal
{
    public class CreateGoalCommandResponse : BaseResponse
    {
        public Guid GoalId { get; set; }
    }
}
