using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateAverageTurnoverPerGoal;
using FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateTotalIncomePerGoal;
using FinancialRise.DebtManagement.Application.Features.Summary.Commands.CalculateTotalOutcomePerGoal;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Summary.Queries.GetSummary
{
    public class GetSummaryQueryHandler : IRequestHandler<GetSummaryQuery, SummaryVm>
    {
        private readonly IMediator _mediator;
        private readonly IGoalRepository _goalRepository;
        private readonly ISavingRepository _savingRepository;
        private const string GoalTitleOfDebt = "Debt Repayment";

        public GetSummaryQueryHandler( IMediator mediator, IGoalRepository goalRepository, ISavingRepository savingRepository)
        {
            _mediator = mediator;
            _goalRepository = goalRepository;
            _savingRepository = savingRepository;
        }

        public async Task<SummaryVm> Handle(GetSummaryQuery request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdAsync(request.GoalId);

            if (goal == null)
                return null;

            var totalIncome = await _mediator.Send(new CalculateTotalIncomePerGoalCommand(request.UserId, goal, cancellationToken));
            var averageMonthIncome = await _mediator.Send(new CalculateAverageTurnoverPerGoalCommand(goal, totalIncome, cancellationToken));
            var totalOutcome = await _mediator.Send(new CalculateTotalOutcomePerGoalCommand(request.UserId, goal));
            var averageMonthOutcome = await _mediator.Send(new CalculateAverageTurnoverPerGoalCommand(goal, totalOutcome, cancellationToken));
            var debtGoal = await _goalRepository.GetGoalOfUserByTitle(GoalTitleOfDebt, request.UserId);
            var totalDebt = 0m;

            if (debtGoal.Equals(goal))
                totalDebt = debtGoal.Amount;

            var saving = await _savingRepository.GetByUserId(request.UserId);
            var diff = totalIncome - totalOutcome - totalDebt;
            var description = $"You can save, invest or spent or your new goal: {diff}";

            if (diff <= 0)
                description =
                    $"You need to earn that amount of money in the future to at least be on zero equals: {Math.Abs(diff)}";

            var leftDebt = totalDebt - saving.TotalSaving;
            if (leftDebt < 0)
                leftDebt = 0;

            return new SummaryVm()
            {
                Difference = diff,
                Description = description,
                TotalIncome = totalIncome,
                AverageMonthIncome = averageMonthIncome,
                TotalOutcome = totalOutcome,
                AverageMonthOutcome = averageMonthOutcome,
                TotalDebt = totalDebt,
                Saving = saving.TotalSaving,
                LeftDebtIfResetSaving = leftDebt,
                DiffIfResetSaving = totalIncome - totalOutcome - leftDebt
            };
        }
    }
}
