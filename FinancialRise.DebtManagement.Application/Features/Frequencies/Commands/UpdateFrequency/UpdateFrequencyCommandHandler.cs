using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;
using FluentValidation;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.UpdateFrequency
{
    public class UpdateFrequencyCommandHandler : IRequestHandler<UpdateFrequencyCommand>
    {
        private readonly IMapper _mapper;
        private readonly IFrequencyRepository _frequencyRepository;

        public UpdateFrequencyCommandHandler(IMapper mapper, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<Unit> Handle(UpdateFrequencyCommand request, CancellationToken cancellationToken)
        {
            var frequencyToUpdate = await _frequencyRepository.GetByIdAsync(request.FrequencyId);

            if (frequencyToUpdate == null || !frequencyToUpdate.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Frequency)} with the id: {request.FrequencyId} not found");

            var validator = new UpdateFrequencyCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            _mapper.Map(request, frequencyToUpdate, typeof(UpdateFrequencyCommand), typeof(Frequency));
            var unit = _mapper.Map<UnitOfFrequency>(request.Unit);
            frequencyToUpdate.Unit = unit;

            await _frequencyRepository.UpdateAsync(frequencyToUpdate);

            return Unit.Value;
        }
    }
}
