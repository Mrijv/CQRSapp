using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateTotalOutcomePerGoal
{
    public class CalculateTotalOutcomePerGoalCommandHandler :IRequestHandler<CalculateTotalOutcomePerGoalCommand, decimal>
    {
        private readonly IOutcomeRepository _outcomeRepository;
        private readonly ITurnoverCalculationHelper _turnoverCalculation;

        public CalculateTotalOutcomePerGoalCommandHandler(IOutcomeRepository outcomeRepository, ITurnoverCalculationHelper turnoverCalculation)
        {
            _outcomeRepository = outcomeRepository;
            _turnoverCalculation = turnoverCalculation;
        }

        public async Task<decimal> Handle(CalculateTotalOutcomePerGoalCommand request, CancellationToken cancellationToken)
        {
            var goalDeadline = request.Goal.Deadline;
            var allOutcomes = await _outcomeRepository.ListAllByUserAsync(request.UserId);
            var totalAmount = 0m;

            foreach (var outcome in allOutcomes)
            {
                if (outcome.Frequency.Unit.Equals(UnitOfFrequency.Day))
                {
                    if (outcome.LastRemit > goalDeadline || outcome.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForDays(goalDeadline, outcome.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForDays(outcome.LastRemit, outcome.Amount, totalAmount);
                    }
                }
                else if (outcome.Frequency.Unit.Equals(UnitOfFrequency.Week))
                {
                    if (outcome.LastRemit > goalDeadline || outcome.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForWeeks(goalDeadline, outcome.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForWeeks(outcome.LastRemit, outcome.Amount, totalAmount);
                    }
                }
                else if (outcome.Frequency.Unit.Equals(UnitOfFrequency.Month))
                {
                    if (outcome.LastRemit > goalDeadline || outcome.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForMonths(goalDeadline, outcome.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForMonths(outcome.LastRemit, outcome.Amount, totalAmount);
                    }
                }
                else
                {
                    if (outcome.LastRemit > goalDeadline || outcome.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForYears(goalDeadline, outcome.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForYears(outcome.LastRemit, outcome.Amount, totalAmount);
                    }
                }
            }

            return totalAmount;
        }
    }
}
