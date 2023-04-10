using System;
using FinancialRise.DebtManagement.Application.Responses;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.CreateOutcome
{
    public class CreateOutcomeCommandResponse : BaseResponse
    {
        public Guid OutcomeId { get; set; }
    }
}
