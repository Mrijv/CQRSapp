using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByType
{
    public class GetDailyOperationsByTypeQueryValidator: AbstractValidator<GetDailyOperationsByTypeQuery>
    {
        public GetDailyOperationsByTypeQueryValidator()
        {
            RuleFor(x => x.Operation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .IsInEnum();

        }
    }
}
