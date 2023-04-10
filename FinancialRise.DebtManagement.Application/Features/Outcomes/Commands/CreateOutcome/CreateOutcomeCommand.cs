using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.CreateOutcome
{
    public class CreateOutcomeCommand : IRequest<CreateOutcomeCommandResponse>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public Guid FrequencyId { get; set; }
        public DateTime FirstRemit { get; set; }
        public DateTime LastRemit { get; set; }
    }
}
