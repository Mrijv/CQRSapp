using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.DeleteFrequency
{
    public class DeleteFrequencyCommandHandler : IRequestHandler<DeleteFrequencyCommand>
    {
        private readonly IFrequencyRepository _frequencyRepository;

        public DeleteFrequencyCommandHandler(IFrequencyRepository frequencyRepository)
        {
            _frequencyRepository = frequencyRepository;
        }

        public async Task<Unit> Handle(DeleteFrequencyCommand request, CancellationToken cancellationToken)
        {
            var frequencyToDelete = await _frequencyRepository.GetByIdAsync(request.FrequencyId);

            if (frequencyToDelete == null || !frequencyToDelete.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Frequency)} with the id: {request.FrequencyId} not found");

            await _frequencyRepository.DeleteAsync(frequencyToDelete);

            return Unit.Value;
        }
    }
}
