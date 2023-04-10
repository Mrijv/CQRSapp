using FinancialRise.DebtManagement.Domain.Common;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.UpdateDailyOperation
{
    public class UpdateDailyOperationCommandValidator : AbstractValidator<UpdateDailyOperationCommand>
    {
        public UpdateDailyOperationCommandValidator()
        {
            When(x => x.Operation == TypeOfOperation.Saving, () =>
            {
                RuleFor(c => c.Amount).GreaterThan(0);
            });

            When(x => x.Operation == TypeOfOperation.DailyOutcome, () =>
            {
                RuleFor(c => c.Amount).LessThan(0);
            });
        }
    }
}
