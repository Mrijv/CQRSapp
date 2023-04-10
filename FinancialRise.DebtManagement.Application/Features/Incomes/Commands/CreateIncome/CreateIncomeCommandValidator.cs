using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.CreateIncome
{
    public class CreateIncomeCommandValidator : AbstractValidator<CreateIncomeCommand>
    {
        private readonly IIncomeRepository _incomeRepository;

        public CreateIncomeCommandValidator(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IncomeNameUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(x => x.FirstRemit).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.LastRemit).GreaterThanOrEqualTo(DateTime.Now);
        }

        private async Task<bool> IncomeNameUnique(string name, CancellationToken token)
        {
            return !await _incomeRepository.IsIncomeNameExists(name);
        }
    }
}
