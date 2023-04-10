using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Queries.GetFrequency
{
    public class GetFrequencyQueryHandler : IRequestHandler<GetFrequencyQuery, FrequencyVm>
    {
        private readonly IMapper _mapper;
        private readonly IFrequencyRepository _frequencyRepository;

        public GetFrequencyQueryHandler(IMapper mapper, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<FrequencyVm> Handle(GetFrequencyQuery request, CancellationToken cancellationToken)
        {
            var frequency = await _frequencyRepository.GetByIdAsync(request.FrequencyId);

            if (frequency == null || !frequency.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Frequency)} with the id: {request.FrequencyId} not found");

            return _mapper.Map<FrequencyVm>(frequency);
        }
    }
}
