using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal;
using FinancialRise.DebtManagement.Application.Features.Goals.Commands.UpdateGoal;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Events
{
    public class DebtChangedEventHandler : INotificationHandler<DebtChangedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IGoalRepository _goalRepository;
        private readonly ICalculateGoal _calculateGoal;
        private readonly IDebtRepository _debtRepository;
        private readonly IMapper _mapper;
        private const string GoalTitleOfDebt = "Debt Repayment";

        public DebtChangedEventHandler(IMediator mediator, IGoalRepository goalRepository, 
            ICalculateGoal calculateGoal, IDebtRepository debtRepository, IMapper mapper)
        {
            _mediator = mediator;
            _goalRepository = goalRepository;
            _calculateGoal = calculateGoal;
            _debtRepository = debtRepository;
            _mapper = mapper;
        }

        public async Task Handle(DebtChangedEvent @event, CancellationToken cancellationToken)
        {
            var userId = @event.CreatedDebt.UserId;
            var goal = await _goalRepository.GetGoalOfUserByTitle(GoalTitleOfDebt, userId);
            var newAmount = await _calculateGoal.CalculateGoalDebtRepayment(_debtRepository, userId);

            if (goal == null)
            {
                var debtGoal = new CreateGoalCommand()
                {
                    Amount = newAmount,
                    Deadline = @event.CreatedDebt.LastInstalment,
                    Description =
                        "Focus your all power to repay you debt and become free. It is worth of your effort! Believe.",
                    Title = GoalTitleOfDebt,
                    UserId = userId
                };

                await _mediator.Send(debtGoal, cancellationToken);
            }
            else
            {
                goal.Amount = newAmount;
                var goalToUpdate = _mapper.Map<UpdateGoalCommand>(goal);

                await _mediator.Send(goalToUpdate, cancellationToken);
            }
        }
    }
}
