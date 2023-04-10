using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal
{
    public class CreateGoalCommandValidator :AbstractValidator<CreateGoalCommand>
    {
        private readonly IGoalRepository _goalRepository;

        public CreateGoalCommandValidator(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MustAsync((command, domain, ctn)=> GoalTitleUnique(command.Title, command.UserId, ctn))
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

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

        private async Task<bool> GoalTitleUnique(string name, Guid userId, CancellationToken ctn)
        {
            return !await _goalRepository.IsGoalTitleExists(name, userId);
        }
    }
}
