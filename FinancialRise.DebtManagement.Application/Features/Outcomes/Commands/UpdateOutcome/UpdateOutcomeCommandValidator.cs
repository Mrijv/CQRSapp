using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.UpdateOutcome
{
    public class UpdateOutcomeCommandValidator : AbstractValidator<UpdateOutcomeCommand>
    {
        public UpdateOutcomeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }
    }
}
