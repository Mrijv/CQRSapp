using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.DeleteOutcome
{
    public class DeleteOutcomeCommand : IRequest
    {
        public Guid OutcomeId { get; set; }
        public Guid UserId { get; set; }
    }
}
