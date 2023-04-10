using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Features.Debts.Events;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.DeleteDebt
{
    public class DeleteDebtCommandHandler : IRequestHandler<DeleteDebtCommand>
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IMediator _mediator;

        public DeleteDebtCommandHandler(IDebtRepository debtRepository, IMediator mediator)
        {
            _debtRepository = debtRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteDebtCommand request, CancellationToken cancellationToken)
        {
            var debtToDelete = await _debtRepository.GetByIdAsync(request.DebtId);

            if (debtToDelete == null || !debtToDelete.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Debt)} with the id: {request.DebtId} not found");

            await _debtRepository.DeleteAsync(debtToDelete);
            await _mediator.Publish(new DebtChangedEvent(debtToDelete), cancellationToken);

            return Unit.Value;
        }
    }
}
