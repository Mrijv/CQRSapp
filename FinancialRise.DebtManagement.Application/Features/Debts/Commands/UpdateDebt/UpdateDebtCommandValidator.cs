using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.UpdateDebt
{
    class UpdateDebtCommandValidator : AbstractValidator<UpdateDebtCommand>
    {
        public UpdateDebtCommandValidator()
        {
            RuleFor(p => p.FirstInstalment)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.LastInstalment)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.InterestRate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.LoanAmount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Total)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }
    }
}
