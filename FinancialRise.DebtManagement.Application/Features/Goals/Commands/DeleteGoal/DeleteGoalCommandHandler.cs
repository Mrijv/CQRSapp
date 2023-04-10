using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.DeleteGoal
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
    {
        private readonly IGoalRepository _goalRepository;

        public DeleteGoalCommandHandler(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<Unit> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            var goalToDelete = await _goalRepository.GetByIdAsync(request.GoalId);

            if(goalToDelete == null || !goalToDelete.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Goal)} with the id: {request.GoalId} not found");

            await _goalRepository.DeleteAsync(goalToDelete);

            return Unit.Value;
        }
    }
}
