using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Features.Debts.Services;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateAverageTurnoverPerGoal
{
    public class CalculateAverageIncomePerGoalCommandHandler :IRequestHandler<CalculateAverageTurnoverPerGoalCommand, decimal>
    {
        public async Task<decimal> Handle(CalculateAverageTurnoverPerGoalCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var date = request.Goal.Deadline;
                var diff = DateTimeSpan.CompareDates(date, DateTime.Now);
                var months = diff.Years * 12 + diff.Months + (decimal)diff.Days / 30;
                return request.TotalTurnover / months;
            });
        }
    }
}
