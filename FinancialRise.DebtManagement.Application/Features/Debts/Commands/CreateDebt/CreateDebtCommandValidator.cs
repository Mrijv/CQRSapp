using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.CreateDebt
{
    public class CreateDebtCommandValidator: AbstractValidator<CreateDebtCommand>
    {
        private readonly IDebtRepository _debtRepository;

        public CreateDebtCommandValidator(IDebtRepository debtRepository)
        {
            _debtRepository = debtRepository;

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
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(DebtNameUnique)
                .WithMessage("An debt with the same name and date already exists.");

            RuleFor(p => p.Total)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        public async Task<bool> DebtNameUnique(string name, CancellationToken token)
        {
            return !await _debtRepository.IsDebtNameExists(name);
        }
    }
}
