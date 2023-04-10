using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.CreateFrequency
{
    public class CreateFrequencyCommandHandler : IRequestHandler<CreateFrequencyCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IFrequencyRepository _frequencyRepository;

        public CreateFrequencyCommandHandler(IMapper mapper, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<Guid> Handle(CreateFrequencyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFrequencyCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exception(validationResult.ToString());

            var unit = _mapper.Map<UnitOfFrequency>(request.Unit);
            var frequency = _mapper.Map<Frequency>(request);
            frequency.Unit = unit;
            frequency = await _frequencyRepository.AddAsync(frequency);

            return frequency.FrequencyId;
        }
    }
}
