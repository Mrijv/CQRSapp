using System;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.UpdateIncome
{
    public class UpdateIncomeCommandValidator : AbstractValidator<UpdateIncomeCommand>
    {
        public UpdateIncomeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(x => x.FirstRemit).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.LastRemit).GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
