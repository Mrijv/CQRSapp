using System;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByDay
{
    public class GetDailyOperationsByDayQueryValidator : AbstractValidator<GetDailyOperationsByDayQuery>
    {
        public GetDailyOperationsByDayQueryValidator()
        {
            RuleFor(x => x.PickedDay)
                .LessThan(DateTime.Now)
                .WithMessage("Picking a day from the future doesn't make sense in this context.");
        }
    }
}
