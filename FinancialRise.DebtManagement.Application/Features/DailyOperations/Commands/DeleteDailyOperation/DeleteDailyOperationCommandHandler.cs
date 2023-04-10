using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.DeleteDailyOperation
{
    public class DeleteDailyOperationCommandHandler : IRequestHandler<DeleteDailyOperationCommand>
    {
        private readonly IDailyOperationRepository _dailyOperationRepository;

        public DeleteDailyOperationCommandHandler(IDailyOperationRepository dailyOperationRepository)
        {
            _dailyOperationRepository = dailyOperationRepository;
        }

        public async Task<Unit> Handle(DeleteDailyOperationCommand request, CancellationToken cancellationToken)
        {
            var dailyOperation = await _dailyOperationRepository.GetByIdAsync(request.DailyOperationId);

            if(dailyOperation==null || !dailyOperation.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(DailyOperation)} with the id: {request.DailyOperationId} not found");

            await _dailyOperationRepository.DeleteAsync(dailyOperation);

            return Unit.Value;
        }
    }
}
