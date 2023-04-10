using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.CreateOutcome
{
    public class CreateOutcomeCommandHandler : IRequestHandler<CreateOutcomeCommand, CreateOutcomeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOutcomeRepository _outcomeRepository;
        private readonly IFrequencyRepository _frequencyRepository;

        public CreateOutcomeCommandHandler(IMapper mapper, IOutcomeRepository outcomeRepository, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _outcomeRepository = outcomeRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<CreateOutcomeCommandResponse> Handle(CreateOutcomeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOutcomeCommandResponse();
            var validator = new CreateOutcomeCommandValidator(_outcomeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.Success)
            {
                var frequency = await _frequencyRepository.GetByIdAsync(request.FrequencyId);
                if (frequency == null || !frequency.UserId.Equals(request.UserId))
                {
                    response.Message = "UserId with a given frequencyId doesn't exist in the database.";
                    response.Success = false;
                    return response;
                }

                var outcome = _mapper.Map<Outcome>(request);
                outcome = await _outcomeRepository.AddAsync(outcome);
                response.OutcomeId = outcome.OutcomeId;

                return response;
            }

            return response;
        }
    }
}
