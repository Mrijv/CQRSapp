using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateTotalIncomePerGoal
{
    public class CalculateTotalIncomePerGoalCommandHandler :IRequestHandler<CalculateTotalIncomePerGoalCommand, decimal>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly ITurnoverCalculationHelper _turnoverCalculation;

        public CalculateTotalIncomePerGoalCommandHandler(IIncomeRepository incomeRepository, ITurnoverCalculationHelper turnoverCalculation)
        {
            _incomeRepository = incomeRepository;
            _turnoverCalculation = turnoverCalculation;
        }

        public async Task<decimal> Handle(CalculateTotalIncomePerGoalCommand request, CancellationToken cancellationToken)
        {
            var goalDeadline = request.Goal.Deadline;
            var allIncomes = await _incomeRepository.ListAllByUserAsync(request.UserId);
            var totalAmount = 0m;

            foreach (var income in allIncomes)
            {
                if (income.Frequency.Unit.Equals(UnitOfFrequency.Day))
                {
                    if (income.LastRemit > goalDeadline || income.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForDays(goalDeadline, income.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForDays(income.LastRemit, income.Amount, totalAmount);
                    }
                }
                else if (income.Frequency.Unit.Equals(UnitOfFrequency.Week))
                {
                    if (income.LastRemit > goalDeadline || income.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForWeeks(goalDeadline, income.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForWeeks(income.LastRemit, income.Amount, totalAmount);
                    }
                }
                else if (income.Frequency.Unit.Equals(UnitOfFrequency.Month))
                {
                    if (income.LastRemit > goalDeadline || income.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForMonths(goalDeadline, income.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForMonths(income.LastRemit, income.Amount, totalAmount);
                    }
                }
                else
                {
                    if (income.LastRemit > goalDeadline || income.LastRemit == DateTime.MinValue)
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForYears(goalDeadline, income.Amount, totalAmount);
                    }
                    else
                    {
                        totalAmount = await _turnoverCalculation.IncreaseTotalForYears(income.LastRemit, income.Amount, totalAmount);
                    }
                }
            }

            return totalAmount;
        }
    }
}
