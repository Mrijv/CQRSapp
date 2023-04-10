using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.CreateOutcome
{
    public class CreateOutcomeCommandValidator :AbstractValidator<CreateOutcomeCommand>
    {
        private readonly IOutcomeRepository _outcomeRepository;

        public CreateOutcomeCommandValidator(IOutcomeRepository outcomeRepository)
        {
            _outcomeRepository = outcomeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(OutcomeNameUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> OutcomeNameUnique(string name, CancellationToken token)
        {
            return !await _outcomeRepository.IsOutcomeNameExists(name);
        }
    }
}
