using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.DeleteOutcome
{
    public class DeleteOutcomeCommandHandler : IRequestHandler<DeleteOutcomeCommand>
    {
        private readonly IOutcomeRepository _outcomeRepository;

        public DeleteOutcomeCommandHandler(IOutcomeRepository outcomeRepository)
        {
            _outcomeRepository = outcomeRepository;
        }

        public async Task<Unit> Handle(DeleteOutcomeCommand request, CancellationToken cancellationToken)
        {
            var outcomeToDelete = await _outcomeRepository.GetByIdAsync(request.OutcomeId);

            if (outcomeToDelete == null)
                throw new Exception($"{nameof(Outcome)} with the id: {request.OutcomeId} not found");

            await _outcomeRepository.DeleteAsync(outcomeToDelete);

            return Unit.Value;
        }
    }
}