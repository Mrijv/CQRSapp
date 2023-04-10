using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommandValidation :AbstractValidator<UpdateGoalCommand>
    {

        public UpdateGoalCommandValidation()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed 300 characters.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(p => p.Deadline)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(p => DateTime.Now).WithMessage("date must be in the future");
        }
    }
}
